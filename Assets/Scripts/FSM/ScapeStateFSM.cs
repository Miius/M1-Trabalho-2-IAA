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
        enemy.GetComponent<NavMeshMovement>().MoveTo(-enemy.Target.position);
    }

    public void Update() 
    {
        if (enemy.IsNearTarget())
        {
            if (enemy.CollideWithTarget())
            {
                enemy.Die();
            }
        }
        // else
            // enemy.SetState(new PatrolStateFSM(enemy));
    }

    public void Exit() 
    {
        enemy.SetState(new PatrolStateFSM(enemy));
        // enemy.energy = 3;
    }
}