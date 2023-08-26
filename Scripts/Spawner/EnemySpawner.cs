using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        EnemySpawner.instance = this;
    }

    public override string GetRandomPrefab()
    {
        int keyRandom = (UIController.Instance.rateDeep >= 0.5f) ? this.listPrefab.Count : this.listPrefab.Count - 1;
        int keyObject = Random.Range(0, keyRandom);
        return this.listPrefab[keyObject].name;
    }
}

