using UnityEngine;
using System.Collections;


public enum Skill{
	SwordFighting, UnarmedCombat, FireExplosives, Stealth
}

[System.Serializable]
public class Character : ScriptableObject {

	public Sprite Sprite;
	public string name;
	public string backstory; 
	public Skill skill; 
	public string skillValue; 
}
