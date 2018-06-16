using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPower : MonoBehaviour
{
	public bool hasPower = false;
	public PowerUp powerUp;

	public bool TryEquipPowerUp(PowerUpObject powerUpObject)
	{
		if (!hasPower)
		{
			this.powerUp = powerUpObject.powerUp;
			hasPower = true;
			Destroy(powerUpObject.gameObject);
			return true;
		}
		else
		{
			return false;
		}
	}

	public void UsePowerUp()
	{
		if (hasPower)
		{
			powerUp.Activate(this);
		}
	}
}
