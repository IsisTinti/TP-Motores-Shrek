using UnityEngine.AI;

public class Enemy : PoolableObject
{

    public EnemyMovement movement;
    public NavMeshAgent agent;
    public int enemyHealth;
    public int health;


    public override void OnDisable()
    {
        base.OnDisable();
        agent.enabled = false;

    }
  
}
