using UnityEngine;

public class Ghoul : EnemyMovement
{
    Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
        currentState = EnemyState.Idle;
        RunOnStart();
    }

    public enum EnemyState
    {
        Idle,
        Run,
        Attack1,
        Attack2,
    }

    public EnemyState currentState;

    private void ChageState(EnemyState newState)
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Run:
                break;
            case EnemyState.Attack1:
                break;
            case EnemyState.Attack2:
                break;
        }

        switch (newState)
        {
            case EnemyState.Idle:
                anim.Play("Idle");
                anim.Stop("Walk");
                anim.Stop("Run");
                anim.Stop("Attack1");
                anim.Stop("Attack2");
                anim.Stop("Death");
                break;
            case EnemyState.Run:
                anim.Stop("Idle");
                anim.Stop("Walk");
                anim.Play("Run");
                anim.Stop("Attack1");
                anim.Stop("Attack2");
                anim.Stop("Death");
                break;
            case EnemyState.Attack1:
                anim.Stop("Idle");
                anim.Stop("Walk");
                anim.Stop("Run");
                anim.Play("Attack1");
                anim.Stop("Attack2");
                anim.Stop("Death");
                break;
            case EnemyState.Attack2:
                anim.Stop("Idle");
                anim.Stop("Walk");
                anim.Stop("Run");
                anim.Stop("Attack1");
                anim.Play("Attack2");
                anim.Stop("Death");
                break;
        }

        currentState = newState;
    }

    private void Update()
    {
        Move();
        Attack();
        Debug.Log(distance);
    }

    private void Attack()
    {
        if (distance <= 3f && currentState != EnemyState.Attack2)
        {
            ChageState(EnemyState.Attack1);
        }
        else
        {
            ChageState(EnemyState.Run);
        }
    }
}
