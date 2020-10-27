using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text myScore;
    [SerializeField]
    private int score = 0;

    private void Start()
    {
        myScore.text = "Score:";
    }

    private void Update()
    {
        myScore.text = "Score:" + score;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            
            score++;
        }
    }
}
