using System;

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
public class CharacterData
{
	public string FirstName;
	public string LastName;
	public string Class;
}
