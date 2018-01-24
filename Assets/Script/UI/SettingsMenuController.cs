using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
	[SerializeField]
	private Button _resetGameDataButton;
	[SerializeField]
	private Button _add100CoinsButton;
	[SerializeField]
	private Button _add100GemsButton;

	private void Awake()
	{
		_resetGameDataButton.onClick.AddListener(OnResetGameData);
		_add100CoinsButton.onClick.AddListener(OnAddCoins);
		_add100GemsButton.onClick.AddListener(OnAddGems);
	}

	private void OnResetGameData()
	{
		GameDataManager.Reset();
	}
	
	private void OnAddCoins()
	{
		GameDataManager.GetGameData().Coins += 100;
	}

	private void OnAddGems()
	{
		GameDataManager.GetGameData().Gems += 100;
	}
}
