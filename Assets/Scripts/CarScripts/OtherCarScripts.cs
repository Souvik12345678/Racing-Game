using UnityEngine;

public class OtherCarScripts : MonoBehaviour
{
    public float minVelocity;
    public float forceMultipler;
    Rigidbody2D rBody;
    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rBody.velocity.magnitude < minVelocity)
        {
            rBody.AddForce(transform.up * forceMultipler);
        
        }
    }
}
