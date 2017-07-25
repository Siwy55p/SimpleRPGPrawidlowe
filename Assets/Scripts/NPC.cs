using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {
    public string[] dialogue;
    public string name;

    public override void Interact()
    {
        DialogueSystems.Instance.AddNewDialogue(dialogue, name);
        Debug.Log("Interact() with in NPC");
    }
}
