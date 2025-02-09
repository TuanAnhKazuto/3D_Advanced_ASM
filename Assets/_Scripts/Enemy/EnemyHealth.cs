using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float heath = 50f;

    public void TakeDamage (float amount)
    {
        heath -= amount;
    }
}
