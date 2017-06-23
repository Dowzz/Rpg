using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Item {
    public enum ItemTypes { Weapon, Consumable, Quest }
    public List<BaseStat> Stats { get; set; }
    public string ObjectSlug { get; set; }
    public string description { get; set; }
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ItemTypes ItemType { get; set; }
    public string actionName { get; set; }
    public string ItemName { get; set; }
    public bool ItemModifier { get; set; }

    public Item(List<BaseStat> Stats, string ObjectSlug)
	{
		this.Stats = Stats;
		this.ObjectSlug = ObjectSlug;
	}
    [Newtonsoft.Json.JsonConstructor]
    public Item(List<BaseStat> Stats, string ObjectSlug, string Description, ItemTypes ItemType, string actionName, string ItemName, bool ItemModifier)
    {
        this.Stats = Stats;
        this.ObjectSlug = ObjectSlug;
        this.description = Description;
        this.ItemType = ItemType;
        this.actionName = actionName;
        this.ItemName = ItemName;
        this.ItemModifier = ItemModifier;
    }

}
