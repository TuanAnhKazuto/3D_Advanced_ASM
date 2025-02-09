using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    EnemyBehaviour enemyMovement;
    [HideInInspector] public float curHealth;

    [Tooltip("HpBar => 'Slider'")]
    public Slider hpSlider;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyBehaviour>();
        curHealth = enemyMovement.maxHealth;
        hpSlider.maxValue = curHealth;
        hpSlider.value = curHealth;
    }

    private void Update()
    {
        hpSlider.value = curHealth;
    }

    public void TakeDamage(float amount)
    {
        curHealth -= amount;
    }
}
