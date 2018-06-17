using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerInventory : MonoBehaviour
{
	public int powerCountInInventory = 0;
	public PowerUp powerUp;

	public bool TryEquipPowerUp(PowerUpObject powerUpObject)
    {
        this.powerUp = powerUpObject.powerUp;
        powerCountInInventory++;
        PowerUpSpawner.isAlreadyPickUpList[powerUpObject.id] = true;
        Destroy(powerUpObject.gameObject);
        return true;
    }

	public void UsePowerUp()
	{
		if (powerCountInInventory > 0)
		{
            powerCountInInventory--;
			powerUp.Activate(this);
		}
	}
}
