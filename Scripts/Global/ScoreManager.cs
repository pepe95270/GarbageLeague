using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
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
				victoryAchieved = true;
				Time.timeScale = 0.05f;
				DisplayVictory(playerNumber);
				return;
			}
		}
	}
	
	//for now we only destroy the other players
	private void DisplayVictory(int winnerPlayerNumber)
	{
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
