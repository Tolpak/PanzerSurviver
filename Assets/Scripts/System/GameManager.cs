using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CharacterSpawner spawnManager;

    void Awake()
    {
        var levelLoader = new LevelLoader();
        var enemyLoader = EnemyManager.Instance;
        spawnManager = new CharacterSpawner();
    }

	private void Update()
	{
        spawnManager.OnUpdate();
    }
}
