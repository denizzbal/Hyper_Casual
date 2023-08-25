using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource buttonClick;
    public AudioSource button2Click;
    public AudioSource playerPatlama;
    public AudioSource SatinAlma;
    public AudioSource OyunSonu;
    public AudioSource ObjectHit;

    public AudioClip buttonClip;
    public AudioClip button2Clip;
    public AudioClip playerPatlamaClip;
    public AudioClip SatinAlmaClip;
    public AudioClip OyunSonuClip;
    public AudioClip ObjectHitClip;

    public void ButtonSound()
    {
        buttonClick.PlayOneShot(buttonClip);
    }
    public void Button2Sound()
    {
        button2Click.PlayOneShot(button2Clip);
    }
    public void PlayerPatlamaSound()
    {
        playerPatlama.PlayOneShot(playerPatlamaClip);
    }
    public void SatinAlmaSound()
    {
        SatinAlma.PlayOneShot(SatinAlmaClip);
    }
    public void OyunSonuSound()
    {
        OyunSonu.PlayOneShot(OyunSonuClip);
    }
    public void ObjectHitSound()
    {
        ObjectHit.PlayOneShot(ObjectHitClip);
    }
}
