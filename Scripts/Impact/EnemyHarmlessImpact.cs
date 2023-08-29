using UnityEngine;

public class EnemyHarmlessImpact : EnemyImpact
{
    private const int default_Number_Increase = 1;
    [SerializeField] private int numberIncrease = default_Number_Increase;

    protected override void Affect(Transform objectAffect)
    {
        GameController.Instance.EatHarmlessEnemy();
        for (int i = 1; i <= this.numberIncrease; i++)
            GameController.Instance.IncreaseLength(1);
    }
}
