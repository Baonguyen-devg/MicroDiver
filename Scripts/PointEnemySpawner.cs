using System;
using System.Collections.Generic;
using UnityEngine;

public class PointEnemySpawner : AutoMonoBehaviour, ISubject
{
    private const float DEFAULT_RATE_TIME_SPAWN = 2f;

    [SerializeField] private List<Transform> listPrefabs;
    public List<Transform> ListPrefabs => this.listPrefabs;
    private void LoadListPrefas() =>
        this.listPrefabs = gameObject.GetComponent<ListPrefab>().Prefabs;

    [SerializeField] private float rateTimeSpawn = DEFAULT_RATE_TIME_SPAWN;
    [SerializeField] private float timeCountDown = DEFAULT_RATE_TIME_SPAWN;

    [SerializeField] private List<IObserver> observers = new List<IObserver>();

    protected override void LoadComponent() => this.LoadListPrefas();

    private void Update()
    {
        this.timeCountDown = this.timeCountDown - Time.deltaTime;
        Predicate<float> predicate = (x) => x > 0;
        if (predicate(this.timeCountDown)) return;
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
