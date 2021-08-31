using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class playercontroller : MonoBehaviour
{
    

    [SerializeField] Animation aanm;
    public GameObject ggg;

    private AudioSource ads;
    public int player_lives = 3;
    // Start is called before the first frame update
    public Rigidbody rb;
    public GameObject go;
   public Animator anm;
    [SerializeField]
      GameObject fireprefab;
    [SerializeField]
    GameObject firerightprefab;

    [SerializeField]
    GameObject tripleshotprefap;

    GameObject fireleftprefab;
    public int canspawnthreefires ;
    public float speed=10f;
    public bool canincreasespeed = false;
    // Update is called once per frame

    public float timetofire = 0f;
    public float timetofire1 = 0f;


    public AudioClip adcliplazer;
    public AudioClip adclipedge;

    [SerializeField]
    UImanager _uimanager;


    
    public void Start()
    {
        anm= this.GetComponent<Animator>();

        // no need for find object
        ads = GetComponent<AudioSource>();
        ads.clip = adcliplazer;
        FindObjectOfType<spawnmanager>().start_spawn_powerups();
        //_uimanager.Updatelives();
        // another way 
        _uimanager = GameObject.Find("Canvas").GetComponent<UImanager>();
        _uimanager.Updatelives(player_lives);
       
    
    
    }










    IEnumerator settheoincrasespeedok()
    {
        // canincreasespeed = true;
        speed = 30f;
        yield return new WaitForSeconds(3f);
        //canincreasespeed = false;
        speed = 10f;
    }

    public void starttheincrasingspeed()
    {
        

      StartCoroutine(settheoincrasespeedok());
    }



    public void startsetthethreefiresok()
    {
StartCoroutine(setthethreesiresok());

    }

    IEnumerator setthethreesiresok()
    {
        canspawnthreefires = 1;
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5.0f);
 canspawnthreefires = 0; 
    }



    public GameObject player_shild;
    bool _is_shild = false;


    private void OnTriggerEnter(Collider other)
    {

     

        if (other.tag == "enemie")
        {
            //   anm.enabled = true;
            Animator aaa = other.GetComponent<Animator>();
            aaa.enabled = true;
            //Destroy(other);
           
            _uimanager.scooore++ ;
            _uimanager.UpdateScore();

            StartCoroutine(desetroyingboath());



            if (_is_shild == true)
            {

                player_shild.SetActive(false);
                //    Destroy(player_shild);

                _is_shild = false;

            }
            else
            {
                int engfai = Random.Range(0, 2);
                if (engine_failure[engfai].activeSelf == false)
                    engine_failure[engfai].SetActive(true);
                else engine_failure[1 - engfai].SetActive(true);



                
                player_lives--;
                _uimanager = GameObject.Find("Canvas").GetComponent<UImanager>();
                _uimanager.Updatelives(player_lives);

                if (player_lives < 1)
                {                Instantiate(playerexplosionprefab, transform.position, Quaternion.identity);

                    //player_lives = 3;
                    _uimanager = GameObject.Find("Canvas").GetComponent<UImanager>();
                    _uimanager.restart();
                    Destroy(this.gameObject);
                }
            }







        }



        if (other.tag=="shild")
        {
            Destroy(other.gameObject);
            _is_shild = true;
            // Instantiate(player_shild,transform.position,Quaternion.identity);
            player_shild.SetActive(true);

        }
         

    }

    [SerializeField] GameObject[] engine_failure;


    [SerializeField]
    GameObject enm;
    [SerializeField]
    GameObject playerexplosionprefab;
    IEnumerator desetroyingboath()
    {
        yield return new WaitForSeconds(1);
        
       // Destroy(this.gameObject);
        
        //  DestroyObject(enm);
      //  Destroy(enm);

    }



   


    void FixedUpdate()    { if (Input.GetKey("w"))
        {

            GetComponent<Rigidbody>().AddForce(0, 10 * Time.deltaTime, 0);

        }





      if (Input.GetKeyDown(KeyCode.Space))
        {    if (Time.time-timetofire>0.25f)
            {
                ads.clip = adcliplazer;
                ads.Play();
                Instantiate(fireprefab, transform.position, Quaternion.identity);
                //  FindObjectOfType<FiresBehaviour>().firebehaviour();
                timetofire = Time.time ;
            
            }
        }
      
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time - timetofire1 > 0.25f)
            {
                Instantiate(fireprefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                if (canspawnthreefires > 0)
                {
                    Instantiate(tripleshotprefap, transform.position , Quaternion.identity);

                    //   Instantiate(fireleftprefab, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
                    // Instantiate(firerightprefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                    // canspawnthreefires--;
                }
                //   FindObjectOfType<FiresBehaviour>().firebehaviour();
                timetofire1 = Time.time;

            }
        }





        /*
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, -100 * Time.deltaTime, 0);

        }
        */




        float kkk = Input.GetAxis("Vertical");

        if (transform.position.y >= -3.42f && transform.position.y <= 5.3f)
            transform.Translate(Vector3.up * kkk * Time.deltaTime * speed);




        else if (transform.position.y < -3.42f)
        {
            ads.clip = adclipedge;
            ads.Play();
            transform.position = new Vector3(transform.position.x, -3.42f, transform.position.z);

        }
        else if (transform.position.y > 5.31f)
        {
            ads.clip = adclipedge;
            ads.Play();
            transform.position = new Vector3(transform.position.x, 5.2f, transform.position.z);
        }



        float kk = Input.GetAxis("Horizontal");
        //loat kkk = Input.GetAxis("Vertacilly");

        //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, kkk);
        

        if (transform.position.x >= -13f&&transform.position.x<=12f)
        {
           





            transform.Translate(Vector3.right * Time.fixedDeltaTime * speed* kk); }
        else if (transform.position.x<-13f)
        {
            transform.position = new Vector3(12f, transform.position.y, transform.position.z);

        }
        else
        {
            transform.position = new Vector3(-13f, transform.position.y, transform.position.z);


        }
    }
}
