using System.Collections.Generic;
using UnityEngine;

public class PointEnemySpawner : AutoMonoBehaviour, ISubject
{
    private const float default_Rate_Time_Spawn = 2f;

    [SerializeField] private List<Transform> listPrefabs;
    private void LoadListPrefas() =>
        this.listPrefabs = gameObject.GetComponent<ListPrefab>().Prefabs;
    public List<Transform> ListPrefabs => this.listPrefabs;

    [SerializeField] private float rateTimeSpawn = default_Rate_Time_Spawn;
    [SerializeField] private float timeCountDown = default_Rate_Time_Spawn;

    [SerializeField] private List<IObserver> observers = new List<IObserver>();

    protected override void LoadComponent() => this.LoadListPrefas();

    private void Update()
    {
        this.timeCountDown = this.timeCountDown - Time.deltaTime;
        if (this.timeCountDown > 0) return;
        this.Notify();
    }

    public void Attach(IObserver observer) => this.observers.Add(observer);

    public void Detach(IObserver observer) => this.observers.Remove(observer);

    public void Notify()
    {
        this.timeCountDown = this.rateTimeSpawn;
        foreach (IObserver observer in this.observers)
            observer.UpdateObserver(this);
    }
}
