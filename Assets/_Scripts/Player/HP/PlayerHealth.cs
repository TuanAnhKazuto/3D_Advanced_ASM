using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float maxHealth = 1;
    public float currentHealth;
    public WinLose winLose;


    Image hpFill;

    private void Awake()
    {
        hpFill = GameObject.Find("lifeFill").GetComponent<Image>();
        winLose = GameObject.Find("GameManager").GetComponent<WinLose>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        hpFill.fillAmount = currentHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            winLose.GameOver();
        }
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