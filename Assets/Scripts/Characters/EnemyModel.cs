using UnityEngine;

[System.Serializable]
public class EnemyModel : CharacterModel
{
	[SerializeField] private int damage;
	public int Damage => damage;
}
