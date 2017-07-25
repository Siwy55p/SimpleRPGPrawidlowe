using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    public PlayerWeaponController playerWeaponController;
    public Item sword;

    void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        List<StatBase> swordStats = new List<StatBase>();
        swordStats.Add(new StatBase(6, "Power", "Power level."));
        sword = new Item(swordStats, "sword");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(sword);
        }
    }

}
