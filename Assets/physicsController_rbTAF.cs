using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class physicsController_rbTAF : MonoBehaviour
{
	public float speed = 10f; // acceleration magnitude
	private Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (rb == null) return;

		//Transform is in local object space
		Vector3 input = Vector3.zero;
		if (Input.GetKey(KeyCode.A)) input += -transform.right;
		if (Input.GetKey(KeyCode.D)) input += transform.right;
		if (Input.GetKey(KeyCode.W)) input += transform.forward;
		if (Input.GetKey(KeyCode.S)) input += -transform.forward;
		

		// normalize so diagonal isn't faster
		if (input.sqrMagnitude > 0f)
		{
			// Use ForceMode.Acceleration so movement is independent of mass
			rb.AddForce(input.normalized * speed, ForceMode.Acceleration);
		}
	}
}

