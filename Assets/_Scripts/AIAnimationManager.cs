using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimationManager : MonoBehaviour
{
    public AIMonsterController Controller;

    public void StartAttack()
    {

    }

    public void EndDamage()
    {

    }

    public void EndAttack()
    {
        Controller.CurrentAttackCooldown = Controller.AttackCooldown;
    }
}
