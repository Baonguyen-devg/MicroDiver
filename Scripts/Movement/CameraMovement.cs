using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : Movement
{
    [SerializeField] protected Transform headPlayer;
    protected virtual void LoadPlayer() =>
        this.headPlayer = GameObject.Find("Player").transform.Find("Model")?.Find("Head");

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
    }

    protected override void Move()
    {
        Vector3 pos = new Vector3(transform.position.x, this.headPlayer.position.y, -10);
        transform.parent.position = Vector3.MoveTowards(transform.position, pos, this.speed);
    }
}