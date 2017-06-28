using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class BaseStat
{
    public enum BaseStatType { Power, Toughness, AttackSpeed }
  
	public List<StatBonus> BaseAdditives {get;set;}
    [JsonConverter(typeof(StringEnumConverter))]
    public BaseStatType StatType { get; set; }
    public int BaseValue {get;set;}
	public string StatName {get;set;}
	public string StatDescription {get;set;}
	public int FinalValue {get;set;}

	public BaseStat(int baseValue, string StatName, string statDescription)
	{
		this.BaseAdditives = new List<StatBonus> ();    
        this.BaseValue = baseValue;
		this.StatName = StatName;
		this.StatDescription = statDescription;
	}

    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(BaseStatType statType, int baseValue, string StatName)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.StatType = statType;
        this.BaseValue = baseValue;
        this.StatName = StatName;
    }

    public void AddStatBonus(StatBonus statBonus)
	{
		this.BaseAdditives.Add (statBonus);
	}
	public void RemoveStatBonus(StatBonus statBonus)
	{
		this.BaseAdditives.Remove (BaseAdditives.Find(x=> x.BonusValue == statBonus.BonusValue));
	}
	public int GetCalculatedStat()
	{
		this.FinalValue = 0;
		this.BaseAdditives.ForEach (x => this.FinalValue += x.BonusValue);
		FinalValue += BaseValue;
		return FinalValue;
	}
}
