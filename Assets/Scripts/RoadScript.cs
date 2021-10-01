using UnityEngine;

[ExecuteInEditMode]
public class RoadScript : MonoBehaviour
{
    public Transform toFollow;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(offset.x, toFollow.position.y + offset.y, offset.z);
    }
}
