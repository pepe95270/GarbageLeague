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

	public Color GetColor()
	{
		switch (trashType)
		{
			case TrashType.Green:
				return new Color(0, 255, 0, 255);
			case TrashType.Blue:
				return new Color(0, 0, 255, 255);
			case TrashType.Yellow:
				return new Color(255, 255, 0, 255);
			case TrashType.White:
			default:
				return new Color(255, 255, 255, 255);
		}
	}
}
