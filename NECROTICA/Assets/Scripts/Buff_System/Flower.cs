using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : BuffItem
{
    [SerializeField] private float healthRestorePercent = 0.16f;
    [SerializeField] private float armorRestorePercent = 0.25f;
    [SerializeField] private float armorBuffDuration = 5f; // Длительность баффа для брони

    protected override void ApplyBuff(PlayerMove playerMove, PlayerHealth playerHealth)
    {
        // Восстанавливаем здоровье
        int healthRestore = Mathf.CeilToInt(playerHealth.maxHealth * healthRestorePercent);
        playerHealth.RestoreHealth(healthRestore);

        Debug.Log("Health restored by " + healthRestore);

        // Применяем корутину для восстановления брони
        StartCoroutine(ApplyArmorBuff(playerHealth, armorRestorePercent));
    }

    private IEnumerator ApplyArmorBuff(PlayerHealth playerHealth, float armorPercent)
    {
        // Расчет увеличения брони
        int armorRestore = Mathf.CeilToInt(playerHealth.maxArmor * armorPercent);
        playerHealth.RestoreArmor(armorRestore);
        Debug.Log("Armor restored by " + armorRestore + " for " + armorBuffDuration + " seconds.");

        // Ждем указанное время
        yield return new WaitForSeconds(armorBuffDuration);

        // Возвращаем броню обратно
        playerHealth.RestoreArmor(-armorRestore);
        Debug.Log("Armor buff ended. Armor decreased by " + armorRestore);

        // Уничтожаем объект после применения эффекта
        Destroy(gameObject);
    }
}
