using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        Debug.Log("You drink a swig of the potion. Cool!");
    }

    public void Consume(StatCharacter stats)
    {
        Debug.Log("You drink a swig of the potion. Rad!");
    }
}
