using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMoviment : MonoBehaviour
{
    public Transform destination = null;
    
    NavMeshAgent navMeshAgent;
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent> ();
    }

    public void ReciveTarget(Transform dest)
    {
        destination = dest;
    }
    void Update()
    {
        if (destination != null)
            navMeshAgent.SetDestination(new Vector3(destination.position.x, 0, destination.position.z));
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
            destination = null;
    }
}
