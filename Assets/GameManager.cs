using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreUIText;
    public int Score;
  
    [SerializeField] TMP_Text LivesUIText;
    public int Health;
    public int Ehealth;
    public int Lives;
    public Image Healthbar;

    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        
        Score = 0 ; // Initialize score as 0
        Health = 100;
        Ehealth = 10;
        Lives = 3;

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
        ScoreUIText.text = Score.ToString();
        LivesUIText.text = Lives.ToString(); 
  

    }
    public void UpdateHealthBar()
    {
        Healthbar.fillAmount = (float)Health / 100f;
    }

    public void GetSceneChange()
    {
     if (currentSceneIndex == 0)  // Assuming scene 1 has build index 0
        {
            SceneManager.LoadScene("Scene2");
        }
        else if (currentSceneIndex == 1)  // Assuming scene 2 has build index 1
        {
            SceneManager.LoadScene("Scene3"); // Load scene 3
        }
        {
            SceneManager.LoadScene("Scene4");
        }

    }


}