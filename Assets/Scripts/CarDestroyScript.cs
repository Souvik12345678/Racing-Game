using UnityEngine;

public class CarDestroyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
    }

}
