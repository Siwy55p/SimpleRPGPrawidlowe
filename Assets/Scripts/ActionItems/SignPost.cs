using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem {

    public string []dialog;

    public override void Interact()
    {
        DialogueSystems.Instance.AddNewDialogue(dialog, "Znak");
        Debug.Log("Interact with SignPost");
    }
}
