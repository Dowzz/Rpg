using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signpost : ActionItem {
	public string[] dialogue;
	public override void Interact()
	{
		DialogueSystem.Instance.AddNewDialogue (dialogue, "sign");
		Debug.Log ("Interacting with sign post");
	}


}
