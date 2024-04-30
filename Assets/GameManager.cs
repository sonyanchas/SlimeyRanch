using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreUIText;
    public int Score;
    //public int Damage;
    [SerializeField] TMP_Text HealthUIText;
    [SerializeField] TMP_Text LivesUIText;
    public int Health;
    public int Ehealth;
    public int Lives;
    public Image Healthbar;
    public int Slimes;
    public string[] inventory;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0 ; // Initialize score as 0
        //Damage = 100;
        Health = 100;
        Ehealth = 10;
        Lives = 3;
        Slimes = 0;
        inventory = new string[5];
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
        ScoreUIText.text = Score.ToString(); // Update both strings to show score
        LivesUIText.text = Lives.ToString(); // Update both strings to show score
        //HealthUIText.text = Health.ToString();

    }
    public void UpdateHealthBar()
    {
        Healthbar.fillAmount = (float)Health / 100f;
    }
    public void AddToInventory(string item)
    {
        // Check if there's space in the inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                // If the slot is empty, add the item and break the loop
                inventory[i] = item;
                break;
            }
        }
    }
}