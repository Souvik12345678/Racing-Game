using UnityEngine;

public class CarControlScript : MonoBehaviour
{

    [SerializeField]
    float accelerationPower = 5f;
    [SerializeField]
    float steeringPower = 5f;
    float steeringAmount, speed, direction;

    public float roadScrollMultiplier;
    public RoadScrollScript rdScrollScript;

    //Internal vars
    private int isGoFwd;
    enum Steer { NONE,LEFT,RIGHT };
    Steer steering;
    float currRotation;
    Vector2 moveDirection;
    private Rigidbody2D rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();

        steering = Steer.NONE;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        //Control car
        AccInput();
        SteerInput();

        steeringAmount = -Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical") * accelerationPower;

        //Scroll road
        if (rdScrollScript != null)
        {
            rdScrollScript.ySpeed = rBody.velocity.y * roadScrollMultiplier;
        }
    }

    private void FixedUpdate()
    {
       
        direction = Mathf.Sign(Vector2.Dot(rBody.velocity, rBody.GetRelativeVector(Vector2.up)));
        rBody.MoveRotation(rBody.rotation + steeringAmount * steeringPower * rBody.velocity.magnitude * direction);

        rBody.AddRelativeForce(Vector2.up * speed * 2);

        rBody.AddRelativeForce(rBody.velocity.magnitude * steeringAmount * -Vector2.right / 2);

    }

    //Input
    private void AccInput()
    {
        if (Input.GetKey(KeyCode.W)) { isGoFwd = 1; }
        else if (Input.GetKey(KeyCode.S)) { isGoFwd = -1; }
        else { isGoFwd = 0; }
    }

    private void SteerInput()
    {
        if (Input.GetKey(KeyCode.D)) { steering = Steer.RIGHT; }
        else if (Input.GetKey(KeyCode.A)) { steering = Steer.LEFT; }
        else { steering = Steer.NONE; }
    }

}
