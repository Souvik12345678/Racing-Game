using UnityEngine;

public class OtherCarScripts : MonoBehaviour
{
    public float maxForce;
    public float forceMultipler;
    public float desiredVelocity;
    public float maxVelocity;
    Rigidbody2D rBody;

    float timer = 0.0f;
    float resetTime = 0.1f;


    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        Debug.Log(rBody.velocity.magnitude);
    }

    void FixedUpdate()
    {
        if (rBody.velocity.magnitude < desiredVelocity)
        {
            float diff = desiredVelocity - rBody.velocity.magnitude;
            float forceToApply = Map(diff, 0, maxVelocity, 0, maxForce);
            //If car has to accelerate
            rBody.AddForce(transform.up * forceToApply, ForceMode2D.Impulse);
        }
        else if (rBody.velocity.magnitude > desiredVelocity)
        {
            //Do not apply force

        }
    }

    public float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}
