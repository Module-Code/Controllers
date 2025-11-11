using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KinematicWASDController : MonoBehaviour
{
	public float speed = 3f;
	public float rotationSpeed = 720f;
	public bool enableArrowKeys = true;

	Rigidbody rb;
	Vector3 desiredVelocity;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		rb.interpolation = RigidbodyInterpolation.Interpolate;
	}

	void Update()
	{
		float h = 0f, v = 0f;

		if (Input.GetKey(KeyCode.W)) v += 1f;
		if (Input.GetKey(KeyCode.S)) v -= 1f;
		if (Input.GetKey(KeyCode.D)) h += 1f;
		if (Input.GetKey(KeyCode.A)) h -= 1f;

		if (enableArrowKeys)
		{
			if (Input.GetKey(KeyCode.UpArrow)) v += 1f;
			if (Input.GetKey(KeyCode.DownArrow)) v -= 1f;
			if (Input.GetKey(KeyCode.RightArrow)) h += 1f;
			if (Input.GetKey(KeyCode.LeftArrow)) h -= 1f;
		}

		Vector3 input = new Vector3(h, 0f, v);
		desiredVelocity = (input.sqrMagnitude > 0.0001f) ? input.normalized * speed : Vector3.zero;
	}

	void FixedUpdate()
	{
		float dt = Time.fixedDeltaTime;

		if (desiredVelocity.sqrMagnitude > 0.0001f)
		{
			Quaternion target = Quaternion.LookRotation(desiredVelocity.normalized, Vector3.up);
			Quaternion next = Quaternion.RotateTowards(rb.rotation, target, rotationSpeed * dt);
			rb.MoveRotation(next);
		}

		rb.MovePosition(rb.position + desiredVelocity * dt);
	}
}