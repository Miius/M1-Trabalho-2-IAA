using UnityEngine;

public class PatrolStateFSM : StateFSM
{
    EnemyMachineFSM enemy;
    float time;
    Vector3 dir;
    
    public PatrolStateFSM(EnemyMachineFSM enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("Enter Patrol State");
    }

    public void Update()
    {
        if (enemy.IsNearTarget())
        {
            Debug.Log("perto");
            enemy.SetState(new FollowStateFSM(enemy));
        }
        else
        {
            // enemy.GetComponent<EnemyMovimentRayCast>().Raycast();
            enemy.GetComponent<NavMeshMovement>().Patrolling();
            // enemy.SetState(new PatrolStateFSM(enemy));
        }
    }

    public void Exit() {}
}