using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHarmImpact : EnemyImpact
{
    protected override void Affect(Transform objectAffect) {
        VFXSpawner.Instance.Spawn("Smoke_Boom", transform.position, transform.rotation);
        GameController.Instance.LoseGame();
    }
}
