using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroypowershild : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
         if (FindObjectOfType<UImanager>().img.enabled == true)
            Destroy(this.gameObject);
    }
}
