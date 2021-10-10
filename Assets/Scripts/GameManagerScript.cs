using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject Car;
    public TMP_Text scoreText;
    public GameObject gameOverText;
    public UILivesBarScript livesBar;
    public TMP_Text timerText;
    public CountdownScript countdownTimerObjScr;

    float score;

    bool isTimerPaused;
    float gameOverTimer;
    bool timerRanOut;

    private void OnEnable()
    {
        AllEventsScript.OnCarLifeDecrease += OnCarLifeDecrease;
        AllEventsScript.OnCarDestroyed += OnCarDestroyed;
        AllEventsScript.OnCountdownOver += OnStartCountdownOver;
    }

    private void OnDisable()
    {
        AllEventsScript.OnCarLifeDecrease -= OnCarLifeDecrease;
        AllEventsScript.OnCarDestroyed -= OnCarDestroyed;
        AllEventsScript.OnCountdownOver -= OnStartCountdownOver;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverTimer = 180;//In seconds;
        timerRanOut = false;
        isTimerPaused = true;
        Car.GetComponent<NewCarScript>().PauseCar();

        countdownTimerObjScr.StartTimer();//Start count down timer

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        CountCarDistance();  
    }

    public void GotoHomeScene()
    {
        SceneManager.LoadSceneAsync(0);
    }

    void CountCarDistance()
    {
        float dot = Vector2.Dot(Car.transform.up, Vector2.up);
        //If car facing up count distance traveled
        if (dot > 0.9f)
        {
            score += Car.GetComponent<Rigidbody2D>().velocity.magnitude * Time.deltaTime * 0.1f;

            scoreText.text = " Score : " + ((int)score).ToString("0000");
        }
    }

    void UpdateTimer()
    {
        //Count timer
        if (gameOverTimer > 0 && !isTimerPaused)
        {
            gameOverTimer -= Time.deltaTime;
        }
        //If timer less than 0 make it 0 
        if (gameOverTimer < 0) { gameOverTimer = 0; }

        timerText.text = "Time:\n" + TimeToString((uint)gameOverTimer);

        if (gameOverTimer == 0 && !timerRanOut) { OnTimerRanOut(); timerRanOut = true; }

    }

    //Events

    void OnGameStart()
    {
        isTimerPaused = false;
    }

    //Car life decrease event listener
    void OnCarLifeDecrease(uint currLives)
    {
        livesBar.SetLives(currLives);
    }

    void OnCarDestroyed()
    {
        isTimerPaused = true;
        Invoke(nameof(OnGameOver), 2.0f);
    }

    void OnGameOver()
    {
        gameOverText.SetActive(true);
        Invoke(nameof(GotoHomeScene), 15.0f);
    }
    
    void OnTimerRanOut()
    {
        Car.GetComponent<NewCarScript>().PauseCar();
        Invoke(nameof(OnGameOver), 2.0f);
    }

    void OnStartCountdownOver()
    {
        isTimerPaused = false;
        Car.GetComponent<NewCarScript>().ResumeCar();
    }

    //Utility

    /*Converts seconds(int) to hour:minutes:seconds*/
    string TimeToString(uint timeInSeconds)
    {
        string output="";

        int hours = (int)(timeInSeconds / 3600);
        if (hours!=0)
        {
            output += hours.ToString() + "h:";
        }

        int minutes = (int)(timeInSeconds - (3600 * hours)) / 60;
        if (minutes!=0)
        {
            output += minutes.ToString() + "m:";
        }

        timeInSeconds = (uint)(timeInSeconds - (3600 * hours) - (minutes * 60));
        output += timeInSeconds.ToString() + "s";

        return output;

    }

}
