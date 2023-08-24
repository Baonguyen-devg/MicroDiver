using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHarmlessImpact : EnemyImpact
{
    protected override void Affect(Transform objectAffect) =>
        GameController.Instance.IncreaseLength(1);
}
