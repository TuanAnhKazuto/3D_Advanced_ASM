using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : EnemyMovement
{
    Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    public enum EnemyState
    {
        Idle,
        Move,
        Attack
    }

    public EnemyState currentState;

    private void ChageState(EnemyState newState)
    {
        switch(currentState)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Move:
                break;
            case EnemyState.Attack:
                break;
        }

        switch (newState)
        {
            case EnemyState.Idle:

                break;
            case EnemyState.Move:
                break;
            case EnemyState.Attack:
                break;
        }

        currentState = newState;
    }

    private void Update()
    {
        Move();
    }
    
}
