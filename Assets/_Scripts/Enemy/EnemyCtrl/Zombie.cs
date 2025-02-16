using Unity.VisualScripting;
using UnityEngine;

public class Zombie : EnemyBehaviour
{
    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        EnemyMove();
        EnemyDeath(enemyHealth);
    }

    public override void Death()
    {
        throw new System.NotImplementedException();
    }
}