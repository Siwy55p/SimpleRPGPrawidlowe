using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plecak : MonoBehaviour {

    public ItemPickUp[] Plecak;
    int iloscWPlecaku = 0;
    
	// Use this for initialization
	void Start () {
        Plecak = new ItemPickUp[10];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WrzucDoPlecaka(ItemPickUp item)
    {

        Plecak[iloscWPlecaku] = item;
        iloscWPlecaku++;
        print("dodano item: " + item.name);
    }

    public int IleWPlecaku()
    {
        return iloscWPlecaku;
    }
}
