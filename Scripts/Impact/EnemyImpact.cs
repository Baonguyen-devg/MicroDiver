using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyImpact : Impact
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        this.Affect(collision.transform);
        EnemySpawner.Instance.Despawn(transform.parent);
    }

    protected abstract void Affect(Transform objectAffect);
}
