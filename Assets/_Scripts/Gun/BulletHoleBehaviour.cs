using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoleBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        Destroy(this.gameObject, 4f);
    }
}
