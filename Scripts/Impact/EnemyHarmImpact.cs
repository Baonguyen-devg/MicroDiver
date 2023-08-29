using UnityEngine;

public class EnemyHarmImpact : EnemyImpact
{
    protected override void Affect(Transform objectAffect) {
        GameController.Instance.EatHarmEnemy(transform);
        GameController.Instance.LoseGame();
    }
}
