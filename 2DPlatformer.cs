Enemy Patrol Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed; // How fast the enemy moves
    public float rayDistance; // How far the ray attends
    private bool isMovingRight = true; // Is the enemy moving right
    public Transform groundDetection;// Is the enemy touching the ground


    // Update is called once per frame
    void Update()
    {
        // Move the enemy to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance);

        if(groundInfo.collider == false)
        {
            if(isMovingRight == true)
            {
                // Flip Enemy at edge to move left
                transform.eulerAngles = new Vector3(0, -180, 0);
                isMovingRight =  false;
            }
            else
            {
                // Flip Enemy at edge to move right
                transform.eulerAngles = new Vector3(0,0,0);
                isMovingRight = true;
            }
        }
    }
}


Platform Script:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDropDown : MonoBehaviour
{
    private PlatformEffector2D effector2D;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.5f;
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (waitTime <=0)
            {
                effector2D.rotationalOffset = 180f;
                waitTime = 0.5f;
            }

            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            effector2D.rotationalOffset = 0;
        }
    }
}


Projectile Weapon Script:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire1"))
       {
            Shoot();
       } 
    }
    
    void Shoot()
    {
        Instantiate(projectile,firePoint.position,firePoint.rotation);
    }
}


Revised projectile code to shoot left and right:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;
    public float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        firePoint.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        
        if(!Mathf.Approximately (0,movement))
        {
            firePoint.rotation = movement > 0 ? Quaternion.Euler (0, 180, 0) : Quaternion.identity;
        }
       if(Input.GetButtonDown("Fire1"))
       {
            Shoot();
       } 
    }
    
    void Shoot()
    {
        Instantiate(projectile,firePoint.position,firePoint.rotation);
    }
}
