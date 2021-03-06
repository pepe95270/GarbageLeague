﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour
{
	public TrashInfo trashInfo;
    public List<GameObject> prefabDefaultTrashList;
    public List<GameObject> prefabGlassTrashList;
    public List<GameObject> prefabPaperTrashList;
    public List<GameObject> prefabPlasticTrashList;
    [HideInInspector]public bool waitBeforeActive = false;
	[HideInInspector]
	public bool pickedUpAlready = false;
    

    public void ActiveWait()
    {
        waitBeforeActive = true;
    }

    public void DesactiveWait()
    {
        waitBeforeActive = false;
    }

	public void Initialize(TrashInfo trashInfo)
	{
		this.trashInfo = trashInfo;
        GetComponentInChildren<GlowingAura>().Initialize();
        if (trashInfo.trashType == TrashType.Green)
        {
            Instantiate(prefabGlassTrashList[Random.Range(0, prefabGlassTrashList.Count)], transform);
        }
        else if (trashInfo.trashType == TrashType.Blue)
        {
            Instantiate(prefabPaperTrashList[Random.Range(0, prefabPaperTrashList.Count)], transform);
        }
        else if (trashInfo.trashType == TrashType.Yellow)
        {
            Instantiate(prefabPlasticTrashList[Random.Range(0, prefabPlasticTrashList.Count)], transform);
        }
        else if (trashInfo.trashType == TrashType.White)
        {
            Instantiate(prefabDefaultTrashList[Random.Range(0, prefabDefaultTrashList.Count)], transform);
        }
    }

	void OnTriggerEnter(Collider other)
	{
        if (!waitBeforeActive)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player") && !pickedUpAlready)
            {
                TrashInventory otherTrashInventory = other.GetComponentInParent<TrashInventory>();
                otherTrashInventory.AddTrashObject(this);
            }
        }
	}

    public void CustomDestroy()
    {
        TrashSpawner.trashesInMap.Remove(gameObject);
        Destroy(gameObject);
    }
}
