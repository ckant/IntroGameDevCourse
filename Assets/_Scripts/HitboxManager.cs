using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour {
    public float DamageAmount;

    private void OnTriggerEnter(Collider other)
    {
        var healthController = other.gameObject.GetComponent<HealthController>();
        bool isPlayer = other.gameObject.CompareTag("Player");
        if (healthController != null && isPlayer)
        {
            healthController.TakeDamage(DamageAmount);
        }
    }
}
