using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : BuffItem
{
    [SerializeField] private float healthRestorePercent = 0.16f;
    [SerializeField] private float armorRestorePercent = 0.25f;

    protected override void ApplyBuff(PlayerMove playerMove, PlayerHealth playerHealth)
    {
        int healthRestore = Mathf.CeilToInt(playerHealth.maxHealth * healthRestorePercent);
        playerHealth.RestoreHealth(healthRestore);

        int armorRestore = Mathf.CeilToInt(playerHealth.maxArmor * armorRestorePercent);
        playerHealth.RestoreArmor(armorRestore);

        Debug.Log("Health restored by " + healthRestore + " and armor restored by " + armorRestore);
    }
}

