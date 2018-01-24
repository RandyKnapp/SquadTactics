using System;

[Serializable]
public enum BodyType
{
	Infantry,
	Scout,
	Sniper,
	Gunner
}

[Serializable]
public enum UniformColor
{
	Blue,
	Red,
	Green,
	Yellow,
	Black,
	Gray
}

[Serializable]
public enum Weapon
{
	AssaultRifle,
	Shotgun,
	SMG,
	SniperRifle,
	MachineGun,
	RocketLauncher,
	Pistol,
	Knife
}

[Serializable]
public enum CharacterType
{
	Soldier,
	Scientist,
	Engineer,
	Leader
}

[Serializable]
public struct CharacterData
{
	public CharacterType Type;
	public string FirstName;
	public string LastName;
	public BodyType Body;
	public UniformColor Color;
	public Weapon Weapon;
}
