using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHarmlessImpact : EnemyImpact
{
    [SerializeField] private int numberIncrease = 1;

    protected override void Affect(Transform objectAffect)
    {
        for (int i = 1; i <= this.numberIncrease; i++)
            GameController.Instance.IncreaseLength(1);

        SFXSpawner.Instance.PlaySound("Swallow_Audio");
    }
}
