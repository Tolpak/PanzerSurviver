using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPanzer", menuName = "ScriptableObjects/New Panzer", order = 1)]
public class PlayerDataTemplate : ScriptableObject
{
	[SerializeField] private PlayerModel model;
	public PlayerModel PlayerModel => model;
}
