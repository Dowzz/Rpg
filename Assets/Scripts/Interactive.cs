using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactive : MonoBehaviour {
	[HideInInspector]
    public NavMeshAgent playerAgent;
	private bool hasInteracted;
    bool isEnemy;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        isEnemy = gameObject.tag == "Enemy";
		hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = this.transform.position;
    }
	void Update()
	{
		if (!hasInteracted &&  playerAgent != null && !playerAgent.pathPending) 
		{
			if (playerAgent.remainingDistance <= playerAgent.stoppingDistance) 
			{
                if (!isEnemy)
				Interact();
				hasInteracted = true;
			}
		}
	}
    void EnsureLookDirection()
    {
        playerAgent.updateRotation = false;
        Vector3 LookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        playerAgent.transform.LookAt(LookDirection);
        playerAgent.updateRotation = true;
    }

    public virtual void Interact()
    {
        Debug.Log("interacting with base class.");
    }
}
