using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float heath = 50f;

    public void TakeDamage (float amount)
    {
        heath -= amount;
        if ( heath <= 0f )
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
