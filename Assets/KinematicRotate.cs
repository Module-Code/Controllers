using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KinematicRotate : MonoBehaviour
{
	public Transform lookTarget;
	public float rotationSpeed = 120f; // degrees per second
	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		rb.interpolation = RigidbodyInterpolation.Interpolate;
	}

	void FixedUpdate()
	{
		if (lookTarget == null) return;

		Quaternion targetRot = Quaternion.LookRotation(lookTarget.position - rb.position);
		Quaternion next = Quaternion.RotateTowards(rb.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime);
		rb.MoveRotation(next);
	}
}
