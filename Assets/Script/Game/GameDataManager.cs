using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class GameDataManager
{
	private static GameData _currentGame;

	public static GameData GetGameData()
	{
		if (_currentGame == null)
		{
			if (SaveDataExists())
			{
				Load();
			}
			else
			{
				_currentGame = new GameData();
				Save();
			}
		}

		return _currentGame;
	}

	private static bool SaveDataExists()
	{
		return File.Exists(GetSaveFileName());
	}

	public static void Save()
	{
		var bf = new BinaryFormatter();
		FileStream fs = File.Create(GetSaveFileName());
		bf.Serialize(fs, _currentGame);
		fs.Close();
	}

	public static void Load()
	{
		if (!SaveDataExists())
		{
			return;
		}
		
		var bf = new BinaryFormatter();
		FileStream fs = File.Open(GetSaveFileName(), FileMode.Open);
		_currentGame = (GameData)bf.Deserialize(fs);
		fs.Close();
	}

	private static string GetSaveFileName()
	{
		return Application.persistentDataPath + "/save.sav";
	}

	public static void Reset()
	{
		if (_currentGame == null)
		{
			_currentGame = new GameData();
		}
		_currentGame.Reset();
		Save();
	}
}
