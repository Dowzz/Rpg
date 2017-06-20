using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
	public PlayerWeaponsController playerWeaponController;
    public ConsumablesController consumablscontroller;
	public Item Sword;
    public Item PotionHealth;

	void Start()
	{
		playerWeaponController = GetComponent<PlayerWeaponsController> ();
        consumablscontroller = GetComponent<ConsumablesController>();
		List<BaseStat> swordStats = new List<BaseStat> ();
		swordStats.Add(new BaseStat(6, "Power", "Your power level !"));
		Sword = new Item (swordStats, "Staff");;
        PotionHealth = new Item(new List<BaseStat>(), "PotionHealth", "DRINK THIS FOR REGENERATING HEALTH", "drink", "Health Potion", false);

	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			playerWeaponController.EquipWeapon (Sword);
            consumablscontroller.ConsumeItem(PotionHealth);
		}

	}

	
}
