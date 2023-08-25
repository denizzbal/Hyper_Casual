using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField] Text MoneyText;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Moneyy"))
        {
            PlayerPrefs.SetInt("Moneyy", 5000);
            MoneyText.text = PlayerPrefs.GetInt("Moneyy").ToString();
        }
        else
        {
            MoneyText.text = PlayerPrefs.GetInt("Moneyy").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Levels");
    }

    public void QuitButton()
    {
        Application.Quit();
    }




}
