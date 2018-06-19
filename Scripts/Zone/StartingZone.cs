using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class StartingZone : MonoBehaviour
{
	public List<CarUserControl> playerUserControlInside;
	public float timeToWin;
	public Countdown countdown;
	private Coroutine winCoroutine;
	private int playerWinning = 0;

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
			if (GameManager.instance.currentGameState == GameManager.GameState.Gameplay)
			{
				TrashInventory trashInventory = other.GetComponentInParent<TrashInventory>();
				if (trashInventory.trashInfoList.FindIndex(x => x.trashType == TrashType.Unicorn) != -1 && playerWinning == 0)
				{
					countdown.countdownUI.gameObject.SetActive(true);
					playerWinning = userControl.playerNumber;
					winCoroutine = StartCoroutine(WinCoroutine());
				}
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
			if (GameManager.instance.currentGameState == GameManager.GameState.Gameplay)
			{
				TrashInventory trashInventory = other.GetComponentInParent<TrashInventory>();
				if (trashInventory.trashInfoList.FindIndex(x => x.trashType == TrashType.Unicorn) != -1 && playerWinning != 0)
				{
					countdown.countdownUI.gameObject.SetActive(false);
					playerWinning = 0;
					StopCoroutine(winCoroutine);
				}
			}
		}
	}

	private IEnumerator WinCoroutine()
	{
		float timer = timeToWin;
		while (timer > 0f)
		{
			if(PlayerManager.Instance.userControlList[playerWinning - 1].GetComponent<TrashInventory>().trashInfoList.FindIndex(x => x.trashType == TrashType.Unicorn) == -1)
			{
				countdown.countdownUI.gameObject.SetActive(false);
				playerWinning = 0;
				yield break;
			}
			timer -= Time.deltaTime;
			TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
			countdown.countdownUI.text = String.Format("{0:00}:{1:00}", timeSpan.Seconds, Mathf.Floor(timeSpan.Milliseconds / 10f));
			countdown.countdownUI.color = Color.magenta;
			yield return null;
		}

		if (timer <= 0f)
		{
			PlayerManager.Instance.userControlList[playerWinning - 1].GetComponent<Score>().score += PlayerManager.Instance.GetNumberOfPlayers();
			List<int> maxScorePlayers = new List<int> { 1 };
			int maxScore = PlayerManager.Instance.userControlList[0].GetComponent<Score>().score;
			for (int i = 1; i < PlayerManager.Instance.GetNumberOfPlayers(); i++)
			{
				int currentScore = PlayerManager.Instance.userControlList[i].GetComponent<Score>().score;
				if (currentScore > maxScore)
				{
					maxScore = currentScore;
					maxScorePlayers.Clear();
				}
				if (currentScore >= maxScore)
				{
					maxScorePlayers.Add(i + 1);
				}
			}
			Time.timeScale = 0.1f;
			if (maxScorePlayers.Count == 1)
			{
				countdown.countdownUI.text = "Player " + maxScorePlayers[0] + " won!";
			}
			else
			{
				string result = "It's a tie between players ";
				result += maxScorePlayers[0];
				for (int i = 1; i < maxScorePlayers.Count - 1; i++)
				{
					result += ", " + maxScorePlayers[i];
				}
				result += " and " + maxScorePlayers[maxScorePlayers.Count - 1];
				countdown.countdownUI.text = result;
			}
		}
	}
}
