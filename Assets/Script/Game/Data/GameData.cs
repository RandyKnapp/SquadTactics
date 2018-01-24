using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal static class NameRandomizer
{
	private static System.Random _random = new System.Random();

	private static readonly string[] RandomFirstNames =
	{
		"John", "Jacob", "Frank", "Joe", "Steve", "Marty", "Guy", "Max"
	};

	private static readonly string[] RandomLastNames =
	{
		"Duderson", "McBadass", "Hero", "Force", "Gasoline", "Explosion"
	};

	public static int GetRandInt(int min, int max)
	{
		return _random.Next(min, max);
	}

	public static string GetFirstName()
	{
		int index = GetRandInt(0, RandomFirstNames.Length);
		return RandomFirstNames[index];
	}

	public static string GetLastName()
	{
		int index = GetRandInt(0, RandomLastNames.Length);
		return RandomLastNames[index];
	}
}

[Serializable]
public class Roster
{
	public List<CharacterData> Soldiers = new List<CharacterData>();
	public List<CharacterData> Scientists = new List<CharacterData>();
	public List<CharacterData> Engineers = new List<CharacterData>();
	public List<CharacterData> Leaders = new List<CharacterData>();
}

[Serializable]
public class GameData
{
	[SerializeField]
	private int _coins;

	[SerializeField]
	private int _gems;

	[SerializeField]
	private Roster _roster = new Roster();

	[NonSerialized]
	public Action OnDataChanged = delegate { };

	public GameData()
	{
		Reset();
	}

	public int Coins
	{
		get { return _coins; }
		set
		{
			_coins = value;
			OnDataChanged();
		}
	}

	public int Gems
	{
		get { return _gems; }
		set
		{
			_gems = value;
			OnDataChanged();
		}
	}

	public Roster Roster
	{
		get { return _roster; }
	}

	private void AddStartingSoldier()
	{
		var character = new CharacterData
		{
			Type = CharacterType.Soldier
			, FirstName = NameRandomizer.GetFirstName()
			, LastName = NameRandomizer.GetLastName()
			, Body = (BodyType) NameRandomizer.GetRandInt(0, Enum.GetNames(typeof(BodyType)).Length)
			, Color = (UniformColor) NameRandomizer.GetRandInt(0, Enum.GetNames(typeof(UniformColor)).Length)
		};
		_roster.Soldiers.Add(character);
	}

	private void AddStartingScientist()
	{
		var character = new CharacterData
		{
			Type = CharacterType.Scientist
			, FirstName = "Susan"
			, LastName = "McScience"
		};
		_roster.Scientists.Add(character);
	}
	
	private void AddStartingEngineer()
	{
		var character = new CharacterData
		{
			Type = CharacterType.Engineer
			, FirstName = "Dwayne"
			, LastName = "Erector"
		};
		_roster.Engineers.Add(character);
	}
	
	private void AddStartingLeader()
	{
		var character = new CharacterData
		{
			Type = CharacterType.Leader
			, FirstName = "General"
			, LastName = "Serious"
		};
		_roster.Leaders.Add(character);
	}

	public void Reset()
	{
		_coins = 100;
		_gems = 0;
		_roster = new Roster();
		for (int i = 0; i < 12; i++)
		{
			AddStartingSoldier();
		}
		AddStartingScientist();
		AddStartingEngineer();
		AddStartingLeader();

		OnDataChanged();
	}
}
