using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TrashType { Green, Yellow, Blue, White }

public class TrashInfo
{
	public TrashType trashType;

	public TrashInfo(TrashType trashType)
	{
		this.trashType = trashType;
	}

	public TrashInfo(TrashInfo trashInfo)
	{
		this.trashType = trashInfo.trashType;
	}
}
