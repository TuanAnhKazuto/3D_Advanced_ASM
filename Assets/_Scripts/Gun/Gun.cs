using UnityEngine;
using System.Collections;
public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float fireSpeed = 5f;
    public float impactForce = 30f;

    [Header("Ammo Info")]
    public int maxAmmo = 10;
    public int currenAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public float nextTimeToFire = 0f;

    [Header("References")]
    public Camera fpscam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject bulletHole;
    public Animator animator;


    private void Start()
    {
        fpscam = GameObject.Find("Main Camera").GetComponent<Camera>();
        muzzleFlash = GameObject.Find("MuzzleFlash").GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        currenAmmo = maxAmmo;

        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (isReloading)
            return;

        if(currenAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            return;
        }
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireSpeed / fireRate;
            Shoot();
            animator.SetBool("isFire", true);
        }
        else
        {
            animator.SetBool("isFire", false);
        }

    }
    protected void Reload()
    {
        isReloading = true;
        animator.SetBool("isFire", false);
        animator.SetBool("Reloading", true);
    }

    protected void Shoot()
    {
        muzzleFlash.Play();
        currenAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.normal * -impactForce);
            }

            Quaternion lookRotation = Quaternion.LookRotation(hit.normal);
            Quaternion _rorate = lookRotation * Quaternion.Euler(0f, 90f, 90f);

            if(hit.transform.gameObject.CompareTag("Player"))
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, _rorate);
                Destroy(impactGO, 2f);
            }

            if (!hit.transform.gameObject.CompareTag("Enemy") || !hit.transform.CompareTag("Player"))
            {
                GameObject hole = Instantiate(bulletHole, hit.point, _rorate);
                Destroy(hole, 5f);
            }
        }
    }

    public void ReloadingDone()
    {
        isReloading = false;
        Debug.Log("Reloading Done");
        animator.SetBool("Reloading", false);
        currenAmmo = maxAmmo;
    }



}
