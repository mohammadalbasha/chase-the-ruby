using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class enmieexplosion : MonoBehaviour
{
    [SerializeField] Animator aaa;


    [SerializeField]
    GameObject playerexppref;

    [SerializeField]
    AudioClip adc;
    








    private void Update()
    {
        transform.Translate(Vector3.down * 3 * Time.deltaTime);
        if (transform.position.y < -6.5f)
            transform.position = new Vector3(Random.Range(-12f, 16f), Random.Range(-3f, 7f), transform.position.z);

        if (aaa.enabled == true)
        {

            AudioSource.PlayClipAtPoint(adc, Camera.main.transform.position);

            // StartCoroutine(destroygameobject());
            Instantiate(playerexppref, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

  IEnumerator destroygameobject()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
            


    }

    
    //public Animator aaa;
    // Start is called before the first frame update
    /* void OnCollisionEnter(Collision collision)
     {
         if (collision.collider.tag == "fireee")

         { aaa.enabled = true; }



     }




  



     */
    /*   public void OnTriggerEnter(Collider other)
       {

           if (other.tag == "fireee")
               aaa.enabled=true;
       }
       */
}
