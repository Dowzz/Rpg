using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
    public static InventoryController Instance { get; set; }
	public PlayerWeaponsController playerWeaponController;
    public ConsumablesController consumablscontroller;
    public InventoryUIDetails Inventory_Details;
    public List<Item> playerItems = new List<Item>();

	void Start()
	{
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
		playerWeaponController = GetComponent<PlayerWeaponsController> ();
        consumablscontroller = GetComponent<ConsumablesController>();
        GiveItem("sword");
        GiveItem("PotionHealth");
        GiveItem("staff");
        GiveItem("Hammer");

	}
    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.Instance.GetItem(itemSlug);
        playerItems.Add(item);
        Debug.Log(playerItems.Count + "items in inventory. Added : " + itemSlug);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void SetItemDetails(Item item, Button SelectedButton)
    {
        Inventory_Details.SetItem(item, SelectedButton);
    }

    public void EquipItem(Item itemToEquip)
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }
    public void ConsumeItem(Item itemtoConsume)
    {
        consumablscontroller.ConsumeItem(itemtoConsume);
    }	
}
