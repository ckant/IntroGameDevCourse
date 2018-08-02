using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMonsterController : MonoBehaviour
{

    private NavMeshAgent agent;

    public float AttackCooldown;
    public float CurrentAttackCooldown;

    public float MovementSpeed;
    public float AttackRadius;

    public GameObject Target;

    public Animator Anim;

    private Rigidbody RB;
    private AISpawnerController spawner;

	// Use this for initialization
	void Start()
    {
        RB = GetComponent<Rigidbody>();

        agent = GetComponent<NavMeshAgent>();

        agent.speed = MovementSpeed;
        agent.acceleration = MovementSpeed * 2;
        agent.stoppingDistance = 0;

        agent.SetDestination(Target.transform.position);

        CurrentAttackCooldown = 0;

        spawner = GetComponent<AISpawnerController>();
    }

    public void die()
    {
        spawner.spawn();
        Destroy(gameObject);
    }

    private void updateAnim()
    {
        var localVel = transform.InverseTransformDirection(agent.velocity);

        Anim.SetFloat("ForwardSpeed", localVel.z);
    }

    private float countDown(float remainingTime)
    {
        return Mathf.MoveTowards(remainingTime, 0, Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        updateAnim();

        float DistanceBetween = agent.remainingDistance;

        CurrentAttackCooldown = countDown(CurrentAttackCooldown);

        if (DistanceBetween <= AttackRadius)
        {
            agent.isStopped = true;

            if (CurrentAttackCooldown == 0)
            {
                Anim.SetTrigger("Attack");
            }
        }
        else if (CurrentAttackCooldown <= 0)
        {
            agent.isStopped = false;
        }

        if (Target != null)
        {
            agent.SetDestination(Target.transform.position);
        }
    }
}
