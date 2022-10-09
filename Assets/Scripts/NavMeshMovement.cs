using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    public Transform destination = null;
    
    NavMeshAgent navMeshAgent;

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;
    public bool isStoped = false;


    private void Start() {
        StartCoroutine(DoCheck());
    }
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
        // Move();
        // if(destination.hasChanged)
        // if (destination != null)
        //     navMeshAgent.SetDestination(new Vector3(destination.position.x, 5, destination.position.z));
    }
    public void MoveTo(Transform target)
    {
        if (target != null)
            // navMeshAgent.SetDestination(new Vector3(destination.position.x, 0, destination.position.z));
            navMeshAgent.SetDestination(new Vector3(target.position.x, 0, target.position.z));
    }

    public void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) navMeshAgent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (isStoped)
        {
            walkPointSet = false;
            isStoped = false;
        }
        if (distanceToWalkPoint.magnitude < 1.0f) {
            walkPointSet = false;
        }
    }

    IEnumerator DoCheck()
    {
        Vector3 pos = transform.position;
        yield return new WaitForSeconds(1.0f);
        if ((pos.x - transform.position.x > -0.2f && pos.x - transform.position.x < 0.2f) || transform.position == pos)
        {
            isStoped = true;
        }
        else
        {
            isStoped = false;
        }
        yield return DoCheck();
    }
    public void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        // if (Physics.Raycast(transform.position, walkPoint, 2f)) {
            walkPointSet = true;
        // }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
            destination = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
        Gizmos.DrawLine(transform.position, walkPoint);
    }
}
