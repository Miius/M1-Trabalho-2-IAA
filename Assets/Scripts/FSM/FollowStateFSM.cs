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
        // Debug.Log("Enter Follow State");
    }

    public void Update()
    {
        if (enemy.IsNearTarget())
        {
            if (enemy.CollideWithTarget())
            {
                SceneManager.LoadScene("Game");
            }
            enemy.SetState(new FollowStateFSM(enemy));
        }
        else
            enemy.SetState(new PatrolStateFSM(enemy));
    }

    public void Exit() {}
}
