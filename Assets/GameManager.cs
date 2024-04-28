using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreUIText;
    public int Score;
    public int Damage;
    [SerializeField] TMP_Text HealthUIText;
    public int Health;
    public int Damage2;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0 ; // Initialize score as 0
        Damage = 100;
        Health = 100;
        Damage2 = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
        ScoreUIText.text = Score.ToString(); // Update both strings to show score and time
        HealthUIText.text = Health.ToString();

    }
}