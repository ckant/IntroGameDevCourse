using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private float CurrentHealth;

    public float MaxHealth;

    public float HealthGenSpeed;

    public float DamageTimer;
    private float CurrentDamageTimer;

    private int Score = 0;

    public Image HealthBar;
    public Text ScoreText;

    public void TakeDamage(float DamageAmount)
    {
        CurrentHealth = Mathf.MoveTowards(CurrentHealth, 0, DamageAmount);
        CurrentDamageTimer = DamageTimer;

        if (CurrentHealth == 0)
        {
            PlayerController player = GetComponent<PlayerController>();
            if (player != null)
            {
                player.die();
            }
            else
            {
                Destroy(gameObject);
                Score++;
                ScoreText.text = Score.ToString();
            }
        }
    }

    private void HealthGen(float Speed)
    {
        if (CurrentDamageTimer == 0)
        {
            float regenAmount = (Speed * Time.deltaTime);
            CurrentHealth = Mathf.MoveTowards(CurrentHealth, MaxHealth, regenAmount);
        }
    }

    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;
        CurrentDamageTimer = 0;
    }
	
	// Update is called once per frame
	void Update()
    {
        CurrentDamageTimer = Mathf.MoveTowards(CurrentDamageTimer, 0, Time.deltaTime);
        HealthGen(HealthGenSpeed);

        if (HealthBar != null)
        {
            HealthBar.fillAmount = CurrentHealth / MaxHealth;
        }

        //Debug.Log(Health);
    }
}
