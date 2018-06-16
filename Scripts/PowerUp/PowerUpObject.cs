using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObject : MonoBehaviour
{
	public PowerUp powerUp;
	private bool hasBeenPickedUp = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player") && !hasBeenPickedUp)
		{
			CarPower otherCarPower = other.GetComponentInParent<CarPower>();
			hasBeenPickedUp = otherCarPower.TryEquipPowerUp(this);
		}
	}
}
