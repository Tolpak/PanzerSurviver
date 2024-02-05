using System;
using UnityEngine;

[Serializable]
public class WeaponData
{
	[SerializeField] private Color projectileColor;
	[SerializeField] private float projectileSpeed;
	[SerializeField] private int projectileDamage;
	public Color ProjectileColor => projectileColor;
	public float ProjectileSpeed => projectileSpeed;
	public int ProjectileDamage => projectileDamage;
}
