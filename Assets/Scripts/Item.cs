using System.Collections.Generic;
using UnityEngine;

public class Item {
    public List<StatBase> Stats { get; set; }
    public string ObjectSlug { get; set; }

    public Item(List<StatBase> _Stats, string _ObjectSlug)
    {
        this.Stats = _Stats;
        this.ObjectSlug = _ObjectSlug;
    }
}
