using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
	public GameObject parent;
	public List<Text> scoreTexts;
	public List<Text> playerTexts;
	
	void Update()
	{
		if (GameManager.instance.currentGameState == GameManager.GameState.PlayerActivation)
		{
			parent.SetActive(false);
		}
		else
		{
			parent.SetActive(true);
		}
		if (GameManager.instance.currentGameState == GameManager.GameState.GameOver)
		{
			return;
		}
		int iMax = PlayerManager.Instance.GetNumberOfPlayers();
		for (int i = 0; i < iMax; i++)
		{
			scoreTexts[i].gameObject.SetActive(true);
			playerTexts[i].gameObject.SetActive(true);
			scoreTexts[i].text = PlayerManager.Instance.userControlList[i].GetComponent<Score>().score.ToString();
		}
		for (int i = iMax; i < scoreTexts.Count; i++)
		{
			scoreTexts[i].gameObject.SetActive(false);
			playerTexts[i].gameObject.SetActive(false);
		}
	}
}
