using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private GameObject damageZone;

    private void Start()
    {
        damageZone.SetActive(false);
    }
    public void DamageZoneOn()
    {
        damageZone.SetActive(true);
    }

    public void DamageZoneOff()
    {
        damageZone.SetActive(false);
    }
}