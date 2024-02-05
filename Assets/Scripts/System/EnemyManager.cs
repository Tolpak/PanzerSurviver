using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public sealed class EnemyManager
{
	private const string EnemiesDataAddress = "Enemies";

	private static EnemyManager instance;
	public AssetReference AssetReference;
	public static EnemyManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new EnemyManager();
			}
			return instance;
		}
	}

	private IList<EnemyDataTemplate> enemiesData;

	private EnemyManager()
	{
		enemiesData = Addressables.LoadAssetsAsync<EnemyDataTemplate>(EnemiesDataAddress, null).WaitForCompletion();
	}

	public EnemyModel GetRandomEnemyModel()
	{
		return enemiesData[Random.Range(0, enemiesData.Count)].EnemyModel;
	}
}
