using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : PowerUp
{

	public override void Activate(PowerInventory caller)
	{
        //we instantiate a projectile in front of the car, the projectile goes at constant speed in a direction
        GameObject missile = GameObject.Instantiate(PrefabManager.Instance.prefabMissile);
        missile.GetComponent<MissileBehavior>().sender = caller.gameObject;
        missile.GetComponent<MissileBehavior>().Launch();

    }
}
