using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    public static InventoryController Instance { get; set; }
	public PlayerWeaponsController playerWeaponController;
    public ConsumablesController consumablscontroller;

	void Start()
	{
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
		playerWeaponController = GetComponent<PlayerWeaponsController> ();
        consumablscontroller = GetComponent<ConsumablesController>();

	}

	
}
