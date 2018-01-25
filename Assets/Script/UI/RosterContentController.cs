using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RosterContentController : MonoBehaviour
{
	[SerializeField]
	private CharacterType _characterType;
	[SerializeField]
	private ScrollRect _scrollView;
	[SerializeField]
	private Text _subtitleText;
	[SerializeField]
	private Text _countText;
	[SerializeField]
	private GameObject _characterTilePrefab;

	private void Awake()
	{
		var characters = GetCharacterList();

		SetSubtitle();
		_countText.text = characters.Count.ToString();

		foreach (var characterData in characters)
		{
			CharacterTileController characterTile = Instantiate(_characterTilePrefab).GetComponent<CharacterTileController>();
			characterTile.SetCharacter(characterData);
			
			characterTile.transform.SetParent(_scrollView.content, false);
		}
	}

	private List<CharacterInstance> GetCharacterList()
	{
		var gameData = GameDataManager.GetGameData();
		
		switch (_characterType)
		{
			default:
			case CharacterType.Soldier:
				return gameData.Roster.Soldiers;
			case CharacterType.Scientist:
				return gameData.Roster.Scientists;
			case CharacterType.Engineer:
				return gameData.Roster.Engineers;
			case CharacterType.Leader:
				return gameData.Roster.Leaders;
		}
	}

	private void SetSubtitle()
	{
		_subtitleText.text = _characterType.ToString() + "s";
	}
}
