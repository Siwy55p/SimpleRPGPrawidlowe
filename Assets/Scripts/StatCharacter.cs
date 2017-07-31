using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCharacter : MonoBehaviour {

    public List<StatBase> stats = new List<StatBase>();

    private void Start()
    {
        stats.Add(new StatBase(4, "Power", "Power Level."));
        stats.Add(new StatBase(2, "Vitality", "Vitality Level."));
        //stats[0].AddStatBonus(new StatBonus(5)); przyklad uzycia
        stats[0].AddStatBonus(new StatBonus(4));
        Debug.Log(stats[0].GetCalculatedStatValue());


    }

    public void AddStatBonus(List<StatBase> statBonuses)
    {
        foreach(StatBase statBonus in statBonuses)
        {
            stats.Find(x=> x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<StatBase> statBonuses)
    {
        foreach (StatBase statBonus in statBonuses)
        {
            stats.Find(x => x.StatName == statBonus.StatName).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}
