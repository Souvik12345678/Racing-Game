using UnityEngine;

public class NewOtherCarScript : MonoBehaviour
{

    public float desiredVelocity;

    public bool isDriving;

    Rigidbody2D rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();

        isDriving = true;
    }



    void FixedUpdate()
    {
        if (isDriving)
        {
            if (rBody.velocity.magnitude != desiredVelocity)
                rBody.velocity = transform.up * desiredVelocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Stop driving after 0.8s 
        Invoke(nameof(StopDriving), 0.2f);
    }

    void StopDriving()
    {
        isDriving = false;
    }

}
