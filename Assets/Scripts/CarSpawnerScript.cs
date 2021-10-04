using System.Collections;
using UnityEngine;

public class CarSpawnerScript : MonoBehaviour
{
    public float carSpawnEveryNSeconds;
    public CarTypesScrObj carTypes;
    public GameObject car;

    float[] xRanges = { -1.85f, -0.75f, 0.75f, 1.85f };
    uint previousUpOrDown;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating(nameof(SpawnACar), 3, 3);
        StartCoroutine(CarSpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnACar()
    {
        //if upOrDown is same as before flip again
        int upOrDown = Random.Range(0, 2);
        while (upOrDown == (uint)previousUpOrDown)
        {
            upOrDown = Random.Range(0, 2);
        }

        previousUpOrDown = (uint)upOrDown;

        //Spawn car driving up
        if (upOrDown == 1)
        {
            var carToSpawn = carTypes.GetCarAtIndex((uint)Random.Range(0, 4));
            carToSpawn = Instantiate(carToSpawn);
            carToSpawn.transform.rotation = Quaternion.Euler(0, 0, 0);
            carToSpawn.transform.position = new Vector2(xRanges[Random.Range(2, 4)], car.transform.position.y + 20.0f);
        }
        else  //Spawn car driving down
        {
            var carToSpawn = carTypes.GetCarAtIndex((uint)Random.Range(0, 4));
            carToSpawn = Instantiate(carToSpawn);
            carToSpawn.transform.position = new Vector2(xRanges[Random.Range(0, 2)], car.transform.position.y + 20.0f);
        }
    }

    IEnumerator CarSpawnCoroutine()
    {
        for (; ; )
        {
            //Spawn a car and wait
            SpawnACar();
            yield return new WaitForSeconds(carSpawnEveryNSeconds);
        }
    
    }
}
