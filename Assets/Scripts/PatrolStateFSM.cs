using UnityEngine;

public class PatrolStateFSM : StateFSM
{
    EnemyMachineFSM Enemy;
    float time;
    Vector3 dir;
    
    public PatrolStateFSM(EnemyMachineFSM Enemy)
    {
        this.Enemy = Enemy;
    }

    public void Enter()
    {
        // Debug.Log("Enter Patrol State");
    }

    public void Update()
    {
        // if (Time.time > time)
        // {
        //     dir = Random.onUnitSphere;
        //     dir.y = 0;
        //     time = Time.time + 1;
        // }

        // Enemy.Move(dir);

        // if (Enemy.energy < 0)
        // {
        //     Enemy.SetState(new ScapeStateFSM(Enemy));
        // }
        // if (Enemy.IsNearTarget())
        // {
        //     Enemy.SetState(new FollowStateFSM(Enemy));
        // }
    }

    public void Exit() {}
}