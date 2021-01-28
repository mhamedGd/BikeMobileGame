using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWaypoints : MonoBehaviour
{

    public Color lineColor;
    Transform[] waypointsArray;
    public List<Transform> waypoints;

    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor;

        waypointsArray = GetComponentsInChildren<Transform>();
        waypoints = new List<Transform>();
        foreach(Transform waypoint in waypointsArray)
        {
            if (waypoint != transform)
            {
                waypoints.Add(waypoint);
            }
        }

        for(int i = 0; i < waypoints.Count; i++)
        {
            Vector3 currentWaypoint = waypoints[i].position;
            Vector3 previousWaypoint = Vector3.zero;
            Gizmos.DrawSphere(currentWaypoint, 0.5f);

            if (i != 0)
            {
                previousWaypoint = waypoints[i - 1].position;
                Gizmos.DrawLine(currentWaypoint, previousWaypoint);
                
            }
        }
        
    }

    public Transform NextWaypoint(Transform c_waypoint)
    {
        int index = waypoints.IndexOf(c_waypoint);
        if(index != -1 && index != waypoints.Count -1)
        {
            return waypoints[index + 1];
        }else if(index != -1 && index == waypoints.Count - 1){
            return waypoints[0];
        }
        else
        {
            return null;
        }
    }
}
