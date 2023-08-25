using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectSelect : MonoBehaviour
{
    public UIManager uimanager;

    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;
    public GameObject particle4;

    public Sprite BrownImage;
    public Sprite GreenImage;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;

    int _effect1Price = 5000;
    int _effect2Price = 10000;
    int _effect3Price = 15000;


    public void Awake()
    {
        if (!PlayerPrefs.HasKey("itemselect"))
        {
            PlayerPrefs.SetInt("itemselect", 1);
        }
        //-------------------item Select-------------------------

        if (PlayerPrefs.GetInt("itemselect") == 1)
        {
            particle1.SetActive(true);
            particle2.SetActive(false);
            particle3.SetActive(false);
            particle4.SetActive(false);

            Item1.GetComponent<Image>().sprite = GreenImage;
            Item2.GetComponent<Image>().sprite = BrownImage;
            Item3.GetComponent<Image>().sprite = BrownImage;
            Item4.GetComponent<Image>().sprite = BrownImage;
        }
        else if (PlayerPrefs.GetInt("itemselect") == 2)
        {
            particle1.SetActive(false);
            particle2.SetActive(true);
            particle3.SetActive(false);
            particle4.SetActive(false);

            Item1.GetComponent<Image>().sprite = BrownImage;
            Item2.GetComponent<Image>().sprite = GreenImage;
            Item3.GetComponent<Image>().sprite = BrownImage;
            Item4.GetComponent<Image>().sprite = BrownImage;
        }
        else if (PlayerPrefs.GetInt("itemselect") == 3)
        {
            particle1.SetActive(false);
            particle2.SetActive(false);
            particle3.SetActive(true);
            particle4.SetActive(false);

            Item1.GetComponent<Image>().sprite = BrownImage;
            Item2.GetComponent<Image>().sprite = BrownImage;
            Item3.GetComponent<Image>().sprite = GreenImage;
            Item4.GetComponent<Image>().sprite = BrownImage;
        }
        else if (PlayerPrefs.GetInt("itemselect") == 4)
        {
            particle1.SetActive(false);
            particle2.SetActive(false);
            particle3.SetActive(false);
            particle4.SetActive(true);

            Item1.GetComponent<Image>().sprite = BrownImage;
            Item2.GetComponent<Image>().sprite = BrownImage;
            Item3.GetComponent<Image>().sprite = BrownImage;
            Item4.GetComponent<Image>().sprite = GreenImage;
        }
    }
    public void Start()
    {
        Debug.Log("itemselect " + PlayerPrefs.GetInt("itemselect"));

    }

    public void ItemOpen1()
    {
        particle1.SetActive(true);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(false);

        Item1.GetComponent<Image>().sprite = GreenImage;
        Item2.GetComponent<Image>().sprite = BrownImage;
        Item3.GetComponent<Image>().sprite = BrownImage;
        Item4.GetComponent<Image>().sprite = BrownImage;

        PlayerPrefs.SetInt("itemselect", 1); //itemselect 0 atamasý yapýyoruz.
    }
    public void ItemOpen2()
    {
        int money = PlayerPrefs.GetInt("Moneyy");
        if (money >= _effect1Price)
        {
            PlayerPrefs.SetInt("Moneyy", money - _effect1Price);
            uimanager.CoinTextUpdate();


            particle1.SetActive(false);
            particle2.SetActive(true);
            particle3.SetActive(false);
            particle4.SetActive(false);

            Item1.GetComponent<Image>().sprite = BrownImage;
            Item2.GetComponent<Image>().sprite = GreenImage;
            Item3.GetComponent<Image>().sprite = BrownImage;
            Item4.GetComponent<Image>().sprite = BrownImage;

            PlayerPrefs.SetInt("itemselect", 2);
        }
        else
        {
            Debug.Log("Not Enought Coins");
        }
    }
    public void ItemOpen3()
    {
        int money = PlayerPrefs.GetInt("Moneyy");
        if (money >= _effect2Price)
        {
            PlayerPrefs.SetInt("Moneyy", money - _effect2Price);
            uimanager.CoinTextUpdate();

            particle1.SetActive(false);
            particle2.SetActive(false);
            particle3.SetActive(true);
            particle4.SetActive(false);

            Item1.GetComponent<Image>().sprite = BrownImage;
            Item2.GetComponent<Image>().sprite = BrownImage;
            Item3.GetComponent<Image>().sprite = GreenImage;
            Item4.GetComponent<Image>().sprite = BrownImage;

            PlayerPrefs.SetInt("itemselect", 3);
        }
        else
        {
            Debug.Log("Not Enought Coins");
        }
    }
    public void ItemOpen4()
    {
        int money = PlayerPrefs.GetInt("Moneyy");
        if (money >= _effect3Price)
        {
            PlayerPrefs.SetInt("Moneyy", money - _effect3Price);
            uimanager.CoinTextUpdate();

            particle1.SetActive(false);
            particle2.SetActive(false);
            particle3.SetActive(false);
            particle4.SetActive(true);

            Item1.GetComponent<Image>().sprite = BrownImage;
            Item2.GetComponent<Image>().sprite = BrownImage;
            Item3.GetComponent<Image>().sprite = BrownImage;
            Item4.GetComponent<Image>().sprite = GreenImage;

            PlayerPrefs.SetInt("itemselect", 4);
        }
        else
        {
            Debug.Log("Not Enought Coins");
        }
    }

}
