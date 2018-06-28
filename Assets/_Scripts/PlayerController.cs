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

    public float RotateSpeed;

    public Animator Anim; // Animator

    private float FireRate;

    private Vector3 IP; // Input vector

    private Camera cam;

    public GunController gun;

    // Use this for initialization
    void Start()
    {
        RB = GetComponent<Rigidbody>();

        cam = GameObject.FindObjectOfType<Camera>();

        if (cam == null)
        {
            Debug.Log("No Camera");
        }
    }

    public void updateAnim()
    {
        var localVel = transform.InverseTransformDirection(RB.velocity);

        Anim.SetFloat("ForwardSpeed", localVel.z);
        Anim.SetFloat("RightSpeed", localVel.x);
    }

    public void mouseInput()
    {
        FireRate = Input.GetAxisRaw("Fire1");
    }

    public void keyInput()
    {
        IP.x = Input.GetAxisRaw("Horizontal");
        IP.z = Input.GetAxisRaw("Vertical");

        var isMoving = IP.x != 0 || IP.z != 0;
        bool IsSprinting = isMoving && Input.GetAxisRaw("Sprint") > 0;

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

    public void handleFire()
    {
        if (FireRate > 0)
        {
            gun.Fire();
        }
    }

    public void doMouseLook()
    {
        RaycastHit hit;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10000))
        {
            Vector3 forward = (transform.position - hit.point).normalized * -1;

            transform.forward = Vector3.MoveTowards(transform.forward, forward, RotateSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        mouseInput();
        keyInput();
    }

    void FixedUpdate()
    {
        handleMovement();
        handleFire();
        updateAnim();
        doMouseLook();
    }
}
