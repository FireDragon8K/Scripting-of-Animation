Balloon Code:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{

    public int clickToPop = 3; // how many clicks until the balloon pops

    public float scaleToIncrease = 0.10f; // each time the balloon is clicked inflate 10% 
    public int scoreToGive = 100;
    private ScoreManager scoreManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Reference ScoreManager Component
        scoreManager = GameObject.Find("ScoreManger").GetComponent<ScoreManager>();
        
    }

     void OnMouseDown()
    {
        clickToPop -= 1; // Reduce clicks by one

        //Inflate the balloon a certain amount every time it is clicked on
        transform.localScale += Vector3.one * scaleToIncrease;

        if (clickToPop == 0)
        {
            // Send points to score manager and update the score
            scoreManager.IncreaseScoreText(scoreToGive);
            // Destroy this balloon
            Destroy(gameObject);
        }
    
    }
}


Float Code and Top Boundary Code:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUp : MonoBehaviour
{

    public float moveSpeed; // speed at which the balloon will move upwards
    public float upperBound; // Top boundary for when the balloon exits the screen it will get destroyed

    private Balloon balloon; // Reference the balloon gameobject

    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
      balloon = GetComponent<Balloon>(); 
      scoreManager = GameObject.Find("ScoreManger").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the balloon upwards
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Destroy balloon if it passes the top boundary
        if(transform.position.y > upperBound)
        {
            scoreManager.DecreaseScoreText(balloon.scoreToGive);
            Destroy(gameObject);
        }
    }
}


Spawn Manager Code:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] balloonPrefabs;
    public float startDelay = 0.5f;
    public float spawnInterval = 1.5f;

    
    public float xRange = 5;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBalloon", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }






    void SpawnRandomBalloon()
    {
        // Get a random position on the x-axis
        Vector3 spawnPosX = new Vector3(Random.Range(-xRange,xRange),0,0);

        // Pick a random balloon from the balloon array
        int balloonIndex = Random.Range(0,balloonPrefabs.Length);

        // Spawn a random balloon at spawn point
        Instantiate(balloonPrefabs[balloonIndex], spawnPosX, balloonPrefabs[balloonIndex].transform.rotation);
    }
}


Score Manger code:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{   

    public int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

   public void IncreaseScoreText(int amount)
  {
    score += amount; // Increase score by a certain amount (Math)


    UpdateScoreText();

  }

     public void DecreaseScoreText(int amount)
  {
    score -= amount; // Decrease score by a certain amount (Math)


    UpdateScoreText();

  }

   public void UpdateScoreText()
   {
     scoreText.text = "Score: "+ score;
   }
}

