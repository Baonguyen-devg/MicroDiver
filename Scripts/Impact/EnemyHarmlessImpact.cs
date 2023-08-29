using UnityEngine;

public class EnemyHarmlessImpact : EnemyImpact
{
    private const int DEFAULT_NUMBER_INCREASE = 1;
    [SerializeField] private int numberIncrease = DEFAULT_NUMBER_INCREASE;

    protected override void Affect(Transform objectAffect)
    {
        GameController.Instance.EatHarmlessEnemy();
        for (int i = 1; i <= this.numberIncrease; i++)
            GameController.Instance.IncreaseLength(1);
    }
}
