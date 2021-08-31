using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationcontrollerswitchanimations : MonoBehaviour
{
    Animator anm;

    // Start is called before the first frame update
    void Start()
    {
        anm = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float kk = Input.GetAxis("Horizontal");
        //loat kkk = Input.GetAxis("Vertacilly");

        //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, kkk);


         if (kk < 0)
            {
                anm.SetBool("turnright", false);

                anm.SetBool("turnleft", true);
            }
            else if (kk > 0)
            {
                anm.SetBool("turnright", true);
                anm.SetBool("turnleft", false);

            }
            else
            {
                anm.SetBool("turnleft", false);

                anm.SetBool("turnright", false);
            }




        
    }
}

