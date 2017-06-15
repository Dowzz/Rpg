using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsController : MonoBehaviour {
	public GameObject playerHand;
	public GameObject EquippedWeapon {get;set;}

	IWeapon equippedWeapon;
	CharacterStats characterStats;

	void Start()
	{
		characterStats = GetComponent<CharacterStats> ();
	}
	public void EquipWeapon(Item itemToEquip) 
	{
		if (EquippedWeapon != null) 
		{
			characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
			Destroy(playerHand.transform.GetChild(0).gameObject);	
		}
		EquippedWeapon = (GameObject)Instantiate (Resources.Load<GameObject> ("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
		equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
		equippedWeapon.Stats = itemToEquip.Stats;
		EquippedWeapon.transform.SetParent(playerHand.transform);
		characterStats.AddStatBonus(itemToEquip.Stats);
			
		}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.X)) 
		{
			PerformWeaponAttack ();
		}
		if (Input.GetKeyDown (KeyCode.Y)) 
		{
			PerformWeaponSpecialAttack ();
		}
	}
	public void PerformWeaponAttack()
	{
		equippedWeapon.PerformAttack();
	}
	public void PerformWeaponSpecialAttack()
	{
		equippedWeapon.PerformSpecialAttack() ;
	}

}
