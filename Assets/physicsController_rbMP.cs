using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class physicsController_rbMP: MonoBehaviour
{
	private Rigidbody rb;
	public float speed = 5f;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (rb == null) return;

		// WASD input in local (object) space
		Vector3 input = Vector3.zero;
		if (Input.GetKey(KeyCode.I)) input += transform.forward;
		if (Input.GetKey(KeyCode.K)) input -= transform.forward;
		if (Input.GetKey(KeyCode.J)) input -= transform.right;
		if (Input.GetKey(KeyCode.L)) input += transform.right;

		// normalize so diagonal isn't faster
		if (input.sqrMagnitude > 1f) input = input.normalized;

		// MovePosition expects a target position
		Vector3 delta = input * speed * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + delta);
	}
}
