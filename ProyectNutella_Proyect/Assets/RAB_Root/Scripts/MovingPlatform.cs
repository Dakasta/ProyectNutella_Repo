using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField]
    private WayPointPath wayPointPath;
    public float platformSpeed;
    private int targetWayPointIndex;
    private Transform previousWayPoint;
    private Transform targetWayPoint;
    private float timeToWayPoint;
    private float elapsedTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TargetNextWayPoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        float elapsedPercentage = elapsedTime / timeToWayPoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        transform.position = Vector3.Lerp(previousWayPoint.position, targetWayPoint.position, elapsedPercentage);
        transform.rotation = Quaternion.Lerp(previousWayPoint.rotation, targetWayPoint.rotation, elapsedPercentage);

        if(elapsedPercentage >= 1)
        {
            TargetNextWayPoint();
        }
    }

    private void TargetNextWayPoint()
    {
        previousWayPoint = wayPointPath.GetWayPoint(targetWayPointIndex);
        targetWayPointIndex = wayPointPath.GetNextWayPoint(targetWayPointIndex);
        targetWayPoint = wayPointPath.GetWayPoint(targetWayPointIndex);

        elapsedTime = 0;

        float distanceToWayPoint = Vector3.Distance(previousWayPoint.position, targetWayPoint.position);
        timeToWayPoint = distanceToWayPoint / platformSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
