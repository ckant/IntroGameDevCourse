using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimationManager : MonoBehaviour
{
    public AIMonsterController Controller;
    public GameObject Hitbox;

    public void StartAttack()
    {
        Debug.Log("Enabled hitbox");
        Hitbox.SetActive(true);
    }

    public void EndDamage()
    {
        Debug.Log("Disabled hitbox");
        Hitbox.SetActive(false);
    }

    public void EndAttack()
    {
        Controller.CurrentAttackCooldown = Controller.AttackCooldown;
    }
}
