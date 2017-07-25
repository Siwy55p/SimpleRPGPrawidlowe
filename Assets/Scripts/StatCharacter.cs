using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCharacter : MonoBehaviour {

    public List<StatBase> stats = new List<StatBase>();

    private void Start()
    {
        stats.Add(new StatBase(4, "Power", "Poziom siły"));
        stats.Add(new StatBase(2, "Vitality", "Poziom witalnosci"));
        //stats[0].AddStatBonus(new StatBonus(5)); przyklad uzycia
        stats[0].AddStatBonus(new StatBonus(4));
        stats[0].RemoveStatBonus(new StatBonus(4));

        Debug.Log(stats[0].GetCalculatedStatValue());
    }
}
