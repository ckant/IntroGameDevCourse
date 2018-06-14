using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody RB;

    private float AccelerationSpeed;

    public float WalkAccelerationSpeed;
    public float SprintAccelerationSpeed;

    private float MaxSpeed;

    public float MaxWalkSpeed;
    public float MaxSprintSpeed;

    public Animator Anim; // Animator

    private Vector3 IP; // Input vector

    private bool IsSprinting;

	// Use this for initialization
	void Start()
    {
        RB = GetComponent<Rigidbody>();
	}

    public void updateAnim()
    {
        var localVel = transform.InverseTransformDirection(RB.velocity);

        Anim.SetFloat("ForwardSpeed", localVel.z);
        Anim.SetFloat("RightSpeed", localVel.x);
    }

    public void keyInput()
    {
        IP.x = Input.GetAxisRaw("Horizontal");
        IP.z = Input.GetAxisRaw("Vertical");

        var isMoving = IP.x != 0 || IP.z != 0;
        IsSprinting = isMoving && Input.GetAxisRaw("Sprint") > 0;

        MaxSpeed = IsSprinting ? MaxSprintSpeed : MaxWalkSpeed;
        AccelerationSpeed = IsSprinting ? SprintAccelerationSpeed : WalkAccelerationSpeed;
    }

    public void handleMovement()
    {
        RB.AddForce(IP * Time.deltaTime * AccelerationSpeed);

        RB.velocity = new Vector3(
            Mathf.Clamp(RB.velocity.x, -MaxSpeed, MaxSpeed), 
            RB.velocity.y, 
            Mathf.Clamp(RB.velocity.z, -MaxSpeed, MaxSpeed));

    }

    // Update is called once per frame
    void Update()
    {
        keyInput();
        handleMovement();
        updateAnim();
    }
}
