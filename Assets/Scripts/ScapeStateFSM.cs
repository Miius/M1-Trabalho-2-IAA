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
        // time = Time.time + 3;
        Debug.Log("Enter Scape State");
    }

    public void Update() 
    {
        // if (Time.time > time)
        // {
        //     enemy.SetState(new PatrolStateFSM(enemy));
        // }
    }

    public void Exit() 
    {
        // enemy.energy = 3;
    }
}