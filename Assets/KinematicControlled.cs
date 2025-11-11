using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KinematicControlled : MonoBehaviour
{
	public float speed = 4f;
	Vector3 desiredVelocity;
	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		rb.interpolation = RigidbodyInterpolation.Interpolate;
	}

	void Update()
	{
		// gather input / network prediction here
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		Vector3 input = new Vector3(h, 0f, v);
		desiredVelocity = input.normalized * speed;
	}

	void FixedUpdate()
	{
		Vector3 next = rb.position + desiredVelocity * Time.fixedDeltaTime;
		rb.MovePosition(next);
	}
}
