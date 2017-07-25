using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : ItemPickUp {

    float wartosc;
    score Scor;
    public score(float value)
    {
        wartosc = value;
    }
	// Use this for initialization
	void Start () {
        Scor = new score(15);
	}
    public override void Interact()
    {
        print("Interakcja with score");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Rotate(15 * Time.deltaTime, 15 * Time.deltaTime, 15 * Time.deltaTime);
	}
}
