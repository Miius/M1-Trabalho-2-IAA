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
        enemy.GetComponent<EnemyMovimentRayCast>().Raycast();
    }

    public void Exit() {}
}