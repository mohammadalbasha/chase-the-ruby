using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireslefttBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject gml;
    // Update is called once per frame
    //public  void firebehaviour ()


    bool b = false;

    public void Start()
    {

        if (transform.parent!=null)
        transform.position = new Vector3(transform.parent.position.x-1f, transform.parent.position.y , transform.parent.position.z);
        b = true;
    }




    public void Update()
    {
        transform.Translate(Vector3.up * 10 * Time.deltaTime);
        if (transform.position.y >= 11f)

        {
            Destroy(this.gameObject);
            if (transform.parent != null&&b)
              Destroy(transform.parent.gameObject);
        }
        }

    


}
