CoinPickUp script:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
           other.GetComponent<PlayerController2D>().points++;
           //Add 1 to points.
           Destroy(gameObject); // This Destroys coin 
        }
    }
}


CoinPickUp on PlayerController:

    private void OnGUI()
    {
        GUI.Label(new Rect(10,10,100,20), "Score :" + points);
    }
    
