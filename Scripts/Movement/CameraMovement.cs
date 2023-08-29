using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : Movement
{
    private const float DEFAULT_DISTANCE_STOP = 5f;
    [SerializeField] private float distanceStop = DEFAULT_DISTANCE_STOP;

    /*Begin predicatedload of components*/
    [SerializeField] private List<Action> predicateLoad;

    [SerializeField] private Transform headPlayer;
    [SerializeField] private Transform bottomSea;
    /*End predicatedload of components*/

    protected override void LoadComponent()
    {
        base.LoadComponent();
        predicateLoad.Clear();
        predicateLoad = new List<Action>
        {
            () => this.headPlayer = GameObject.Find("Player")?.transform.Find("Model")?.Find("Head"),
            () => this.bottomSea = GameObject.Find("Background")?.transform.Find("Bottom_Sea")?.transform
        };

        foreach (var predicate in predicateLoad)
            predicate?.Invoke();
    }

    protected override void Move()
    {
        Predicate<float> predicate = (x) => x > 0 || x <= this.bottomSea.localPosition.y + this.distanceStop;
        if (predicate.Invoke(this.headPlayer.localPosition.y)) return;

        Vector3 pos = new Vector3(transform.localPosition.x, this.headPlayer.localPosition.y, -10);;
        transform.parent.position = Vector3.MoveTowards(transform.position, pos, this.speed);
    }
}