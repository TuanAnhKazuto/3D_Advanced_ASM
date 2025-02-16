using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBehaviour : MonoBehaviour
{
    #region Variables
    public float maxHealth = 100f;
    [SerializeField] protected Transform target;
    [SerializeField] protected NavMeshAgent navMeshAgent;
    [SerializeField] protected EnemyHealth enemyHealth;
    [SerializeField] protected Animation anim;

    protected bool canRun = true;
    protected bool isDead = false;


    public float radius = 10f;  // Phạm vi phát hiện
    [HideInInspector] public Vector3 position; // Vị trí ban đầu
    public float maxDistace = 50f; // khoảng cách
    public float distance;
    [HideInInspector] protected float speed;
    public float originalSpeed = 4;
    #endregion

    protected virtual void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animation>();

        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;
        else
            target = player.GetComponent<Transform>();

        navMeshAgent = GetComponent<NavMeshAgent>();


        position = transform.position; // vị trí

        // Kiểm tra nếu vị trí ban đầu nằm trên NavMesh
        if (NavMesh.SamplePosition(position, out NavMeshHit hit, 10f, NavMesh.AllAreas))
        {
            position = hit.position; // Đặt lại vị trí trên NavMesh
            navMeshAgent.enabled = true; // Bật NavMeshAgent
            navMeshAgent.Warp(position); // Đặt vị trí ban đầu chính xác
        }

        speed = 0;
        navMeshAgent.speed = speed;
        navMeshAgent.isStopped = false;
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

    public void ChangeState(EnemyState newState)
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

    public void EnemyMove()
    {
        if (target != null)
        {
            var lookPos = target.position - transform.position;
            lookPos.y = 0;

            distance = Vector3.Distance(target.position, transform.position);

            if (distance <= radius)
            {
                if (navMeshAgent.isOnNavMesh)
                {

                    var rotation = Quaternion.LookRotation(lookPos);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
                    navMeshAgent.SetDestination(target.position);
                }
            }

            if(distance <= maxDistace)
            {
                if(distance <= radius)
                {
                    speed = originalSpeed;
                    navMeshAgent.speed = speed;
                }
            }
            else
            {
                speed = 0;
                navMeshAgent.speed = speed;
            }
        }
        else
        {
            return;
        }
    }

    public void EnemyDeath(EnemyHealth enemyHealth)
    {
        if(enemyHealth.curHealth <= 0)
        {
            Death();
        }
    }

    public abstract void Death();
}