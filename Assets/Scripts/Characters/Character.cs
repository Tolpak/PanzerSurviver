using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
	protected int CurrentHealth;
	[SerializeField] protected SpriteRenderer SpriteRenderer;
	public CharacterModel CharacterModel { get; protected set; }

	protected void TakeDamage(int damage)
	{
		CurrentHealth = CurrentHealth - (int)(damage * CharacterModel.Armor);
		if (CurrentHealth <= 0)
		{
			OnDeath();
		}
	}

	protected virtual void OnDeath()
	{

	}
}
