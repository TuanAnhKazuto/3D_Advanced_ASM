using UnityEngine;
using System.Collections;
public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float fireSpeed = 5f;
    public float impactForce = 30f;


    public int maxAmmo = 10;
    public int currenAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;



    public Camera fpscam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject bulletHole;

    public float nextTimeToFire = 0f;

    public Animator animator;


    private void Start()
    {
        fpscam = GameObject.Find("Main Camera").GetComponent<Camera>();
        muzzleFlash = GameObject.Find("MuzzleFlash").GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        if (currenAmmo == -1 )
        currenAmmo = maxAmmo;

        isReloading = false;
    }

    private void OnEnable()
    {
            isReloading = false;
            animator.SetBool("Reloaing", false);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(isReloading);
        if (isReloading)
            return;

        if(currenAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
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
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("reload");
        reloadTime = animator.GetCurrentAnimatorStateInfo(0).length;

        animator.SetBool("Reloaing", true);
        yield return new WaitForSeconds(reloadTime - .7f);

        animator.SetBool("Reloaing", false);
        yield return new WaitForSeconds(.25f);

        currenAmmo = maxAmmo;
        isReloading = false ;
    }

    protected void Shoot()
    {
        muzzleFlash.Play();
        currenAmmo --;

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

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            if(hit.transform.tag != "Enemy")
            {
                GameObject hole = Instantiate(bulletHole, hit.point, _rorate);
                Destroy(hole, 5f);
            }
            Destroy(impactGO, 2f);

        }
    }





}
