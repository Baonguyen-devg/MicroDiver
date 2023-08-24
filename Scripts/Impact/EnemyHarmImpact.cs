using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHarmImpact : EnemyImpact
{
    protected override void Affect(Transform objectAffect) =>
        GameController.Instance.LoseGame();
}
