using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shild : MonoBehaviour
{  public Transform player;

    // Start is called before the first frame update
    void Start()
    {
      //  transform.position = player.transform.position;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.position;
    }
}
