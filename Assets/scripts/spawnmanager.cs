using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class spawnmanager : MonoBehaviour
{
    // Start is called before the first frame update


      

    [SerializeField]
    GameObject enemypref;
    [SerializeField]
    GameObject [] powerups ;
    // int a[3];
    // Update is called once per frame
    bool b = true;
    UImanager _uimanager;
    private void Start()
    {
        _uimanager = GameObject.Find("Canvas").GetComponent<UImanager>();

    }


    public void start_spawn_powerups()
    {
        StartCoroutine(spwunpowerup());


    }
    void Update()


    { 
     
    if (b)
        StartCoroutine(spawnenemy());
    }


    IEnumerator spawnenemy()
    {

        
            b = false;
        if (!_uimanager.img.enabled)
            Instantiate(enemypref, new Vector3(Random.Range(-13f, 13f), 5.59f, 0f), Quaternion.identity);
                    yield return new WaitForSeconds(5f);
            b = true;

    }

    IEnumerator spwunpowerup()
    {
        while (true)
        {







            // max is exclusive in ineger mode 
            int i = Random.Range(0, 3);

     if (!_uimanager.img.enabled)
            Instantiate(powerups[i], new Vector3(Random.Range(-13f, 13f), 5.59f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }

    }

}
