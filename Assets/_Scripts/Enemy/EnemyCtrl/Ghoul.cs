using System.Collections;
using UnityEngine;

public class Ghoul : EnemyBehaviour
{
    protected override void Start()
    {
        base.Start();
    }

    private void GhoulBehaviour()
    {
        if (speed > 1 && canRun)
        {
            ChangeState(EnemyState.Run);
        }

        if (speed == 0)
        {
            ChangeState(EnemyState.Idle);
        }

        if (distance <= 3f)
        {
            speed = 0.2f;
            navMeshAgent.speed = speed;
            canRun = false;
            if (speed <= 0.3f && speed >= 0)
            {
                ChangeState(EnemyState.Attack1);
            }
        }
        else
        {
            canRun = true;
        }
    }

    private void Update()
    {
        EnemyDeath(enemyHealth);
        if (isDead) return;
        EnemyMove();
        GhoulBehaviour();
    }

    public override void Death()
    {
        ChangeState(EnemyState.Dead);
    }
}
