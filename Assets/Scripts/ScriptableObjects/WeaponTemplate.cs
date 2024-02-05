using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/New Weapon", order = 4)]
public class WeaponTemplate : ScriptableObject
{
	public WeaponData weaponData;
}
