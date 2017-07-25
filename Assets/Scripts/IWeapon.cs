using System.Collections.Generic;

public interface IWeapon {
    List<StatBase> Stats { get; set; }
    void PerformAttack();

}
