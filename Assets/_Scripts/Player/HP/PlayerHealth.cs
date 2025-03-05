using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float maxHealth = 1;
    private float currentHealth;

    Image hpFill;

    private void Awake()
    {
        hpFill = GameObject.Find("lifeFill").GetComponent<Image>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        hpFill.fillAmount = currentHealth;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyDamageZone"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        currentHealth -= maxHealth * 0.15f;
        hpFill.fillAmount = currentHealth;
    }

}