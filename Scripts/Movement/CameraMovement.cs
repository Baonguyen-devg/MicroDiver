using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : Movement
{
    [SerializeField] protected Transform headPlayer;
    protected virtual void LoadPlayer() =>
        this.headPlayer = GameObject.Find("Player").transform.Find("Model")?.Find("Head");

    [SerializeField] protected Transform bottomSea;
    protected virtual void LoadBottomSea() =>
        this.bottomSea = GameObject.Find("Background")?.transform.Find("Bottom_Sea")?.transform;

    [SerializeField] private float distanceStop = 5f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
        this.LoadBottomSea();
    }

    protected override void Move()
    {
        if (this.headPlayer.localPosition.y >= 0) return;
        if (this.headPlayer.localPosition.y <= this.bottomSea.localPosition.y + this.distanceStop) return;

        Vector3 pos = new Vector3(transform.localPosition.x, this.headPlayer.localPosition.y, -10);;
        transform.parent.position = Vector3.MoveTowards(transform.position, pos, this.speed);
    }
}