using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : PowerUp
{
	public GameObject prefabProjectile;

	public Missile(GameObject prefabProjectile)
	{

	}

	public override void Activate(CarPower caller)
	{
		//we instantiate a projectile in front of the car, the projectile goes at constant speed in a direction
	}
}
