using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
	public float minRateSpawn;
	public float maxRateSpawn;
    public int maxObjectMinusNumberOfPlayer;
    public GameObject ground;
    public GameObject bin;
    public GameObject trashPrefab;
    public GameObject trashContainer;
    public GameObject zones;

    public static List<GameObject> trashesInMap;

	private float timeUntilNextSpawn;

    public void Start()
    {
        trashesInMap = new List<GameObject>();
    }

    private void InitializeNextTrash()
    {
		Vector3 spawnPosition;
		while (!GetRandomSpawnPosition(out spawnPosition)) { }
		GameObject newTrash = Instantiate(trashPrefab, trashContainer.transform, true);
        trashesInMap.Add(newTrash);
		newTrash.transform.Translate(spawnPosition);
		TrashType randomType = (TrashType)Random.Range(0, 4);
		newTrash.GetComponent<TrashObject>().Initialize(new TrashInfo(randomType));
	}

	private bool GetRandomSpawnPosition(out Vector3 spawnPosition)
	{
		spawnPosition = Vector3.zero;
        
        Bounds combinedBounds = new Bounds();
        var renderers = zones.GetComponentsInChildren<Renderer>();
        foreach (Renderer render in renderers)
        {
            if (render != zones.GetComponent<Renderer>()) combinedBounds.Encapsulate(render.bounds);
        }

        Vector3 v = combinedBounds.size * 0.9f;
		float l = v.x;
		float L = v.z;
		float lr = Random.Range(1, l - 0.001f);
		float Lr = Random.Range(1, L - 0.001f);
		if (lr < bin.GetComponent<Renderer>().bounds.size.x)
		{
			if (!(Lr < bin.GetComponent<Renderer>().bounds.size.z || Lr > L - bin.GetComponent<Renderer>().bounds.size.z))
			{
				spawnPosition = new Vector3(lr, 0, Lr) - new Vector3(l / 2, 0, L / 2);
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (lr > l - bin.GetComponent<Renderer>().bounds.size.x)
		{
			if (!(Lr < bin.GetComponent<Renderer>().bounds.size.z || Lr > L - bin.GetComponent<Renderer>().bounds.size.z))
			{
				spawnPosition = new Vector3(lr, 0, Lr) - new Vector3(l / 2, 0, L / 2);
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			spawnPosition = new Vector3(lr, 0, Lr) - new Vector3(l / 2, 0, L / 2);
			return true;
		}
	}

    void Update()
	{
		if (GameManager.instance.currentGameState != GameManager.GameState.Gameplay)
		{
			return;
		}

		if (timeUntilNextSpawn <= 0f && trashesInMap.Count < maxObjectMinusNumberOfPlayer + PlayerManager.Instance.GetNumberOfPlayers())
		{
			InitializeNextTrash();
			timeUntilNextSpawn = (Random.Range(minRateSpawn, maxRateSpawn) / PlayerManager.Instance.GetNumberOfPlayers());
		}
		else
		{
			timeUntilNextSpawn -= Time.deltaTime;
		}
	}
}
