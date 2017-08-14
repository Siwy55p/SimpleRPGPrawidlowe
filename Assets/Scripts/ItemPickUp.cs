using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : Interactable {
    public Text NazwaPrzedmiotu;

    public override void Interact()
    {
        Debug.Log("Interact with Item");
    }

}
