using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public Transform target;
    public NavMeshAgent navMeshAgent;
 
    public float radius = 10f;  // Phạm vi phát hiện
    public Vector3 position; // Vị trí ban đầu
    public float maxDistace = 100f; // khoảng cách

    Animation anim;


    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        target = player.GetComponent<Transform>();

        GameObject plQuest = GameObject.FindWithTag("Player");
        anim = GetComponent<Animation>();
        anim.Play("Idle");

        position = transform.position; // vị trí

        // Kiểm tra nếu vị trí ban đầu nằm trên NavMesh
        if (NavMesh.SamplePosition(position, out NavMeshHit hit, 10f, NavMesh.AllAreas))
        {
            position = hit.position; // Đặt lại vị trí trên NavMesh
            navMeshAgent.enabled = true; // Bật NavMeshAgent
            navMeshAgent.Warp(position); // Đặt vị trí ban đầu chính xác
        }
        

        navMeshAgent.isStopped = false; 
    }

    private void Update()
    {
        if (target != null)
        {
            var lookPos = target.position - transform.position;
            lookPos.y = 0;
            
            var distance = Vector3.Distance(target.position, transform.position);

            if (distance <= radius)
            {
                if (navMeshAgent.isOnNavMesh)
                {
                    anim.Play("Run");
                    var rotation = Quaternion.LookRotation(lookPos);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
                    navMeshAgent.SetDestination(target.position);
                }

                if(distance <= 3)
                {
                    anim.Play("Attack1");
                }
                
            }
            else
            {
                anim.Play("Idle");
            }

           
        }
        else
        {
            return;
        }
       
    }
    
}







