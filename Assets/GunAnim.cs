using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnim : Gun
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        fpscam = GameObject.Find("Main Camera").GetComponent<Camera>();
        muzzleFlash = GameObject.Find("MuzzleFlash").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireSpeed / fireRate;
            Shoot();
            anim.SetTrigger("Fire");
            anim.SetBool("isFire", true);
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isFire", false);
        }
    }
}
