using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelColour : MonoBehaviour
{
    private MaterialColor matColor;

    private void Awake() 
    {
    /*    matColor = GameObject.FindGameObjectWithTag("Mat").GetComponent<MaterialColor>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (gameObject.CompareTag("OtherObs"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Obs1.color;
            if (gameObject.CompareTag("Obstacle"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Crush1.color;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (gameObject.CompareTag("OtherObs"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Obs2.color;
            if (gameObject.CompareTag("Obstacle"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Crush2.color;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (gameObject.CompareTag("OtherObs"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Obs3.color;
            if (gameObject.CompareTag("Obstacle"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Crush3.color;
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (gameObject.CompareTag("OtherObs"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Obs4.color;
            if (gameObject.CompareTag("Obstacle"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Crush4.color;
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (gameObject.CompareTag("OtherObs"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Obs5.color;
            if (gameObject.CompareTag("Obstacle"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Crush5.color;
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            if (gameObject.CompareTag("OtherObs"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Obs6.color;
            if (gameObject.CompareTag("Obstacle"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Crush6.color;
        }
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            if (gameObject.CompareTag("OtherObs"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Obs7.color;
            if (gameObject.CompareTag("Obstacle"))
                gameObject.GetComponent<Renderer>().material.color = matColor.Crush7.color;
        }
     */
    }
}
