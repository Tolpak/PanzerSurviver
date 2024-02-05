using UnityEngine;
using UnityEngine.AddressableAssets;

public sealed class LevelLoader
{
	private static LevelLoader instance;
	public static LevelLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new LevelLoader();
			}
			return instance;
		}
	}

	private const string LevelFolderName = "Assets/Prefabs/Levels/Level";
	private int currentLevel = 0;
	private GameObject currentMap;
	public LevelLoader()
	{
		LoadNextLevel();
	}

	public void LoadNextLevel()
	{
		currentLevel++;
		Addressables.Release(currentMap);
		currentMap = Addressables.InstantiateAsync(LevelFolderName + currentLevel + ".prefab").WaitForCompletion();
	}
}
