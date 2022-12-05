main menu script:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int sceneToLoad;


    
    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad); // Indexed scene to load 
        Debug.Log("New Scene Loaded!");
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit Game
        Debug.Log("You have quit the game, goodbye!");
    }
}

Enemy shoot code:


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject laserBolt;

    public Transform alienBlaster;

    public float startDelay = 3f;
    public float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AlienShoot", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AlienShoot()
    {
        Instantiate(laserBolt, alienBlaster.transform.position, laserBolt.transform.rotation);
    }
}
