using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KinematicFollow : MonoBehaviour
{
	public Transform target;
	public float speed = 5f;

	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;              // script-driven
		rb.interpolation = RigidbodyInterpolation.Interpolate; // smoother visuals
	}

	void FixedUpdate()
	{
		if (target == null) return;

		Vector3 next = Vector3.MoveTowards(rb.position, target.position, speed * Time.fixedDeltaTime);
		rb.MovePosition(next);
	}
}
