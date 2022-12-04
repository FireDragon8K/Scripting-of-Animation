using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{

    public int clickToPop = 3; // how many clicks until the balloon pops

    public float scaleToIncrease = 0.10f; // each time the balloon is clicked inflate 10% 
    
    
    // Start is called before the first frame update
    void Start()
    {
    
        
    }

     void OnMouseDown()
    {
        clickToPop -= 1; // Reduce clicks by one

        //Inflate the balloon a certain amount every time it is clicked on
        Transform.localScale += vector3.one * scaleToIncrease;

        if (clickToPop == 0)
        {
            Destroy(gameObject);
        }
    
    }
    //test
}

