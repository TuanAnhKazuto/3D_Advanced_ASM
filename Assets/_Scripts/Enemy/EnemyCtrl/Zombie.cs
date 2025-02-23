using Unity.VisualScripting;
using UnityEngine;

public class Zombie : EnemyBehaviour
{
    Animator animator;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        EnemyMove();
        EnemyDeath(enemyHealth);
    }

    public enum EnemyState
    {
        Idle,
        Run,
        Attack,
        Dead
    }

    public EnemyState currentState;

    private void ChangeState(EnemyState newState)
    {
        if(currentState == newState) return;

        switch (newState)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Run:
                break;
            case EnemyState.Attack:
                break;
            case EnemyState.Dead:
                speed = 0;
                navMeshAgent.speed = speed;
                isDead = true;

                break;
        }

        currentState = newState;
    }

    public override void Death()
    {
        throw new System.NotImplementedException();
    }
}