using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RosterContentController : MonoBehaviour
{
	[SerializeField]
	private Button _soldiersButton;
	[SerializeField]
	private ScrollRect _scrollView;
	[SerializeField]
	private Text _subtitleText;
	[SerializeField]
	private Text _countText;
	[SerializeField]
	private GameObject _soldierTilePrefab;

	private void Awake()
	{
		var gameData = GameDataManager.GetGameData();

		_subtitleText.text = "Soldiers";
		_countText.text = gameData.Roster.Soldiers.Count.ToString();

		foreach (var soldierData in gameData.Roster.Soldiers)
		{
			CharacterTileController soldierTile = Instantiate(_soldierTilePrefab).GetComponent<CharacterTileController>();
			soldierTile.SetData(soldierData);
			
			soldierTile.transform.SetParent(_scrollView.content, false);
		}
	}
}
