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

    protected bool canRun = true;
    protected bool isDead = false;


    public float radius = 10f;  // Phạm vi phát hiện
    [HideInInspector] public Vector3 position; // Vị trí ban đầu
    public float maxDistace = 50f; // khoảng cách
    public float distance;
    [HideInInspector] protected float speed;
    public float originalSpeed = 4;

    AudioSource[] audioSources;
    [SerializeField] private AudioSource enemySound01;
    [SerializeField] private AudioSource enemySound02;
    [SerializeField] private AudioSource enemySound03;
    #endregion

    protected virtual void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();

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

        speed = originalSpeed;
        navMeshAgent.speed = speed;
        navMeshAgent.isStopped = false;
    }

    public void EnemySoundControll()
    {
        // Mảng chứa các âm thanh để dễ quản lý
        audioSources = new AudioSource[] { enemySound01, enemySound02, enemySound03 };

        // Chọn một âm thanh ngẫu nhiên
        int randomSound = Random.Range(0, audioSources.Length);
        Debug.Log("Random Sound Index: " + randomSound);

        // Nếu không có âm thanh nào đang phát, bắt đầu phát một âm thanh ngẫu nhiên
        if (!audioSources[0].isPlaying && !audioSources[1].isPlaying && !audioSources[2].isPlaying)
        {
            audioSources[randomSound].Play();
        }
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