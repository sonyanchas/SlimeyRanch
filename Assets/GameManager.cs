using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreUIText;
    public int Score;
    public int Damage;
    [SerializeField] TMP_Text HealthUIText;
    [SerializeField] TMP_Text LivesUIText;
    public int Health;
    public int Ehealth;
    public int Lives;
    public Image Healthbar;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0 ; // Initialize score as 0
        Damage = 100;
        Health = 100;
        Ehealth = 10;
        Lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        ScoreUIText.text = Score.ToString(); // Update both strings to show score
        LivesUIText.text = Lives.ToString(); // Update both strings to show score
        //HealthUIText.text = Health.ToString();

    }
    public void takedamage(int Damage)
    {
        Health -= Damage;
        Healthbar.fillAmount = Health / 100f;
    }
}