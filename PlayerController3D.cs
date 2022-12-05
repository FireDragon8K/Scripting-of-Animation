using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;
    public float jumpForce;

    public int curHp;
    public int maxHp;

    [Header("Mouse Look")]
    public float lookSensitivity;
    public float maxLookX;
    public float miniLookX;
    private float rotX;

    private Camera camera;
    private Rigidbody rb;

    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
        /* Instantiate the UI
        Game.UIinstance.UpdateHealthBar(curHp, maxHp);
        Game.UIinstance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo); */
    }
    // Applies Damage to the Player

    public void TakeDamage(int damage)
    {
        curHp -= damage;

        if (curHp <= 0)
            Die();
        Game.instance.UpdateHealthBar(curHp, maxHp);       
    }
    // If players health is reduced zero or below then run Die()
    void Die()
    {
        //GameManager.instance.LoseGame();
        Debug.Log("Game Over");
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed; // Getting input for left and right movement
        float z = Input.GetAxis("Vertical") * moveSpeed; // Getting input for forward and back movement

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rb.velocity.y;
        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity; // Look Up and Down
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity; // Look Left and Right
        
        rotX = Mathf.Clamp(rotX, miniLookX, maxLookX);
        // Drives Camera Rotation
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void GiveHealth(int amountToGive)
    {
        //curHp = Mathf.Clamp(curHp + amountToGive, 0, maxHp);
        //GameUI.instance.UpdateHealthBar(curHp, maxHp);
        Debug.Log("Player restored health");
    }

    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        //GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

    //Update is called once per frame
    void Update()
    {
        Move();
        CamLook();

        /* Fire Button
        if (Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
            weapon.Shoot();
        }*/
        // Jump Button
        if(Input.GetButtonDown("Jump"))
            Jump();
        
        // Don't do anything if the game is paused
        /*if(GameManager.instance.gamePaused == true)
            return;*/
    }
}
