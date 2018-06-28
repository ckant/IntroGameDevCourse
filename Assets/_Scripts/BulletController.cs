using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float DamageAmount;

    public GameObject owner;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != owner)
        {
            Destroy(gameObject);

            if (other.gameObject.GetComponent<HealthController>() != null)
            {
                other.gameObject.GetComponent<HealthController>().TakeDamage(DamageAmount);
            }
        }
    }
}
