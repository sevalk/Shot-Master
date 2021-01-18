using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public int score;
    void Start()
    {
        
    }

    
    void Update()
    {
        scoreText.text = score.ToString();

    }
}
