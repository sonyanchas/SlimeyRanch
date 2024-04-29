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
    public int Lives;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0 ; // Initialize score as 0
        Damage = 100;
        Health = 100;
        Damage2 = 10;
        Lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        ScoreUIText.text = Score.ToString(); // Update both strings to show score
        //HealthUIText.text = Health.ToString();

    }
}