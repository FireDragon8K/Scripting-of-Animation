Player Controller code:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float hInput;

    public float speed;

    private float xRange = 11.0f;

    public GameObject LaserBeam; // GameObject projectile to shoot
    public Transform blaster; // point of origin for the laserBeam

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //set horizontal input to recieve values from the keyboard keymap horizontal
        hInput = Input.GetAxis("Horizontal"); 


        //move the player left and right
        transform.Translate(Vector3.right * hInput * speed * Time.deltaTime);

        //keep player within set bounds
        //keep player inside right wall at set xRange
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

         if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(LaserBeam, blaster.transform.position, LaserBeam.transform.rotation); // Instatiate laserBeam GameObject to blaster position
        }
    }
}


Move Foward Code:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{

    public float speed;
 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);  
    }
}

Destroy Object Code:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    public float topBounds = 30.0f;
    public float lowerBounds = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        
        else if (transform.position.z < lowerBounds)
        {
            Destroy(gameObject);
        }
        
    }
}
