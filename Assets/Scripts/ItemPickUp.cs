using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : Interactable {
    public plecak plec;
    public Text NazwaPrzedmiotu;

    public override void Interact()
    {
        Debug.Log("Interact with Item");
    }
    /*
    private void OnMouseExit()
    {
        NazwaPrzedmiotu.enabled = false;
    }

    private void OnMouseDown()
    {
        NazwaPrzedmiotu.enabled = true;
        NazwaPrzedmiotu.text = "Item";
    }*/


}
