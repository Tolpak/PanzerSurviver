using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	public WeaponData weaponData { get; private set; }

	public void InitBullet(WeaponData weaponData)
	{
		this.weaponData = weaponData;
		spriteRenderer.color = weaponData.ProjectileColor;
	}

	private void Update()
	{
		transform.position += Time.deltaTime * weaponData.ProjectileSpeed * transform.up;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(gameObject);
	}
}
