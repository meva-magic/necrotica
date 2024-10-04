using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemiesInTrigger = new List<Enemy>();
    
    public static EnemyManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddEnemy(Enemy enemy)
    {
        enemiesInTrigger.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemiesInTrigger.Remove(enemy);
    }
}
