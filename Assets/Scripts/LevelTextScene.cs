using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTextScene : MonoBehaviour
{
    public Text solText;
    public Text sagText;

    private void Start()
    {
        SahneNoGoster();
    }


    public void SahneNoGoster()
    {
        int _solTextInt = SceneManager.GetActiveScene().buildIndex - 1;
        int _sagTextInt = (SceneManager.GetActiveScene().buildIndex +1) - 1;
        solText.text = _solTextInt.ToString();
        sagText.text = _sagTextInt.ToString();
    }
}
