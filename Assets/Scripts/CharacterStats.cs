using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats {
	public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStats(int power, int tough,int attackSpeed)
    {
        stats = new List<BaseStat>(){
            new BaseStat(BaseStat.BaseStatType.Power, power, "Puissance"),
            new BaseStat(BaseStat.BaseStatType.Toughness, tough, "Resistance"),
            new BaseStat(BaseStat.BaseStatType.AttackSpeed, attackSpeed , "Vitesse")
        };
    }
    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        return this.stats.Find(x=> x.StatType == stat);
    }

	public void AddStatBonus(List<BaseStat> statBonuses)
	{
		
		foreach (BaseStat statBonus in statBonuses)
		{
            GetStat(statBonus.StatType).AddStatBonus(new StatBonus(statBonus.BaseValue));
		}
	}
	public void RemoveStatBonus(List<BaseStat> statBonuses)
	{
		foreach (BaseStat statBonus in statBonuses)
		{
            GetStat(statBonus.StatType).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
		}
	}

}
