using UnityEngine;

public class CarBlockScript : MonoBehaviour
{
    public float yOffset;
    public Transform carTransform;

    float prevYPosition;
    // Start is called before the first frame update
    void Start()
    {
        prevYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        var a = carTransform.position.y + yOffset;

        if (a > prevYPosition)
        {
            transform.position = new Vector2(0, a);
            prevYPosition = a;
        }
    }
}
