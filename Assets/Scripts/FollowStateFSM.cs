using UnityEngine;

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
        // enemy.Move(enemy.TargetDir().normalized);

        // if (enemy.energy < 0)
        // {
        //     enemy.SetState(new ScapeStateFSM(enemy));
        // }
        // if (enemy.IsNearTarget() == false)
        // {
        //     enemy.SetState(new FollowStateFSM(enemy));
        // }
    }

    public void Exit() {}
}
