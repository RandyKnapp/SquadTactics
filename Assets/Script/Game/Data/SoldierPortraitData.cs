using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
internal struct PortraitList
{
	public List<Sprite> Portraits;
}

public class SoldierPortraitData : ScriptableObject
{
	[SerializeField]
	private List<PortraitList> _portraits= new List<PortraitList>();
	[SerializeField]
	private Sprite _scientistPortrait;
	[SerializeField]
	private Sprite _engineerPortrait;
	[SerializeField]
	private Sprite _leaderPortrait;

	[MenuItem("Assets/Create/SoldierPortraitData")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<SoldierPortraitData>();
	}

	public Sprite GetPortrait(CharacterData data)
	{
		if (data.Type == CharacterType.Soldier)
		{
			var bodyIndex = (int)data.Body;
			var colorIndex = (int)data.Color;

			if (bodyIndex < _portraits.Count)
			{
				PortraitList list = _portraits[bodyIndex];
				if (colorIndex < list.Portraits.Count)
				{
					return list.Portraits[colorIndex];
				}
			}
		}
		else
		{
			switch (data.Type)
			{
				case CharacterType.Scientist: return _scientistPortrait;
				case CharacterType.Engineer: return _engineerPortrait;
				case CharacterType.Leader: return _leaderPortrait;
			}
		}

		return new Sprite();
	}
}
