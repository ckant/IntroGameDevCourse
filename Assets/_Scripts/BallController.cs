using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody RB;

    public float Speed;

	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        float LeftRight = Input.GetAxisRaw("Horizontal");
        float ForwardBack = Input.GetAxisRaw("Vertical");
        Vector3 Dir = new Vector3(LeftRight, 0, ForwardBack);

        RB.AddForce(Dir * Time.deltaTime * Speed);

    }
}
