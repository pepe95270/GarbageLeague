using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public enum GameState { PlayerActivation, Gameplay, GameOver };
	public GameState currentGameState;

	public StartingZone startingZone;
	public float readyTime;

	[HideInInspector]
	public float readyTimer;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	private void Start()
	{
		currentGameState = GameState.PlayerActivation;
		StartCoroutine(WaitForPlayersToBeReadyAndLaunchGame());
	}

	private IEnumerator WaitForPlayersToBeReadyAndLaunchGame()
	{
		readyTimer = readyTime;
		while (readyTimer > 0f) //this should only be false once we break out off the second loop because the timer has run out
		{
			if (startingZone.GetNumberOfPlayersInTheZone() == PlayerManager.Instance.GetNumberOfPlayers())
			{
				readyTimer = readyTime;
				while (startingZone.GetNumberOfPlayersInTheZone() == PlayerManager.Instance.GetNumberOfPlayers() && readyTimer > 0f)
				{
					Debug.Log("start in: " + readyTimer);
					readyTimer -= Time.deltaTime;
					yield return null;
				}
			}
			yield return null;
		}

		currentGameState = GameState.Gameplay;
	}
}