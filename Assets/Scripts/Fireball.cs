using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }

    Vector3 spawnPosition;

    private void Start()
    {
        Damage = 4;
        Range = 20f;
        spawnPosition = transform.position;
        GetComponent<Rigidbody>().AddForce(Direction * 50f);
    }

    private void Update()
    {
        if (Vector3.Distance(spawnPosition, transform.position) >= Range)
        {
            Extinguish();
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Enemy")
        {
            col.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        Extinguish();
    }

    void Extinguish()
    {
        Destroy(gameObject);
    }
}
