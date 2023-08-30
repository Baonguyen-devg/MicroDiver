using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : Movement
{
    internal class dataEvent : EventArgs
    {
        private Vector3 direction = Vector3.zero;
        public Vector3 Direction => this.direction;

        public dataEvent(Vector3 direction) => this.direction = direction;
    } 

    private const float DEFAULT_DISTANCE_STOP = 5f;
    [SerializeField] private float distanceStop = DEFAULT_DISTANCE_STOP;

    /*Begin predicatedload of components*/
    [SerializeField] private List<Action> predicateLoad;

    [SerializeField] private Transform headPlayer;
    [SerializeField] private Transform bottomSea;
    /*End predicatedload of components*/

    private event EventHandler MoveEventHandler;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.predicateLoad = new List<Action>
        {
            () => this.headPlayer = GameObject.Find("Player")?.transform.Find("Model")?.Find("Head"),
            () => this.bottomSea = GameObject.Find("Background")?.transform.Find("Bottom_Sea")?.transform
        };

        this.MoveEventHandler += this.Move;
        foreach (var predicate in this.predicateLoad)
            predicate?.Invoke();
    }

    protected override void Move()
    {
        Predicate<float> predicate = (x) => x > 0 || x <= this.bottomSea.localPosition.y + this.distanceStop;
        if (predicate.Invoke(this.headPlayer.localPosition.y)) return;

        dataEvent data = new dataEvent(new Vector3(transform.localPosition.x, this.headPlayer.localPosition.y, -10));
        this.MoveEventHandler?.Invoke(null, data);
    }

    private void Move(object sender, EventArgs dataEventArgs)
    {
        dataEvent dataEvent = (dataEvent)dataEventArgs;
        Vector3 pos = dataEvent.Direction;
        transform.parent.position = Vector3.MoveTowards(transform.position, pos, this.speed);
    }
}