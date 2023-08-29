using UnityEngine;

public class EnemySpawner : Spawner, IObserver
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        EnemySpawner.instance = this;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        GameController.Instance.RegisterSubjectPointEnemySpawner(this);
    }

    public override string GetRandomPrefab()
    {
        int keyRandom = (UIController.Instance.RateDeep >= 0.5f) ? this.listPrefab.Count : this.listPrefab.Count - 1;
        int keyObject = Random.Range(0, keyRandom);
        return this.listPrefab[keyObject].name;
    }

    public void UpdateObserver(ISubject subject)
    {
        int key = Random.Range(0, (subject as PointEnemySpawner).ListPrefabs.Count);
        string nameEnemyRandom = this.GetRandomPrefab();
        Transform pointSpawner = (subject as PointEnemySpawner).ListPrefabs[key];
        this.Spawn(nameEnemyRandom, pointSpawner.position, pointSpawner.rotation);
    }
}

