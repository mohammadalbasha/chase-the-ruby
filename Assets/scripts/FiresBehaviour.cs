using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FiresBehaviour : MonoBehaviour
{[SerializeField]
    GameObject gm;
    // Update is called once per frame
    //public  void firebehaviour ()
    bool b = false;
    UImanager _uimanager;
    public void Start()
    {if (transform.parent != null)
        transform.position = new Vector3 (transform.parent.position.x,transform.parent.position.y+0.8f,transform.parent.position.z);
        b = true;

        _uimanager = GameObject.Find("Canvas").GetComponent<UImanager>();

    }

    public void Update()
    {
        transform.Translate(Vector3.up * 10 * Time.deltaTime);
        if (transform.position.y >= 11f)

        {
            Destroy(this.gameObject);

            if (b&&transform.parent != null)
                Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {if (other.tag == "enemie")
        {
            Animator aaa = other.GetComponent<Animator>();
            aaa.enabled = true;
            _uimanager.scooore++;
            _uimanager.UpdateScore();

            Destroy(this.gameObject);

        }
    }






}
