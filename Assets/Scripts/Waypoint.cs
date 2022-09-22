using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Vector3 position { get; private set; }

    void Start()
    {
        position = transform.position;
    }

    private void Update()
    {
        transform.position = position;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * 3, Color.red);
    }
}
