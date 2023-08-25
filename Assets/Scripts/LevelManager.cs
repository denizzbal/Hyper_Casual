using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Text PercentText;
    [SerializeField] Image BarFill; // Loading Image
    [SerializeField] GameObject LoadingPanel; 
    [SerializeField] List<Button> LevelButtonList = new();
    int _firstSceneIndexNumber = 2; // ilk oyun seviyesinin index numarasý

    int _levelIn;

    private void Awake()
    {
        LoadingPanel.SetActive(false);
    }

    public void Start()
    {
        //int _levelIn = PlayerPrefs.GetInt("LastLevel", _firstSceneIndexNumber);

        if (!PlayerPrefs.HasKey("LastLevel"))
        {
            PlayerPrefs.SetInt("LastLevel", _firstSceneIndexNumber);
            _levelIn = PlayerPrefs.GetInt("LastLevel");
        }
        else
        {
            _levelIn = PlayerPrefs.GetInt("LastLevel");
        }

        for (int i = 0; i < LevelButtonList.Count; i++)
        {
            if(i + _firstSceneIndexNumber > _levelIn)
            {
                LevelButtonList[i].interactable = false;
                LevelButtonList[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        Debug.Log(PlayerPrefs.GetInt("LastLevel"));
    }

    public void LevelControl(int _levelIndex) //Butonlara verilecek fonksiyon ve butonlardan hangi sahneyi temsil ediyorsa o sahnenin index numarasýný alacaðýz.
    {
        StartCoroutine(LoadingBar(_levelIndex));
    }
    public IEnumerator LoadingBar(int _levelInt)
    {
        LoadingPanel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(_levelInt);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            BarFill.fillAmount = progressValue;
            PercentText.text = Mathf.RoundToInt(progressValue * 100) + "%";
            yield return null;
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Main");
    }
}
