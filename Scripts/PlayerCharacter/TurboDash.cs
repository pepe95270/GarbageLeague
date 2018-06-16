using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

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
		GetComponent<CarController>().MaxSpeed = GetComponent<CarController>().MaxSpeed + 40f;

		float timer = accelerationDuration;
		float initialVelocity = transform.InverseTransformDirection(rigidbody.velocity).z;
		float maxSpeed = Mathf.Max(force, initialVelocity + 40);

		while (timer > 0f)
		{
			Vector3 relativeToOwnAxisVelocity = transform.InverseTransformDirection(rigidbody.velocity);
			relativeToOwnAxisVelocity.z = Mathf.Lerp(maxSpeed, initialVelocity, timer / accelerationDuration);
			rigidbody.velocity = transform.TransformDirection(relativeToOwnAxisVelocity);
			
			timer -= Time.deltaTime;
			yield return null;
		}

		timer = maxSpeedDuration;

		while (timer > 0f)
		{
			Vector3 relativeToOwnAxisVelocity = transform.InverseTransformDirection(rigidbody.velocity);
			relativeToOwnAxisVelocity.z = maxSpeed;
			rigidbody.velocity = transform.TransformDirection(relativeToOwnAxisVelocity);

			timer -= Time.deltaTime;
			yield return null;
		}

		Vector3 relativeToOwnAxisVelocityLast = transform.InverseTransformDirection(rigidbody.velocity);
		relativeToOwnAxisVelocityLast.z = (maxSpeed + initialVelocity) /2f;
		rigidbody.velocity = transform.TransformDirection(relativeToOwnAxisVelocityLast);
		
		GetComponent<CarController>().MaxSpeed = GetComponent<CarController>().MaxSpeed - 40f;
	}
}
