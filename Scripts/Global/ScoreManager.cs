using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	//here, victory means that a unicorn will be instantiated, the game will end when the unicorn is brought back to a deposit zone
	public int victoryScore;
	private PlayerManager playerManager;

	private bool victoryAchieved = false;

	private void Awake()
	{
		playerManager = GetComponent<PlayerManager>();
	}

	private void Update()
	{
		if (victoryAchieved) return;
		int iMax = playerManager.userControlList.Count;
		for (int i = 0; i < iMax; i++)
		{
			int playerNumber = i + 1;
			if (playerManager.userControlList[i].GetComponent<Score>().score >= victoryScore)
			{
				//GameManager.instance.currentGameState = GameManager.GameState.GameOver;
				GameManager.instance.unicornReady = true;
				victoryAchieved = true;
				return;
			}
		}
	}
	
	//for now we only destroy the other players
	public void DisplayVictory(int winnerPlayerNumber)
	{
		Time.timeScale = 0.1f;
		int iMax = playerManager.userControlList.Count;
		for (int i = 0; i < iMax; i++)
		{
			int playerNumber = i + 1;
			if (playerNumber != winnerPlayerNumber)
			{
				Destroy(playerManager.userControlList[i].gameObject);
			}
		}
	}
}
