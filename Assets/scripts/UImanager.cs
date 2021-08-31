using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;


public class UImanager : MonoBehaviour
{
    public Image lives_display;
    public Sprite []  current_lives;
    public int scooore = 0;
    public Text score_dis;
    // Start is called before the first frame update

    public void Start()
    {
        score_dis.text = "0" ;
        Updatelives(3);
    }
    public void Updatelives(int i)
    {
        lives_display.sprite = current_lives[i] ;
        
    }


    public void UpdateScore()
    {
        score_dis.text=(scooore.ToString());   
    }

    // Update is called once per frame
    [SerializeField]
    GameObject playerpref;
   public Image img;


    public void restart()
    {
        img.enabled = true;
        scooore = 0;
        UpdateScore();
        Updatelives(3);


    }

    public void Update()
    {
        if (img.enabled==true&&Input.GetKey(KeyCode.Escape))
        {
            Instantiate(playerpref, new Vector3(0, 0, 0), Quaternion.identity);
            img.enabled = false;


        }
    }

}
