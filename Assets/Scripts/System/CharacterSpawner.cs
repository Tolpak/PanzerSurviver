using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CharacterSpawner
{
	private const string PlayerPrefabAddress = "PlayerPrefab";
	private const string EnemyPrefabAddress = "EnemyPrefab";
	private const string SpawnSettingsAddress = "SpawnSettings";

	private PlayerCharacter player;
	private List<EnemyCharacter> enemies = new List<EnemyCharacter>();
	private SpawnSettings spawnSettings;
	private float spawnTimer = 0;
	private Camera mainCamera;
	public int EnemyAmount => enemies.Count;

	public CharacterSpawner()
	{
		mainCamera = Camera.main;
		player = Addressables.InstantiateAsync(PlayerPrefabAddress).WaitForCompletion().GetComponent<PlayerCharacter>();
		spawnSettings = Addressables.LoadAssetAsync<SpawnSettings>(SpawnSettingsAddress).WaitForCompletion();
	}

	private void SpawnEnemy()
	{
		var enemy = Addressables.InstantiateAsync(EnemyPrefabAddress, GeneratePosition(), Quaternion.identity).WaitForCompletion().GetComponent<EnemyCharacter>();
		enemy.OnDead += () => enemies.Remove(enemy);
		enemies.Add(enemy);
	}

	public void OnUpdate()
	{
		spawnTimer += Time.deltaTime;
		if (spawnSettings.SpawnCooldown < spawnTimer && EnemyAmount < spawnSettings.MaxEnemies)
		{
			spawnTimer = 0;
			SpawnEnemy();
		}

		foreach (var enemy in enemies)
		{
			enemy.SetDestination(player.transform.position);
		}
	}

	private Vector3 GeneratePosition()
	{
		return mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0, 2), Random.Range(0, 2), mainCamera.nearClipPlane));
	}
}
