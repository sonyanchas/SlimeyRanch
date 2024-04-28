using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreUIText;
    public int Score;
    [SerializeField] int TimeSet;
    public int Timer;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0; // Initialize score as 0

    }

    // Update is called once per frame
    void Update()
    {
        
        ScoreUIText.text = Score.ToString(); // Update both strings to show score and time
        
       
    }
}