using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
	public PlayerWeaponsController playerWeaponController;
	public Item Sword;

	void Start()
	{
		playerWeaponController = GetComponent<PlayerWeaponsController> ();
		List<BaseStat> swordStats = new List<BaseStat> ();
		swordStats.Add(new BaseStat(6, "Power", "Your power level !"));
			Sword = new Item (swordStats, "Sword");
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			playerWeaponController.EquipWeapon (Sword);
		}
	}

	
}
