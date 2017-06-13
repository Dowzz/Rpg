using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
	public static DialogueSystem Instance { get; set; }

	public string npcName;
	public List<string> dialogueLines = new List<string>();
	public GameObject dialogPanel;
	Button continueButton;
	Text dialogueText,nameText;
	int dialogueIndex;
	// Use this for initialization
	void Awake () {
		continueButton = dialogPanel.transform.Find ("Continue").GetComponent<Button> ();
		dialogueText = dialogPanel.transform.Find ("Text").GetComponent<Text> ();
		nameText = dialogPanel.transform.Find ("Name").GetChild (0).GetComponent<Text> ();
		continueButton.onClick.AddListener (delegate { ContinueDialogue(); });
		dialogPanel.SetActive (false);

		if (Instance != null && Instance != this)
		{
			Destroy	(gameObject);
		} 
		else 
		{
			Instance = this;
		}
	}

	public void AddNewDialogue(string[] lines, string npcName)
	{
		dialogueIndex = 0;
		dialogueLines = new List<string> (lines.Length);
		dialogueLines.AddRange (lines);
		this.npcName = npcName;

		Debug.Log (dialogueLines.Count);
		CreateDialogue ();
	}
	public void CreateDialogue()
	{
		dialogueText.text = dialogueLines[dialogueIndex];
		nameText.text = npcName;
		dialogPanel.SetActive(true);

	}

	public void ContinueDialogue()
	{
		if (dialogueIndex < dialogueLines.Count-1) 
		{
			dialogueIndex++;
			dialogueText.text = dialogueLines [dialogueIndex];
		}
		else
		{
			dialogPanel.SetActive (false);
	}
}
}
