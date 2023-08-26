using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnerByTime : Despawner
{
    [SerializeField] protected float timeDespawn = 2f;
    [SerializeField] protected float timeStartSpawn;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.timeStartSpawn = 0;
    }

    public override void DespawnObject()
    {
        base.DespawnObject();
        EnemySpawner.Instance.Despawn(transform.parent);
    }

    protected override bool CanDespawn()
    {
        this.timeStartSpawn = this.timeStartSpawn + Time.deltaTime;
        if (this.timeDespawn > timeStartSpawn) return false;
        else return true;
    }
}
