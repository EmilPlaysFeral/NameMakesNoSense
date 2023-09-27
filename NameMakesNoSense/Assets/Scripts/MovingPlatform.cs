using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] private WayPointPath waypointPath;
    [SerializeField] private float speed;

    private int targetWaypointIndex;

    private Transform previousWaypoint;
    private Transform targetWaypoint;

    private float timeToWaypoint;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        float elapsedPercentage = elapsedTime / timeToWaypoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage); //smooth the landing zones platform smooth beginning and end
        transform.position = Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, elapsedPercentage);
        transform.rotation = Quaternion.Lerp(previousWaypoint.rotation, targetWaypoint.rotation, elapsedPercentage); //if I want rotation on the platform. Also (change rotation on waypoint transforms in the scene).

        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }

    private void TargetNextWaypoint()
    {
        previousWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);
        targetWaypointIndex = waypointPath.GetNextWaypointIndex(targetWaypointIndex);
        targetWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);

        elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
        timeToWaypoint = distanceToWaypoint / speed;
    }

    private void OnTriggerEnter(Collider other)
    {
            other.transform.SetParent(transform); //attach player to platform as child
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
        
        /*
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>(); //Access health script on Player
            if(playerHealth != null && playerHealth.GetCurrentHealth() < 0)
            {
                other.transform.SetParent(null);
            }
        }*/
    }
}
