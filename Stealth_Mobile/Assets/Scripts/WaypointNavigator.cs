using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{

    PedestrianNavigation pd;
    public Waypoint currentWaypoint;

    int direction;
    // Start is called before the first frame update
    void Awake()
    {
        pd = GetComponent<PedestrianNavigation>();
    }

    private void Start()
    {
        direction = Mathf.RoundToInt(Random.Range(0, 2));
        Debug.Log(direction);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (pd.reachedDestination)
        {

            bool shouldBranch = false;
            if(currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0, 1) <= currentWaypoint.branchRatio? false : true;
            }

            if (shouldBranch)
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
            }
            else
            {
                if (direction == 0)
                {
                    if (currentWaypoint.nextWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                        direction = 1;
                    }
                }
                if (direction != 0)
                {
                    if (currentWaypoint.previousWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                        direction = 0;
                    }
                }
            }
            pd.reachedDestination = false;
            pd.MoveTo(currentWaypoint.transform.position);
        }
        pd.MoveTo(currentWaypoint.transform.position);
    }
}
