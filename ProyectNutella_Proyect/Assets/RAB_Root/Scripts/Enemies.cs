using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Enemies : MonoBehaviour
{
    [Header("Enemies Parameters")]
    public float enemiesSpeed = 0;
    public List<Transform> waypoints;
    private int waypointIndex;
    private float range;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypointIndex = 0;
        range = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        transform.LookAt(waypoints[waypointIndex]);
        transform.Translate(Vector3.forward * enemiesSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < range)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Count)
            {
                waypointIndex = 0;
            }
        }

    }
}
