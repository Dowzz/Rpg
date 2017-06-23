using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour {
    public static ItemDatabase Instance { get; set; }
    public List<Item> items { get; set; }

	// Use this for initialization
	void Awake () {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        BuildDatabase();
	}
    public void BuildDatabase()
    {
        items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("Json/items").ToString());
    }
    public Item GetItem(string itemSlug)
    {
        foreach(Item item in items)
        {
            if (item.ObjectSlug == itemSlug)
                return item;
        }
        Debug.LogWarning("no item find" + itemSlug);
        return null;
    }
}
