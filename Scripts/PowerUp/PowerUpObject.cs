using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObject : MonoBehaviour
{
	public PowerUp powerUp;
    [HideInInspector]
    public int id;
    private bool hasBeenPickedUp = false;

    public void Initialize(PowerUp powerUp)
    {
        this.powerUp = powerUp;
        Instantiate(PrefabManager.Instance.prefabMissileDesign, transform);
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player") && !hasBeenPickedUp)
		{
			PowerInventory otherPowerInventory = other.GetComponentInParent<PowerInventory>();
			hasBeenPickedUp = otherPowerInventory.TryEquipPowerUp(this);
		}
	}
}
