using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEnemySpawner : AutoMonoBehaviour
{
    private const float default_Rate_Time_Spawn = 2f;

    [SerializeField] private List<Transform> listPrefabs;
    protected virtual void LoadListPrefas() =>
        this.listPrefabs = gameObject.GetComponent<ListPrefab>().Prefabs;

    [SerializeField] private float rateTimeSpawn = default_Rate_Time_Spawn;
    [SerializeField] private float timeCountDown = default_Rate_Time_Spawn;

    protected override void LoadComponent() => this.LoadListPrefas();
        
    protected virtual void Update()
    {
        this.timeCountDown = this.timeCountDown - Time.deltaTime;
        if (this.timeCountDown > 0) return;

        this.timeCountDown = this.rateTimeSpawn;
        int key = Random.Range(0, this.listPrefabs.Count);
        string nameEnemyRandom = EnemySpawner.Instance.GetRandomPrefab();
        EnemySpawner.Instance.Spawn(nameEnemyRandom, this.listPrefabs[key].position, this.listPrefabs[key].rotation);
    }    
}
