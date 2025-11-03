using UnityEngine;

public class WayPointPath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetWayPoint(int wayPointIndex)
    {
        return transform.GetChild(wayPointIndex);   
    }

    public int GetNextWayPoint(int currentWayPointIndex)
    {
        int nextWayPointIndex = currentWayPointIndex + 1;

        if (nextWayPointIndex == transform.childCount)
        {
            nextWayPointIndex = 0;
        }

        return nextWayPointIndex;
    }
}
