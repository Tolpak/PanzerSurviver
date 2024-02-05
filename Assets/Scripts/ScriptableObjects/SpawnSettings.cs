using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnerSettings", menuName = "ScriptableObjects/Spawner Settings", order = 3)]
public class SpawnSettings : ScriptableObject
{
	[SerializeField] private float spawnCooldown;
	[SerializeField] private int maxEnemies;
	public float SpawnCooldown => spawnCooldown;
	public int MaxEnemies => maxEnemies;

}
