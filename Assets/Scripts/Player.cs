using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public UIManager uIManager;
    public CameraShake camerashake;
    private Rigidbody rb;
    private Touch touch;
    [Range(20,40)]
    private float speedModifierX = 18.0f;

    private float klavyeYatayHareket = 1400f;

    public float forwardSpeed;
    public GameObject cam;
    public GameObject vectorBack;
    public GameObject vectorForward;

    public bool speedballforward = false;
    private bool firstTouchControl = false;

    public SoundManager soundManager;
    private int soundLimitCount;

    private void Awake()
    {
        Variable.firsttouch = 0;
    }
    public void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if(Variable.firsttouch == 1 && speedballforward == false)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);           
            vectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }

        //Klavye kontrol� i�in Start
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Variable.firsttouch = 1;
            firstTouchControl = true;
        }

        if (firstTouchControl == true)
        {
            float _yatay = Input.GetAxis("Horizontal");

            rb.velocity = new Vector3(_yatay * klavyeYatayHareket * Time.deltaTime,0, 0);
            
        }


        //Klavye kontrol� i�in End




        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);  //ilk dokunu�u baz al�yoruz.

            if (touch.phase == TouchPhase.Began) //ilk dokunu� ba�land���nda
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))//e�er dokundu�un yer canvas eleman� de�ilse
                {
                    if(firstTouchControl == false)
                    {
                        Variable.firsttouch = 1;
                        firstTouchControl = true;
                    }
                    
                }
                                   
            }
            else if (touch.phase == TouchPhase.Moved) // parma��m�z hareket ediyorsa
            {

                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))//e�er dokundu�un yer canvas eleman� de�ilse
                {
                    rb.velocity = new Vector3(touch.deltaPosition.x * speedModifierX * Time.deltaTime,0,0);
                    if (firstTouchControl == false)
                    {
                        Variable.firsttouch = 1;
                        firstTouchControl = true;
                    }

                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                //rb.velocity = new Vector3(0, 0, 0);
                rb.velocity = Vector3.zero;
            }

        }

    }
    public GameObject[] FractureItems; //playerin i�inde child objeleri i�in dizi olu�uturuyoruz.
    public void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Obstacle")
        {
            camerashake.CameraShakesCall();
            uIManager.StartCoroutine("WhiteEffect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false); //player Obstacle tagl� objeye �arpt��� zaman kaybolacak.
            soundManager.PlayerPatlamaSound();
            if(PlayerPrefs.GetInt("Vibration") == 1)
            {
                Vibration.Vibrate(50);
            }else if (PlayerPrefs.GetInt("Vibration") == 2)
            {
                Debug.Log("No Vibration");
            }
            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true; 
                item.GetComponent<Rigidbody>().isKinematic = false;   
            }
            //StartCoroutine("TimeScaleControl");
            StartCoroutine(TimeScaleControl());
        }
        if (hit.gameObject.CompareTag("OtherObs"))
        {
            soundManager.ObjectHitSound();
            soundLimitCount++;
        }
        if (hit.gameObject.CompareTag("OtherObs") && soundLimitCount % 5 == 0)
        {
            soundManager.ObjectHitSound();
        }
    }

    public IEnumerator TimeScaleControl()
    {
        speedballforward = true;
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.6f);
        uIManager.Restart_Button();
        rb.velocity = Vector3.zero; //playerin rigidbodysini s�f�rl�yoruz.
    }

}
