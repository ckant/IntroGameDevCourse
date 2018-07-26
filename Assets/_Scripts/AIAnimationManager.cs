using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimationManager : MonoBehaviour
{
    public AIMonsterController Controller;
    public GameObject Hitbox;

    public void StartAttack()
    {
        Hitbox.SetActive(true);
    }

    public void EndDamage()
    {
        Hitbox.SetActive(false);
    }

    public void EndAttack()
    {
        Controller.CurrentAttackCooldown = Controller.AttackCooldown;
    }
}
