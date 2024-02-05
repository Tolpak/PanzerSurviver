using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "ScriptableObjects/New Enemy", order = 2)]
public class EnemyDataTemplate : ScriptableObject
{
	[SerializeField] private EnemyModel model;
	public EnemyModel EnemyModel => model;
}
