using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected NavMeshAgent navMeshAgent;

    public float radius = 10f;  // Phạm vi phát hiện
    [HideInInspector] public Vector3 position; // Vị trí ban đầu
    public float maxDistace = 50f; // khoảng cách
    public float distance;
    [HideInInspector] protected float speed;
    public float originalSpeed = 4;

    protected void RunOnStart()
    {

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

    public void Move()
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
}