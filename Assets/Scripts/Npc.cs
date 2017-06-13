using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Interactive {
	public string[] dialogue;
	public string name;

    public override void Interact()
    {
		DialogueSystem.Instance.AddNewDialogue (dialogue, name);
        Debug.Log("interacting with npc.");
    }

}
