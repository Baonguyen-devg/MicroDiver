using UnityEngine;

public class DespawnerByTime : Despawner
{
    private const float DEFAULT_TIME_DESPAWN = 2f;

    [SerializeField] protected float timeDespawn = DEFAULT_TIME_DESPAWN;
    [SerializeField] protected float timeStartSpawn;

    protected override void OnEnable() => this.timeStartSpawn = default;

    public override void DespawnObject() =>
         EnemySpawner.Instance.Despawn(transform.parent);

    protected override bool CanDespawn()
    {
        this.timeStartSpawn = this.timeStartSpawn + Time.deltaTime;
        if (this.timeDespawn > timeStartSpawn) return false;
        else return true;
    }
}
