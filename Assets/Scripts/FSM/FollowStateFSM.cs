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
        enemy.GetComponent<NavMeshMovement>().MoveTo(enemy.Target.position);

    }

    public void Update()
    {
        if (enemy.IsNearTarget())
        {
            if (enemy.CollideWithTarget())
            {
                enemy.GotThePlayer();
            }
            enemy.GetComponent<NavMeshMovement>().MoveTo(enemy.Target.position);
        }
        else
        {
            Debug.Log("sumiu");
            enemy.SetState(new PatrolStateFSM(enemy));
        }
    }

    public void Exit() {
    }
}
