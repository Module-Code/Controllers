using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class KinematicWaypointMover : MonoBehaviour
{
	public List<Transform> waypoints;
	public float speed = 3f;
	int idx = 0;
	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		rb.interpolation = RigidbodyInterpolation.Interpolate;
	}

	void FixedUpdate()
	{
		if (waypoints == null || waypoints.Count == 0) return;
		Transform target = waypoints[idx];
		Vector3 next = Vector3.MoveTowards(rb.position, target.position, speed * Time.fixedDeltaTime);
		rb.MovePosition(next);

		if (Vector3.Distance(rb.position, target.position) < 0.1f)
			idx = (idx + 1) % waypoints.Count;
	}
}
