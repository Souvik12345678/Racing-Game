using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject Car;
    public TMP_Text scoreText;

    float score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountCarDistance();  
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
