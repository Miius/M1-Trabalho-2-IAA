using UnityEngine;

public class ScapeStateFSM : StateFSM
{
    EnemyMachineFSM enemy;
    // float time;

    public ScapeStateFSM(EnemyMachineFSM enemy)
    {
        this.enemy = enemy;
    }

    public void Enter() 
    {
        Debug.Log("Enter Scape State");
    }

    public void Update() 
    {
        if (enemy.IsNearTarget())
        {
            if (enemy.CollideWithTarget())
            {
                enemy.Die();
            }
            enemy.SetState(new ScapeStateFSM(enemy));
        }
        else
            enemy.SetState(new PatrolStateFSM(enemy));
    }

    public void Exit() 
    {
        enemy.SetState(new PatrolStateFSM(enemy));
        // enemy.energy = 3;
    }
}