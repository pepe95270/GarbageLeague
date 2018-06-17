using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {


    public GameObject powerUpPrefab;
    public GameObject powerUpContainer;
    public List<Vector2> spawnLocalPositionList;
    public static List<bool> isAlreadyPickUpList;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnPowerUp", 5f, 5f);
        isAlreadyPickUpList = new List<bool>(spawnLocalPositionList.Count);
        for (int i = 0; i < spawnLocalPositionList.Count; i++)
        {
            isAlreadyPickUpList.Add(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPowerUp()
    {
        if (GameManager.instance.currentGameState == GameManager.GameState.Gameplay)
        {
            for(int i = 0; i<spawnLocalPositionList.Count; i++)
            {
                if(isAlreadyPickUpList[i])
                {
                    isAlreadyPickUpList[i] = false;
                    GameObject newPowerUp = Instantiate(powerUpPrefab, powerUpContainer.transform, true);
                    newPowerUp.transform.localPosition = new Vector3(spawnLocalPositionList[i].x, 0f, spawnLocalPositionList[i].y);
                    newPowerUp.GetComponent<PowerUpObject>().id = i;
                    newPowerUp.GetComponent<PowerUpObject>().Initialize(new Missile());
                }
            }
        }
    }
}
