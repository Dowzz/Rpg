using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public RectTransform InventoryPanel;
    public RectTransform ScrollViewContent;
    InventoryUIItem itemContainer { get; set; }
    bool menuIsActive { get; set; }
    Item CurrentSelectedItem { get; set; }




	// Use this for initialization
	void Start () {
        itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        InventoryPanel.gameObject.SetActive(false);
	}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            menuIsActive = !menuIsActive;
            InventoryPanel.gameObject.SetActive(menuIsActive);
        }
    }

    public void ItemAdded(Item item)
    {
        InventoryUIItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(ScrollViewContent);
	}
}
