using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreUIText;
    public int Score;
    [SerializeField] TMP_Text SlimesUIText;
    [SerializeField] TMP_Text LivesUIText;
    public int Health;
    public int Ehealth;
    public int Lives;
    public Image Healthbar;
    public int Slimes;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0 ; // Initialize score as 0
        Health = 100;
        Ehealth = 10;
        Lives = 3;
        Slimes = 0;
      
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
        ScoreUIText.text = Score.ToString();
        LivesUIText.text = Lives.ToString(); 
        SlimesUIText.text = Slimes.ToString();

    }
    public void UpdateHealthBar()
    {
        Healthbar.fillAmount = (float)Health / 100f;
    }
    
}