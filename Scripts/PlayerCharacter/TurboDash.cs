using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TurboDash : MonoBehaviour
{
	public float force;
	public float accelerationDuration;
	public float maxSpeedDuration;
	public float cooldown;

	private new Rigidbody rigidbody;
	private Coroutine dashCoroutine;
	private float cooldownTimer;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (cooldownTimer > 0f)
		{
			cooldownTimer -= Time.deltaTime;
		}
	}

	public void Launch()
	{
		if (cooldownTimer <= 0)
		{
			if (dashCoroutine != null)
			{
				StopCoroutine(dashCoroutine);
			}
			dashCoroutine = StartCoroutine(DashCoroutine());
			float cooldownTimer = cooldown;
		}
	}

	private IEnumerator DashCoroutine()
	{
		float timer = accelerationDuration;
		float initialVelocity = transform.InverseTransformDirection(rigidbody.velocity).z;

		while (timer > 0f)
		{
			Vector3 relativeToOwnAxisVelocity = transform.InverseTransformDirection(rigidbody.velocity);
			relativeToOwnAxisVelocity.z = Mathf.Lerp(force, initialVelocity, timer / accelerationDuration);
			rigidbody.velocity = transform.TransformDirection(relativeToOwnAxisVelocity);
			
			timer -= Time.deltaTime;
			yield return null;
		}

		timer = maxSpeedDuration;

		while (timer > 0f)
		{
			Vector3 relativeToOwnAxisVelocity = transform.InverseTransformDirection(rigidbody.velocity);
			relativeToOwnAxisVelocity.z = force;
			rigidbody.velocity = transform.TransformDirection(relativeToOwnAxisVelocity);

			timer -= Time.deltaTime;
			yield return null;
		}

		Vector3 relativeToOwnAxisVelocityLast = transform.InverseTransformDirection(rigidbody.velocity);
		relativeToOwnAxisVelocityLast.z = force/2f;
		rigidbody.velocity = transform.TransformDirection(relativeToOwnAxisVelocityLast);
	}
}
