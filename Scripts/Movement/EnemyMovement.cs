using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    [SerializeField] private Vector3 direction = Vector3.zero;

    protected override void OnEnable()
    {
        base.OnEnable();
        transform.parent.localPosition = new Vector3(transform.parent.localPosition.x, transform.parent.localPosition.y, 0);
        this.direction = (transform.position.x < 0) ? Vector3.right : Vector3.left;
    }

    protected override void Move() =>
        transform.parent.Translate(this.direction * this.speed * Time.deltaTime);
}
