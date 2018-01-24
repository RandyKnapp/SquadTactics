using System;
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
	[SerializeField]
	private Button _setupPortraitsButton;

	private void Awake()
	{
		_resetGameDataButton.onClick.AddListener(OnResetGameData);
		_add100CoinsButton.onClick.AddListener(OnAddCoins);
		_add100GemsButton.onClick.AddListener(OnAddGems);
		_setupPortraitsButton.onClick.AddListener(OnSetupPortraits);
	}

	private void OnResetGameData()
	{
		GameDataManager.Reset();
	}
	
	private void OnAddCoins()
	{
		GameDataManager.GetGameData().Coins += 100;
		GameDataManager.Save();
	}

	private void OnAddGems()
	{
		GameDataManager.GetGameData().Gems += 100;
		GameDataManager.Save();
	}
	
	private void OnSetupPortraits()
	{
		const int width = 256;
		const int height = 256;
		Camera portraitCamera = GameObject.Find("PortraitCamera").GetComponent<Camera>();
		SoldierController soldierDummy = GameObject.FindGameObjectWithTag("SoldierDummy").GetComponent<SoldierController>();

		var portraitPath = Application.persistentDataPath + "/portraits/";
		foreach (BodyType bodyIndex in Enum.GetValues(typeof(BodyType)))
		{
			foreach (UniformColor colorIndex in Enum.GetValues(typeof(UniformColor)))
			{
				var portraitFilename = portraitPath + "portrait" + bodyIndex + colorIndex + ".png";
				
				soldierDummy.SetData(new CharacterData { Body = bodyIndex, Color = colorIndex });
				
				RenderTexture rt = new RenderTexture(width, height, 32);
				RenderTexture.active = rt;
				portraitCamera.targetTexture = rt;
				Texture2D screenshot = new Texture2D(width, height, TextureFormat.ARGB32, false);
				portraitCamera.Render();
				screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
				portraitCamera.targetTexture = null;
				RenderTexture.active = null;
				Destroy(rt);
				byte[] bytes = screenshot.EncodeToPNG();
				System.IO.File.WriteAllBytes(portraitFilename, bytes);
			}
		}
	}
}
