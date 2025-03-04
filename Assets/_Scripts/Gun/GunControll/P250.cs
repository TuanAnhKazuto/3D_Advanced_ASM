using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class P250 : Gun
{
    public override void Awake()
    {
        base.Awake();
        muzzleFlash = GameObject.Find("P250MuzzleFlash").GetComponent<ParticleSystem>();
        ammoCountText = GameObject.Find("SubBulletCount").GetComponent<TextMeshProUGUI>();
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
