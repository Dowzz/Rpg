using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour {
    Item item;
    Button selectedItemButton, itemInteractButton;
    Text itemNameText, itemDescriptionText, itemInteractButtonText;


    void Start()
    {
        itemNameText = transform.Find("Item_Name").GetComponent<Text>();
        itemDescriptionText = transform.Find("Item_Description").GetComponent<Text>();
        itemInteractButton = transform.Find("Interact_Button").GetComponent<Button>();
        itemInteractButtonText = itemInteractButton.transform.Find("Text").GetComponent<Text>();
    }

    public void SetItem(Item item, Button SelectedButton )
    {
        itemInteractButton.onClick.RemoveAllListeners();
        this.item = item;
        selectedItemButton = SelectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.description;
        itemInteractButtonText.text = item.actionName;
        itemInteractButton.onClick.AddListener(OnItemInteract);
    }
    public void OnItemInteract()
    {

        if (item.ItemType == Item.ItemTypes.Consumable)
        {
            InventoryController.Instance.ConsumeItem(item);
            Destroy(selectedItemButton.gameObject);
        }
        else if (item.ItemType == Item.ItemTypes.Weapon)
        {
            InventoryController.Instance.EquipItem(item);
            Destroy(selectedItemButton.gameObject); 
        }
    }

}
