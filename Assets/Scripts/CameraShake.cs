using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private bool shakecontrol = false;
    [SerializeField] GameObject PlayerBall;
    Vector3 _mesafe;


    private void Start()
    {
        _mesafe = transform.position - PlayerBall.transform.position;
    }

    private void LateUpdate()
    {
        float xClamp = Mathf.Clamp(transform.position.x, 0, 0);
        float yClamp = Mathf.Clamp(0, transform.position.y, 0);
        Vector3 targetPos = PlayerBall.transform.position + _mesafe;
        targetPos.x = xClamp;
        targetPos.y = yClamp;
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);
    }

    public IEnumerator CameraShakes(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;  //geçen zaman

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime; //geçen zamaný deltatime ile çarpýyoruz.
            yield return null;
        }

        transform.localPosition = originalPos;
       
    }


    public void CameraShakesCall()
    {
        if(shakecontrol == false)
        {
            StartCoroutine(CameraShakes(0.22f, 0.4f));
            shakecontrol = true;
        }
       
    }
    
}
