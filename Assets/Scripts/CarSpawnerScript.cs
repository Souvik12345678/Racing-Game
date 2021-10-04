using System.Collections;
using UnityEngine;

public class CarSpawnerScript : MonoBehaviour
{
    public float carSpawnEveryNSeconds;
    public CarTypesScrObj carTypes;
    public GameObject car;

    float[] xRanges = { -1.85f, -0.75f, 0.75f, 1.85f };
    bool isPrevSpwnUpLane;
    CarTypesScrObj.VehicleTypes[] latestSpwnCarTypeInLane = { CarTypesScrObj.VehicleTypes.NONE, CarTypesScrObj.VehicleTypes.NONE, CarTypesScrObj.VehicleTypes.NONE, CarTypesScrObj.VehicleTypes.NONE };

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
        bool isCurrSpwnUpLane = !isPrevSpwnUpLane;
        isPrevSpwnUpLane = isCurrSpwnUpLane;
        //Spawn in Up lane
        if (isCurrSpwnUpLane)
        {
            uint laneNum = (uint)Random.Range(2, 4);
            float laneXPos = xRanges[laneNum];
            Vector2 overlapPoint = new Vector2(laneXPos, car.transform.position.y + 20);

            var collArr = Physics2D.OverlapBoxAll(overlapPoint, new Vector2(0.5f, 0.5f), 0);

            if (collArr.Length == 0)
            {
                //Spawn
                Debug.Log("Spawn");
                SpawnCarAtLane(laneNum);
            }

        }
        else //Spawn down lane
        {
            uint laneNum = (uint)Random.Range(0, 2);
            float laneXPos = xRanges[laneNum];
            Vector2 overlapPoint = new Vector2(laneXPos, car.transform.position.y + 20);

            var collArr = Physics2D.OverlapBoxAll(overlapPoint, new Vector2(0.5f, 0.5f), 0);



            if (collArr.Length == 0)
            {
                //Spawn
                Debug.Log("Spawn");
                SpawnCarAtLane(laneNum);

            }
        }
        
    }

    //Spawn a random car at lane
    void SpawnCarAtLane(uint lane)
    {
        //previous car in this lane
        var prevSpawnedCarInThisLane = latestSpwnCarTypeInLane[lane];

        var carToBeSpawned = (CarTypesScrObj.VehicleTypes)Random.Range(0, 4);

        while (prevSpawnedCarInThisLane == carToBeSpawned)
        {
            carToBeSpawned = (CarTypesScrObj.VehicleTypes)Random.Range(0, 4);
        }

        latestSpwnCarTypeInLane[lane] = carToBeSpawned;

        var carObjToSpawn = carTypes.GetCarAtIndex((uint)carToBeSpawned);
        carObjToSpawn = Instantiate(carObjToSpawn);

        //If down lane
        if (lane < 2)
        {
            carObjToSpawn.transform.position = new Vector2(xRanges[Random.Range(0, 2)], car.transform.position.y + 20.0f);
        }
        else //Else up lane
        {
            carObjToSpawn.transform.rotation = Quaternion.Euler(0, 0, 0);
            carObjToSpawn.transform.position = new Vector2(xRanges[Random.Range(2, 4)], car.transform.position.y + 20.0f);
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
