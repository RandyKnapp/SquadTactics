using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public enum CurrencyType
{
	Coins,
	Gems
}

public class CurrencyController : MonoBehaviour
{
	[SerializeField]
	private Text _textField;
	[SerializeField]
	private CurrencyType _type;

	private void Awake()
	{
		GameDataManager.GetGameData().OnDataChanged += OnGameDataChanged;
		RefreshText();
	}

	private void OnGameDataChanged()
	{
		RefreshText();
	}

	private void RefreshText()
	{
		int value = 0;
		switch (_type)
		{
			case CurrencyType.Coins:
				value = GameDataManager.GetGameData().Coins;
				break;
			case CurrencyType.Gems:
				value = GameDataManager.GetGameData().Gems;
				break;
		}
		
		IFormatProvider iFormatProvider = new System.Globalization.CultureInfo("en-US");
		_textField.text = value.ToString("#,##0", iFormatProvider);
	}
}
