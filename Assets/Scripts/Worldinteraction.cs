using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worldinteraction : MonoBehaviour {
    UnityEngine.AI.NavMeshAgent playerAgent;
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
            GameObject interactedObject = interactioninfo.collider.gameObject;
            if(interactedObject.tag == "Interactive")
            {
                interactedObject.GetComponent<Interactive>().MoveToInteraction(playerAgent);
            }
            else
            {
				playerAgent.stoppingDistance = 0;
                playerAgent.destination = interactioninfo.point;
            }
        }
    }
}
