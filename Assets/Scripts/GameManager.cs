using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour    
{
    public UIManager uiman;

    private void Start()
    {
        CoinCalculater(0);
        Debug.Log(PlayerPrefs.GetInt("Moneyy"));
    }
    private void OnTriggerEnter(Collider other) //level bitirildi�inde gelecek kod
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinishLine"))
        {
            CoinCalculater(100);
            uiman.CoinTextUpdate();
            StartCoroutine(uiman.FinishLaunch());

            int _lastLevel = PlayerPrefs.GetInt("LastLevel");
            int _nextScene = SceneManager.GetActiveScene().buildIndex + 1 ;
            if(_lastLevel < _nextScene)
            {
                PlayerPrefs.SetInt("LastLevel", _lastLevel + 1); //oyuncunun hangi levelde kald���n� kay�t ediyoruz.
            }
            Debug.Log("LastLevelin i�indeki say� " + PlayerPrefs.GetInt("LastLevel"));
        }
    }

    public void CoinCalculater(int money)
    {
        if (PlayerPrefs.HasKey("Moneyy"))
        {
            int oldscore = PlayerPrefs.GetInt("Moneyy");
            PlayerPrefs.SetInt("Moneyy", oldscore + money);
        }
        else
        {
            PlayerPrefs.SetInt("Moneyy",0);
        }
    }
}
