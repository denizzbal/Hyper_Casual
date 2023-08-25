using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("OtherObs") || hit.gameObject.CompareTag("Obstacle"))
            hit.gameObject.SetActive(false);

    }
}
