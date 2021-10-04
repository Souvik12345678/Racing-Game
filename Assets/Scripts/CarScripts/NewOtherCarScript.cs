using UnityEngine;

public class NewOtherCarScript : MonoBehaviour
{
    public float desiredVelocity;

    Rigidbody2D rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        rBody.velocity = transform.up * desiredVelocity;
    }
}
