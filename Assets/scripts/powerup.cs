using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup: MonoBehaviour
{
    [SerializeField]
    int ID;

    [SerializeField]
    AudioClip adc;

    public void Update()
    {
        if (FindObjectOfType<UImanager>().img.enabled == true)
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(adc, Camera.main.transform.position);

            if (ID == 0)
            {
                playercontroller bbb = other.GetComponent<playercontroller>();
                bbb.startsetthethreefiresok()
                    ;
                Destroy(this.gameObject);

            }

            else if (ID == 1)
            {
                FindObjectOfType<playercontroller>().starttheincrasingspeed();
                Destroy(this.gameObject);


            }




        }

    }

}
