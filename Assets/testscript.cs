using UnityEngine;

public class testscript : MonoBehaviour
{

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Transform Direction : " + transform.TransformDirection(new Vector2(2, 0)));
            Debug.Log("Transform Point : " + transform.TransformPoint(new Vector2(2, 0)));
            Debug.Log("Transform Vector : " + transform.TransformVector(new Vector2(2, 0)));
        }
    }
}
