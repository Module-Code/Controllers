using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsController_rbMPT : MonoBehaviour
{
	private Rigidbody rb;
	public float speed = 5f;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		if (rb == null)
			Debug.LogWarning("physicsController3: Rigidbody not found on " + gameObject.name);
	}

	void FixedUpdate()
	{
		if (rb == null) return;

		// use KeyCode so Unity recognizes the arrow keys reliably
		if (Input.GetKey(KeyCode.UpArrow))
		{
			Vector3 newPosition = rb.position + transform.forward * speed * Time.fixedDeltaTime;
			rb.MovePosition(newPosition);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			Vector3 newPosition = rb.position - transform.forward * speed * Time.fixedDeltaTime;
			rb.MovePosition(newPosition);
		}
	}
}

