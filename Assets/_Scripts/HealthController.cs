using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private float Health;

    public float MaxHealth;

    public float HealthGenSpeed;

    public float DamageTimer;
    private float CurrentDamageTimer;

    public void TakeDamage(float DamageAmount)
    {
        Health = Mathf.MoveTowards(Health, 0, DamageAmount);
        CurrentDamageTimer = DamageTimer;

        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void HealthGen(float Speed)
    {
        if (CurrentDamageTimer == 0)
        {
            float regenAmount = (Speed * Time.deltaTime);
            Health = Mathf.MoveTowards(Health, MaxHealth, regenAmount);
        }
    }

    // Use this for initialization
    void Start()
    {
        Health = MaxHealth;
        CurrentDamageTimer = 0;
    }
	
	// Update is called once per frame
	void Update()
    {
        CurrentDamageTimer = Mathf.MoveTowards(CurrentDamageTimer, 0, Time.deltaTime);
        HealthGen(HealthGenSpeed);

        Debug.Log(Health);
    }
}
