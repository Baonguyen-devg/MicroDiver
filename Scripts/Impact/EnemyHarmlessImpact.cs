using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHarmlessImpact : EnemyImpact
{
    protected override void Affect(Transform objectAffect)
    {
        Debug.LogWarning("Increase Length");
    }
}
