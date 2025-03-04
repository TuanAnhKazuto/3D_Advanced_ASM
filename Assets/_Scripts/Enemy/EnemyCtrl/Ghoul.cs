using System.Collections;
using UnityEngine;

public class Ghoul : EnemyBehaviour
{
    Animation anim;

    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animation>();
    }

    public enum EnemyState
    {
        Idle,
        Run,
        Attack1,
        Attack2,
        Dead
    }

    public EnemyState currentState;

    private void ChangeState(EnemyState newState)
    {
        if (currentState == newState) return;

        switch (newState)
        {
            case EnemyState.Idle:
                PlayAnimation("Idle");
                speed = 0;
                navMeshAgent.speed = speed;
                break;
            case EnemyState.Run:
                PlayAnimation("Run");
                speed = originalSpeed;
                navMeshAgent.speed = speed;
                break;
            case EnemyState.Attack1:
                PlayAnimation("Attack1");
                break;
            case EnemyState.Attack2:
                PlayAnimation("Attack2");
                break;
            case EnemyState.Dead:
                isDead = true;
                PlayAnimation("Death");
                speed = 0;
                navMeshAgent.speed = speed;
                StartCoroutine(WaitForAnimation(anim["Death"].length));
                break;
        }

        currentState = newState;
    }

    private void PlayAnimation(string animationName)
    {
        anim.Play(animationName);
        foreach (AnimationState state in anim)
        {
            if (state.name != animationName)
            {
                anim.Stop(state.name);
            }
        }
    }

    private IEnumerator WaitForAnimation(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
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
        EnemySoundControll();
    }

    public override void Death()
    {
        ChangeState(EnemyState.Dead);
    }
}
