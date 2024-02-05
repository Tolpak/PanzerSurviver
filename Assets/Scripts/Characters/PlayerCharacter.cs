using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerCharacter : Character
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private PlayerDataTemplate panzerData;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform bulletStartLocation;

    private GameControls controls;

    private InputAction movementAction;
    private InputAction rotationAction;
    private InputAction shootAction;
    private InputAction nextWeapon;
    private InputAction previousWeapon;

    private int currentWeaponIndex;
    private IList<WeaponData> weaponList;

    private void Awake()
    {
        CharacterModel = panzerData.PlayerModel;
        weaponList = panzerData.PlayerModel.WeaponData.Select(x => x.weaponData).ToList();
        CurrentHealth = CharacterModel.Health;
        SpriteRenderer.sprite = panzerData.PlayerModel.Sprite;
        gameObject.AddComponent<BoxCollider2D>();
        InitControls();
    }

    private void Update()
    {
        transform.Translate(movementAction.ReadValue<float>() * movementSpeed * Time.deltaTime * Vector3.up);
        transform.Rotate(rotationAction.ReadValue<float>() * rotationSpeed * Time.deltaTime * Vector3.forward);
    }

    private void InitControls()
    {
        controls = new GameControls();
        controls.Enable();
        movementAction = controls.DefaultMap.Movement;
        rotationAction = controls.DefaultMap.Rotation;

        shootAction = controls.DefaultMap.Shoot;
        nextWeapon = controls.DefaultMap.NextWeapon;
        previousWeapon = controls.DefaultMap.PreviousWeapon;

        previousWeapon.performed += PreviousWeapon;
        nextWeapon.performed += NextWeapon;
        shootAction.performed += Fire;
    }

    private void Fire(InputAction.CallbackContext context)
	{
        var bullet = Instantiate(bulletPrefab, bulletStartLocation.position, transform.rotation);
        bullet.InitBullet(weaponList[currentWeaponIndex]);
    }

    private void NextWeapon(InputAction.CallbackContext context)
    {
        currentWeaponIndex++;
        UpdateWeaponIndex();
    }

    private void PreviousWeapon(InputAction.CallbackContext context)
    {
        currentWeaponIndex--;
        UpdateWeaponIndex();
    }

    private void UpdateWeaponIndex()
	{
		if (currentWeaponIndex < 0)
		{
            currentWeaponIndex = weaponList.Count - 1;
		}
		else if (currentWeaponIndex >= weaponList.Count)
		{
            currentWeaponIndex = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<EnemyCharacter>();
        if (enemy)
        {
            TakeDamage(enemy.Damage);
        }
    }
	protected override void OnDeath()
	{
        gameObject.SetActive(false);
	}
}
