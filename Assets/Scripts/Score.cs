using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;

    public TMP_Text scoreText;

    private int collisions = 0;

    [SerializeField] private AudioSource scoreSfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    private void OnTriggerEnter(Collider collision)
    {
        collisions++;
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collisions == 1)
            {
                score++;
                scoreSfx.Play();
            }
        }
    }
}
