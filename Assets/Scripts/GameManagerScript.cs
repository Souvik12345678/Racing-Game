using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject Car;
    public TMP_Text scoreText;
    public GameObject gameOverText;
    public UILivesBarScript livesBar;

    float score;

    private void OnEnable()
    {
        AllEventsScript.OnCarLifeDecrease += OnCarLifeDecrease;
        AllEventsScript.OnCarDestroyed += OnCarDestroyed;
    }

    private void OnDisable()
    {
        AllEventsScript.OnCarLifeDecrease -= OnCarLifeDecrease;
        AllEventsScript.OnCarDestroyed -= OnCarDestroyed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountCarDistance();  
    }

    //Events

    //Car life decrease event listener
    void OnCarLifeDecrease(uint currLives)
    {
        livesBar.SetLives(currLives);
    }

    void OnCarDestroyed()
    {
        Invoke(nameof(OnGameOver), 2.0f);
    }

    void OnGameOver()
    {
        gameOverText.SetActive(true);
    }


    void CountCarDistance()
    {
        float dot = Vector2.Dot(Car.transform.up, Vector2.up);
        //If car facing up count distance traveled
        if (dot > 0.9f)
        {
            score += Car.GetComponent<Rigidbody2D>().velocity.magnitude * Time.deltaTime * 0.1f;

            scoreText.text = "Score : " + ((int)score).ToString("0000");
        }

    
    }
}
