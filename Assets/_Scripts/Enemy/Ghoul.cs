using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : EnemyMovement
{
    Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
        currentState = EnemyState.Idle;
    }

    public enum EnemyState
    {
        Idle,
        Run,
        Attack
    }

    public EnemyState currentState;

    private void ChageState(EnemyState newState)
    {
        switch(currentState)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Run:
                break;
            case EnemyState.Attack:
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
            case EnemyState.Attack:
                anim.Stop("Idle");
                anim.Stop("Walk");
                anim.Stop("Run");
                anim.Play("Attack1");
                anim.Stop("Attack2");
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
        if (distance <= 3f)
        {
            ChageState(EnemyState.Attack);
        }
        else
        {
            ChageState(EnemyState.Run);
        }
    }
}
