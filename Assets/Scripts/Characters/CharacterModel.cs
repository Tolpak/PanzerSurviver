using System;
using UnityEngine;

[Serializable]
public class CharacterModel
{
	[SerializeField] private int health;
	[SerializeField] private float armor;
	[SerializeField] private float movespeed;
	[SerializeField] private Sprite sprite;
	public int Health => health;
	public float Armor => armor;
	public float Movespeed => movespeed;
	public Sprite Sprite => sprite;
}
