using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAudio : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
