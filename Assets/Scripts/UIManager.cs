using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public SoundManager soundManager;
    public Image whiteEffectimage;
    private int effectcontrol = 0;

    public Animator layoutanimator;

    public Text coin_text;
    //butonlar
    public GameObject settingsOpen;
    public GameObject settingsClose;
    public GameObject layoutBackground;
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject vibrationOn;
    public GameObject vibrationOff;
    public GameObject iap;
    public GameObject information;
    public GameObject informationOpen;


    public GameObject restartScreen;

    //oyun sonu ekraný
    public GameObject Finish_screen;
    public GameObject Black_background;
    public GameObject completeText;
    public GameObject RadialShine;
    public GameObject f_Coin;

    public GameObject ToplamCoin;
    public GameObject nextLevel;
    public Text ToplamCoinText;

    private bool RadialShinebool = false;

    //level barý
    public Image FillRateImage;
    public GameObject Playerim;
    public GameObject FinishLine;






    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false) //sound adýnda bir deðiþken var mý kontrol et eðer yoksa 
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        ///////////////////////////////////////////////
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
            AudioListener.volume = 0;
        }
        ///////////////////////////////////////////////
        if (!PlayerPrefs.HasKey("Vibration"))
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }

        CoinTextUpdate();
    }

    private void Update()
    {
        if(RadialShinebool == true) //finish ekranýndaki radial shine dönüþü
        {
            RadialShine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 25 * Time.deltaTime));
        }

        //level barý
        FillRateImage.fillAmount = ((Playerim.transform.position.z * 100) / (FinishLine.transform.position.z)) / 100;
    }




    //buton fonksiyonlarý
    public void settings_open()
    {
        settingsOpen.SetActive(false);
        settingsClose.SetActive(true);
        layoutanimator.SetTrigger("Slayt_in");

        //if(PlayerPrefs.GetInt("Sound") == 1)
        //{
        //    soundOn.SetActive(true);
        //    soundOff.SetActive(false);
        //    AudioListener.volume = 1; 
        //}else if(PlayerPrefs.GetInt("Sound") == 2)
        //{
        //    soundOn.SetActive(false);
        //    soundOff.SetActive(true);
        //    AudioListener.volume = 0;
        //}


        if(PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibrationOn.SetActive(true);
            vibrationOff.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibrationOn.SetActive(false);
            vibrationOff.SetActive(true);
        }

    }
    public void settings_close()
    {
        settingsOpen.SetActive(true);
        settingsClose.SetActive(false);
        layoutanimator.SetTrigger("Slayt_out");

    }

    public void Sound_On()
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        AudioListener.volume = 0; //müziði kapatýyoruz.
        PlayerPrefs.SetInt("Sound", 2);
    }
    public void Sound_Off()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        AudioListener.volume = 1; //müziði açýyoruz.
        PlayerPrefs.SetInt("Sound", 1);
    }
    public void Vibration_On()
    {
        vibrationOn.SetActive(false);
        vibrationOff.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }
    public void Vibration_Off()
    {
        vibrationOn.SetActive(true);
        vibrationOff.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }

    public void informations()
    {
        if(informationOpen.activeSelf == false)
        {
            informationOpen.SetActive(true);
        }
        else
        {
            informationOpen.SetActive(false);
        }
    }


    public void CoinTextUpdate()
    {
        coin_text.text = PlayerPrefs.GetInt("Moneyy").ToString();
    }

    public void Restart_Button()
    {
        restartScreen.SetActive(true);
    }

    public void RestartScene()
    {
        Variable.firsttouch = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        Variable.firsttouch = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }



    //public void FinishScreen() 
    //{
    //    StartCoroutine("FinishLaunch");
    //}

    public IEnumerator FinishLaunch()//oyun sonu ekraný
    {
        Time.timeScale = 0.5f;
        RadialShinebool = true;
        Finish_screen.SetActive(true);
        Black_background.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);

        Playerim.GetComponent<Rigidbody>().velocity = Vector3.zero; //playerin hýzýný sýfýrlýyoruz.
        Playerim.GetComponent<Player>().speedballforward = true; //playerin kendi kendine gitmesini sýfýrlýyoruz.
        completeText.SetActive(true);
        soundManager.OyunSonuSound();
        yield return new WaitForSecondsRealtime(1.3f);
        RadialShine.SetActive(true);
        soundManager.OyunSonuSound();
        f_Coin.SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        ToplamCoin.SetActive(true);
        ToplamCoinText.text = PlayerPrefs.GetInt("Moneyy").ToString();
        nextLevel.SetActive(true);
        soundManager.OyunSonuSound();

    }



    public void Privacy_policy()
    {
        Application.OpenURL("https://www.google.com.tr/");
    }
    public void Term_of_use()
    {
        Application.OpenURL("https://www.google.com.tr/");
    }





    public IEnumerator WhiteEffect() // game over olduðunda aniden gelen beyaz patlama efekti
    {

        whiteEffectimage.gameObject.SetActive(true);

        while (effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.005f);
            whiteEffectimage.color += new Color(0, 0, 0, 0.1f); //colorun içinde a rengi 0.1f artacak.
            if (whiteEffectimage.color == new Color(whiteEffectimage.color.r, whiteEffectimage.color.g, whiteEffectimage.color.b, 1))
            {
                effectcontrol = 1;
            }

        }

        while(effectcontrol == 1)
        {
            yield return new WaitForSeconds(0.005f);
            whiteEffectimage.color -= new Color(0, 0, 0, 0.1f); // colorun içindeki a rengi 0.1f azalacak.
            if(whiteEffectimage.color == new Color(whiteEffectimage.color.r, whiteEffectimage.color.g, whiteEffectimage.color.b, 0))
            {
                effectcontrol = 2;
            }
        }
        if(effectcontrol == 2)
        {
            Debug.Log("White Effect bitti");
        }



    }

    public void MainButton()
    {
        SceneManager.LoadScene("Main");
    }
   
}
