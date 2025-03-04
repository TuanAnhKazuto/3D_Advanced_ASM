using TMPro;
using UnityEngine;

public class M4A1 : Gun
{
    public override void Awake()
    {
        base.Awake();
        muzzleFlash = GameObject.Find("M4A1MuzzleFlash").GetComponent<ParticleSystem>();
        ammoCountText = GameObject.Find("MainBulletCount").GetComponent<TextMeshProUGUI>();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        ammoCountText.text = currenAmmo.ToString();

    }
}