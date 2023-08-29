using UnityEngine;

public abstract class EnemyImpact : Impact
{
    private const string name_Layer_Player = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer(name_Layer_Player)) return;
        this.Affect(collision.transform);
        EnemySpawner.Instance.Despawn(transform.parent);
    }

    protected abstract void Affect(Transform objectAffect);
}
