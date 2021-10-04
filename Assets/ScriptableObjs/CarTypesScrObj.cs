using UnityEngine;

[CreateAssetMenu(menuName = "Car Types")]
public class CarTypesScrObj : ScriptableObject
{
    public GameObject truck;
    public GameObject small_truck;
    public GameObject pickup_2;
    public GameObject pickup;

    GameObject[] vehicles = new GameObject[4];

    private void OnEnable()
    {
        vehicles[0] = truck;
        vehicles[1] = small_truck;
        vehicles[2] = pickup_2;
        vehicles[3] = pickup;
    }

    public GameObject GetCarAtIndex(uint index)
    {
        return vehicles[index];
    }
}
