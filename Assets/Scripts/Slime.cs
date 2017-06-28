using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Interactive, IEnemy{
	
	public float currentHealth;
	public float maxHealth;

    private CharacterStats characterStats;

	void Start()
	{
        characterStats = new CharacterStats(6,10,2);
		currentHealth = maxHealth;
	}
	public void PerformAttack ()
	{
		throw new System.NotImplementedException ();
	}
	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
			Die ();
	}
		void Die()
		{
		Destroy (gameObject); 	
		}

}


		




