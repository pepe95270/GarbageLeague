using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class TrashInventory : MonoBehaviour
{
	public List<TrashInfo> trashInfoList;
	public int maxTrashObjectCarried = 5;

	public bool IsFull()
	{
		return trashInfoList.Count >= maxTrashObjectCarried;
	}
	
	public void AddTrashObject(TrashObject trashObject)
	{
		if (!IsFull())
		{
			trashInfoList.Add(new TrashInfo(trashObject.trashInfo));
			Destroy(trashObject.gameObject);
		}
	}

	void Start()
	{
		trashInfoList = new List<TrashInfo>();
	}

	void Update()
	{
		if (Debug.isDebugBuild
			&& this.GetComponent<CarUserControl>().playerNumber == 1
			&& Input.GetKeyDown(KeyCode.I))
		{
			int iMax = trashInfoList.Count;
			string log = "trash count: " + iMax;
			for (int i = 0; i < iMax; i++)
			{
				log += "\n\t" + trashInfoList[i].trashType.ToString();
			}
			Debug.Log(log);
		}
	}
}
