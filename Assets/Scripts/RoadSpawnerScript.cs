using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnerScript : MonoBehaviour
{
    public GameObject roadPrefab;
    public GameObject initialRoad;
    public GameObject Car;

    public Transform carUpLimit;
    public Transform carDownLimit;

    GameObject currFocusRoad;
    public List<GameObject> roads = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        currFocusRoad = initialRoad;
        roads.Add(currFocusRoad);

        InvokeRepeating(nameof(RemoveExtraRoads), 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpawnForUpLimit();
        CheckSpawnForDownLimit();
        //RemoveExtraRoads();

    }

    private void RemoveExtraRoads()
    {
        List<GameObject> rdsToDest = new List<GameObject>();
        foreach (var road in roads)
        {
            if (road.transform.position.y < carDownLimit.transform.position.y-10 || road.transform.position.y > carUpLimit.transform.position.y+10)
            {
                rdsToDest.Add(road);
            }
        }

        foreach (var item in rdsToDest)
        {
            roads.Remove(item);
            Destroy(item);
        }


    }

    void CheckSpawnForUpLimit()
    {
        bool inABox = false;
        //Check if a uplimit is in a box
        foreach (GameObject road in roads)
        {
            if (road.GetComponent<SpriteRenderer>().bounds.Contains(new Vector2(carUpLimit.position.x, carUpLimit.position.y)))
            { inABox = true; }
        }

        if (!inABox)
        {
            //Spawn road
            var road = Instantiate(roadPrefab);
            if ((int)(carUpLimit.position.y % 6.5f) != 0)
            {
                var c = Mathf.Ceil(carUpLimit.position.y / 6.5f);
                float posY = 6.5f * c;
                road.transform.position = new Vector2(0, posY);

            }
            roads.Add(road);
        }
    }

    void CheckSpawnForDownLimit()
    {
        bool inABox = false;
        //Check if a downlimit is in a box
        foreach (GameObject road in roads)
        {
            if (road.GetComponent<SpriteRenderer>().bounds.Contains(new Vector2(carDownLimit.position.x, carDownLimit.position.y)))
            { inABox = true; }
        }

        if (!inABox)
        {
            //Spawn road
            var road = Instantiate(roadPrefab);

            if ((int)(carDownLimit.position.y % 6.5f) != 0)
            {
                var c = Mathf.Floor(carDownLimit.position.y / 6.5f);
                float posY = 6.5f * c;
                road.transform.position = new Vector2(0, posY);

            }
            roads.Add(road);
        }
    }
}
