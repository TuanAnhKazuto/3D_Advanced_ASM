using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driver : LoadingLevel
{
    protected override void Start()
    {
        base.Start();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LoadLevel();
        }
    }
}
