using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour {
    StatCharacter stats;

	// Use this for initialization
	void Start () {
        stats = GetComponent<StatCharacter>();
	}

    public void ConsumeItem(Item item)
    {
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.ObjectSlug));
        if(item.ItemModifier)
        {
            itemToSpawn.GetComponent<IConsumable>().Consume(stats);
        }
        else
            itemToSpawn.GetComponent<IConsumable>().Consume();
    }
}
