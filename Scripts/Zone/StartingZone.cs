using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class StartingZone : MonoBehaviour
{
	public List<CarUserControl> playerUserControlInside;

	public int GetNumberOfPlayersInTheZone()
	{
		return playerUserControlInside.Count;
	}

	private void Awake()
	{
		playerUserControlInside = new List<CarUserControl>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			CarUserControl userControl = other.GetComponentInParent<CarUserControl>();
			if (playerUserControlInside.FindIndex(x => x.playerNumber == userControl.playerNumber) == -1)
			{
				playerUserControlInside.Add(userControl);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			CarUserControl userControl = other.GetComponentInParent<CarUserControl>();
			if (playerUserControlInside.FindIndex(x => x.playerNumber == userControl.playerNumber) != -1)
			{
				playerUserControlInside.Remove(userControl);
			}
		}
	}
}
