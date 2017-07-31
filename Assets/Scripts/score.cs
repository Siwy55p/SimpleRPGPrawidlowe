using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : ItemPickUp {

    float wartosc;

    public score(float value)
    {
        wartosc = value;
    }
	// Use this for initialization
	void Start () {
        this.GetComponent<BoxCollider>().isTrigger = true;
	}
    public override void Interact()
    {
        print("Interakcja with score");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Interact();
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Rotate(15 * Time.deltaTime, 15 * Time.deltaTime, 15 * Time.deltaTime);
	}
}
