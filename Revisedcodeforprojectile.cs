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
