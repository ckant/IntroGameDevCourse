﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public int Mag = 20;

    public float FireRate = .1f;

    private float SetFireDelay;

    public GameObject BulletPrefab;

    public void Fire()
    {
        if (SetFireDelay == 0f && Mag > 0)
        {
            GameObject tempBullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            tempBullet.GetComponent<Rigidbody>().velocity = transform.forward * 100;
            SetFireDelay = FireRate;
            Mag--;
        }
    }

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        SetFireDelay = Mathf.Clamp(SetFireDelay - Time.deltaTime, 0f, Mathf.Infinity);
	}
}
