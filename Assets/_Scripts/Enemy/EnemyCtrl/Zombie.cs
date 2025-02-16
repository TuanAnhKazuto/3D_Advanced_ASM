using UnityEngine;

public class Zombie : EnemyBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();    
        RunOnStart();
    }

    private void Update()
    {
        EnemyMove();
        EnemyDeath(enemyHealth);
    }

    public override void Death()
    {
        animator.Play("Z_FallingBack");
    }
}