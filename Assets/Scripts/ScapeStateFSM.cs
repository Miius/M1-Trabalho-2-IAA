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
            
        }
    }

    public void Exit() 
    {
        enemy.SetState(new PatrolStateFSM(enemy));
        // enemy.energy = 3;
    }
}