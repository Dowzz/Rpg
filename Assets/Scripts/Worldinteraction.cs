using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worldinteraction : MonoBehaviour {
    UnityEngine.AI.NavMeshAgent playerAgent;
    private GameObject Target;
	void Start ()
    {
        playerAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            GetInteraction();       
	}


    void GetInteraction()
    {
        Ray InteractionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactioninfo;
        if (Physics.Raycast(InteractionRay, out interactioninfo, Mathf.Infinity ))
        {
            playerAgent.updateRotation = true;
            Target = interactioninfo.collider.gameObject;

            if (Target.tag == "Interactive")
            {
                Target.GetComponent<Interactive>().MoveToInteraction(playerAgent);
            }
            else if (Target.tag == "Enemy")

            {
                if (GetComponent<PlayerWeaponsController>().EquippedWeapon.GetComponent<IProjectileWeapon>()!= null)
                {
                    GetComponent<PlayerWeaponsController>().PerformWeaponAttack();
                }
                else if (Vector3.Distance(transform.position, Target.transform.position) <= 3f)
                { 
                    GetComponent<PlayerWeaponsController>().PerformWeaponAttack();
                
                }
                else
                {
                    Target.GetComponent<Interactive>().MoveToInteraction(playerAgent);
                }

            }
            else
            {
				playerAgent.stoppingDistance = 0;
                playerAgent.destination = interactioninfo.point;
            }
        }
    }

}
