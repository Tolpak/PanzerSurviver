using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCharacter : Character
{
	public event Action OnDead;
	private NavMeshAgent navMeshAgent;
	public int Damage { get; private set; }

	private void Awake()
	{
		var enemyModel = EnemyManager.Instance.GetRandomEnemyModel();
		CharacterModel = enemyModel;
		CurrentHealth = enemyModel.Health;
		Damage = enemyModel.Damage;
		SpriteRenderer.sprite = enemyModel.Sprite;

		navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
		navMeshAgent.updateRotation = false;
		navMeshAgent.updateUpAxis = false;
		navMeshAgent.speed = CharacterModel.Movespeed;
	}

	public void SetDestination(Vector3 destination)
	{
		navMeshAgent.SetDestination(destination);
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		var bullet = collision.GetComponent<Bullet>();
		if (bullet)
		{
			TakeDamage(bullet.weaponData.ProjectileDamage);
		}
		else if(collision.GetComponent<PlayerCharacter>() != null)
		{
			OnDeath();
		}
	}

	protected override void OnDeath()
	{
		OnDead?.Invoke();
		Destroy(gameObject);
	}
}
