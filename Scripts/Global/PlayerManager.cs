using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager Instance;

	public int maxPlayerNumber = 4; //this number is dictated by the number of inputs set in the project settings
	public GameObject playerPrefab;
	public List<Color> playerColors;
	public List<CarUserControl> userControlList;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	public int GetNumberOfPlayers()
	{
		return userControlList.Count;
	}
	
	private void FixedUpdate()
	{
		int iMax = maxPlayerNumber;
		for (int i = 0; i < maxPlayerNumber; i++)
		{
			//we only allow spawning new players during player Activation phase
			if (GameManager.instance.currentGameState != GameManager.GameState.PlayerActivation)
			{
				return;
			}

			int playerNumber = i + 1;
			if (userControlList.FindIndex(x => x.playerNumber == playerNumber) == -1 && CrossPlatformInputManager.GetAxis("TurboDashP" + playerNumber) > 0.5f)
			{
				GameObject instantiated = Instantiate(playerPrefab);
				CarUserControl carUserControl = instantiated.GetComponent<CarUserControl>();
				carUserControl.playerNumber = playerNumber;
				foreach(Renderer renderer in carUserControl.renderers)
				{
					renderer.material.color = playerColors[i];
				}
				userControlList.Add(carUserControl);
			}
		}
	}
}
