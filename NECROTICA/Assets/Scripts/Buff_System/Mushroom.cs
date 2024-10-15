using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : BuffItem
{
    [SerializeField] private float damageIncrease = 5f;
    [SerializeField] private float buffDuration = 10f;

    protected override void ApplyBuff(PlayerMove playerMove, PlayerHealth playerHealth)
    {
        Sword sword = playerMove.GetComponentInChildren<Sword>();

        if (sword != null)
        {
            playerMove.StartCoroutine(ApplyDamageBuff(sword));

            Destroy(gameObject);
        }
    }

    private IEnumerator ApplyDamageBuff(Sword sword)
    {
        sword.damage += damageIncrease;
        Debug.Log("Damage increased by " + damageIncrease + " for " + buffDuration + " seconds.");

        yield return new WaitForSeconds(buffDuration);

        sword.damage -= damageIncrease;
        Debug.Log("Damage buff ended. Damage decreased by " + damageIncrease);
    }
}
