using System.Collections;
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
        ZombieBehaviour();
        EnemySoundControll();
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
        if (currentState == newState) return;

        switch (newState)
        {
            case EnemyState.Idle:
                speed = 0;
                navMeshAgent.speed = speed;
                animator.SetBool("isAttack", false);
                break;
            case EnemyState.Run:
                animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
                animator.SetBool("isAttack", false);
                break;
            case EnemyState.Attack:
                animator.SetBool("isAttack", true);
                animator.SetFloat("Speed", 0);  
                break;
            case EnemyState.Dead:
                speed = 0;
                navMeshAgent.speed = speed;
                animator.SetBool("isDead", true);
                isDead = true;
                StartCoroutine(WaitForAnimation());
                break;
        }

        currentState = newState;
    }

    private void ZombieBehaviour()
    {
        if (distance <= radius && canRun)
        {
            ChangeState(EnemyState.Run);
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
        }
        
        if (distance <= 3f)
        {
            speed = 0.2f;
            navMeshAgent.speed = speed;
            canRun = false;
            if (speed <= 0.3f && speed >= 0)
            {
                ChangeState(EnemyState.Attack);
            }
        }
        else
        {
            canRun = true;
        }

        if (distance >= maxDistace)
        {
            ChangeState(EnemyState.Idle);
        }

        
    }
    public override void Death()
    {
        ChangeState(EnemyState.Dead);
    }

    private IEnumerator WaitForAnimation()
    {
        float time = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}