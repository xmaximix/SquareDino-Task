using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    [SerializeField] PlayerAnimations animations;
    [SerializeField] PlayerMovePath movePath;
    [SerializeField] BulletShooter pistol;
    private NavMeshAgent navMeshAgent;
   
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        pistol.Init();
        movePath.Init(navMeshAgent, animations);
    }

    void Update()
    {
        if (!movePath.start)
        {
            if (Input.GetMouseButtonDown(0) && movePath.moving == false)
            {
                pistol.Shoot();
            }
        }
    }

    public void MoveToNextStage()
    {
        movePath.SetNextDestination();
    }
}
