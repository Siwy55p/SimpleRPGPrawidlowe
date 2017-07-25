using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }


    IWeapon equippedWeapon;
    StatCharacter charactersStats;

    private void Start()
    {
        charactersStats = GetComponent<StatCharacter>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if(EquippedWeapon != null)
        {
            charactersStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug),
            playerHand.transform.position, playerHand.transform.rotation);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        equippedWeapon.Stats = itemToEquip.Stats;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        charactersStats.AddStatBonus(itemToEquip.Stats);
        Debug.Log(equippedWeapon.Stats[0].GetCalculatedStatValue());
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack();
    }
}
