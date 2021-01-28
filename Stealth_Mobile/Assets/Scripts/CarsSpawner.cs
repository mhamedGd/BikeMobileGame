using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsSpawner : MonoBehaviour
{

    public GameObject cars;
    public int numberOfCars;
    CarWaypoints carWaypoints;
    public List<Transform> waypointsRemained;
    // Start is called before the first frame update
    void Awake()
    {
        carWaypoints = GetComponent<CarWaypoints>();
        waypointsRemained = carWaypoints.waypoints;
        StartCoroutine("SpawnCars");
        
    }
    IEnumerator SpawnCars()
    {
        for (int i = 0; i < numberOfCars; i++)
        {
            GameObject car = Instantiate(cars);
            car.GetComponent<CarNavigation>().carWaypoints = carWaypoints;
            //car.transform.SetParent(transform);
            int rng = Random.Range(1, waypointsRemained.Count);
            car.transform.position = waypointsRemained[rng].position;
            car.GetComponent<CarNavigation>().SetCurrentWaypoint(waypointsRemained[rng + 1]);            
            //car.transform.forward = waypointsRemained[rng].forward;
            waypointsRemained.RemoveAt(rng);

            yield return new WaitForEndOfFrame();

        }
    }
}
