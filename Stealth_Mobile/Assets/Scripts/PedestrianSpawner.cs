using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    public GameObject[] pedestrian;
    public int numberOfPedestrians = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {

        GameObject parentRoot = new GameObject("Pedestrians");
        parentRoot.transform.position = Vector3.zero;
        int count = 0;
        while (count < numberOfPedestrians)
        {
            GameObject obj = Instantiate(pedestrian[Random.Range(0, pedestrian.Length)]);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;
            obj.transform.SetParent(parentRoot.transform);
            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
