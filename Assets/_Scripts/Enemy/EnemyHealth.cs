using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    EnemyBehaviour enemyBehaviour;
    [HideInInspector] public float curHealth;

    [Tooltip("HpBar => 'Slider'")]
    public Slider hpSlider;

    private void Start()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
        curHealth = enemyBehaviour.maxHealth;
        hpSlider.maxValue = enemyBehaviour.maxHealth;
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
