using UnityEngine;

/// <summary>
/// Very tiny proof-of-concept kinematic Rigidbody controller.
/// - Demonstrates: isKinematic, MovePosition, MoveRotation, Update input -> FixedUpdate apply.
/// - Drop onto a GameObject with a Rigidbody and a Collider.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class KinematicTinyController : MonoBehaviour
{
	public float speed = 3f;           // units/sec
	public float rotationSpeed = 720f; // degrees/sec

	Rigidbody rb;
	Vector3 desiredVelocity;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true; // script-driven motion
		rb.interpolation = RigidbodyInterpolation.Interpolate;
	}

	void Update()
	{
		// Read input in Update for responsiveness
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		Vector3 input = new Vector3(h, 0f, v);

		if (input.sqrMagnitude > 0.0001f)
			desiredVelocity = input.normalized * speed;
		else
			desiredVelocity = Vector3.zero;
	}

	void FixedUpdate()
	{
		float dt = Time.fixedDeltaTime;

		// Rotate toward movement direction if moving
		if (desiredVelocity.sqrMagnitude > 0.0001f)
		{
			Quaternion target = Quaternion.LookRotation(desiredVelocity.normalized, Vector3.up);
			Quaternion next = Quaternion.RotateTowards(rb.rotation, target, rotationSpeed * dt);
			rb.MoveRotation(next);
		}

		// Apply kinematic movement
		rb.MovePosition(rb.position + desiredVelocity * dt);
	}
}