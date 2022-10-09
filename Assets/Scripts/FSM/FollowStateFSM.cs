using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowStateFSM : StateFSM
{
    EnemyMachineFSM enemy;

    public FollowStateFSM(EnemyMachineFSM enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("Enter Follow State");
        // enemy.GetComponent<NavMeshMovement>().ReciveTarget(enemy.Target);
        enemy.GetComponent<NavMeshMovement>().MoveTo(enemy.Target);

    }

    public void Update()
    {
        if (enemy.IsNearTarget())
        {
            if (enemy.CollideWithTarget())
            {
                enemy.GotThePlayer();
                // enemy.Target = null;
                // enemy.SetState(new PatrolStateFSM(enemy));
            }
            enemy.GetComponent<NavMeshMovement>().MoveTo(enemy.Target);
            // enemy.GetComponent<NavMeshMovement>().Move();
            // enemy.SetState(new FollowStateFSM(enemy));
        }
        else
        {
            Debug.Log("sumiu");
            // enemy.GetComponent<NavMeshMovement>().ReciveTarget(null);
            // enemy.GetComponent<NavMeshMovement>().ReciveTarget(null);
            // enemy.GetComponent<NavMeshMovement>().MoveTo(null);
            enemy.SetState(new PatrolStateFSM(enemy));
        }
            // enemy.Target = null;
    }

    public void Exit() {
    }
}
