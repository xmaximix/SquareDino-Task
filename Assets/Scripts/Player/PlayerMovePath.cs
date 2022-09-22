using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class PlayerMovePath : MonoBehaviour
{
    [HideInInspector] public bool moving { get; private set; }
    [SerializeField] PathDrawer pathDrawer;
    private Waypoint[] waypoints;
    private int currentWaypoint;
    private NavMeshAgent navMeshAgent;
    private PlayerAnimations animations;
    private float minReachDistance = -1;
    public bool start { get; private set; }

    private void Start()
    {
        transform.parent = null;
        start = true;
        waypoints = GetComponentsInChildren<Waypoint>();
    }

    public void Init(NavMeshAgent playerAgent, PlayerAnimations playerAnimations)
    {
        navMeshAgent = playerAgent;
        animations = playerAnimations;
    }

    private void Update()
    {
        if (moving)
        {
            if (navMeshAgent.remainingDistance < minReachDistance)
            {
                ReachDestination();
            }
        }
    }

    private IEnumerator RotateLookForward()
    {
        navMeshAgent.angularSpeed = 0;
        Vector3 dir = (waypoints[currentWaypoint - 1].transform.position + waypoints[currentWaypoint - 1].transform.forward * 3) - waypoints[currentWaypoint - 1].transform.position;
        dir.y = 0;
        Quaternion rot = Quaternion.LookRotation(dir);
        for (float t = 0; t < 1; t += Time.deltaTime / 3)
        {
            navMeshAgent.transform.rotation = Quaternion.Lerp(navMeshAgent.transform.rotation, rot, t * t);
            yield return null;
        }
        navMeshAgent.angularSpeed = 120;
    }

    private void ReachDestination()
    {
        StartCoroutine(RotateLookForward());
        animations.StopRunning();
        moving = false;
    }

    public void SetNextDestination()
    {
        if (start)
        {
            StartCoroutine(ChangeMinReachDistance());
        }
        if (currentWaypoint + 1 <= waypoints.Length)
        {
            navMeshAgent.destination = waypoints[currentWaypoint].position;
            animations.StartRunning();
            moving = true;
            currentWaypoint++;
            return;
        }
        SceneRestarter.Restart();
    }

    private void OnDrawGizmos()
    {
        var waypoints = GetComponentsInChildren<Waypoint>();
        pathDrawer.Draw(waypoints);
    }

    IEnumerator ChangeMinReachDistance()
    {
        yield return new WaitForSeconds(1f);
        minReachDistance = 0.01f;
        start = false;
    }
}
