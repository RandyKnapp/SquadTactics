using System;

// The author notes that gender exists on a spectrum in real-life, but for the purposes of this game,
//   the characters present as either male or female.
[Serializable]
public enum GenderType
{
	Male,
	Female
}

[Serializable]
public class CharacterData
{
	public GenderType Gender;
	public string FirstName;
	public string LastName;
	public string Class;
}
