using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class TrashInventory : MonoBehaviour
{
	public List<Renderer> ringRenderers;
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
			trashObject.pickedUpAlready = true;
			trashInfoList.Add(new TrashInfo(trashObject.trashInfo));
			Destroy(trashObject.gameObject);
		}
	}

    public void ResetInventory()
    {
        trashInfoList.Clear();
    }

	void Start()
	{
		trashInfoList = new List<TrashInfo>();
	}

	void Update()
	{
		int iMax = trashInfoList.Count;
		for (int i = 0; i < iMax; i++)
		{
			ringRenderers[i].material.color = trashInfoList[i].GetColor();
		}
		for (int i = iMax; i < ringRenderers.Count; i++)
		{
			ringRenderers[i].material.color = Color.gray;
		}
		if (Debug.isDebugBuild
			&& this.GetComponent<CarUserControl>().playerNumber == 1
			&& Input.GetKeyDown(KeyCode.I))
		{
			iMax = trashInfoList.Count;
			string log = "trash count: " + iMax;
			for (int i = 0; i < iMax; i++)
			{
				log += "\n\t" + trashInfoList[i].trashType.ToString();
			}
			Debug.Log(log);
		}
	}
}
