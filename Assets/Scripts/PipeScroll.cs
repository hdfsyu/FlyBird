using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = -5.0f;

    [SerializeField] private GameObject pipeSpawner;

    [SerializeField] private GameObject pipePrefab;

    private int collisions = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(scrollSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisions++;
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            if (collisions == 1)
            {
                Instantiate(this.gameObject, pipeSpawner.transform.position, Quaternion.identity);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Invoke("restartGame", 3.0f);
        }
    }

    void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
