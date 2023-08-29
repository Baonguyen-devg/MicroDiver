using System.Collections;
using UnityEngine;

public partial class GameController : AutoMonoBehaviour
{
    private void Update()
    {
        if (InputController.Instance.GetkeyEscape()) this.PauseGame();
    }

    public virtual void IncreaseLength(int number)
    {
        this.lengthPresent = this.lengthPresent + number;
        IncreaseBody.Instance.Increase();
        UIController.Instance.ChangeLengthText(this.lengthPresent.ToString());
    }

    public virtual void UpdateDeep(float number)
    {
        this.maxDeepPresent = Mathf.Max(this.maxDeepPresent, number);
        UIController.Instance.ChangeDeep(number);
    }

    public virtual void LoseGame() => StartCoroutine(this.Lose());

    private IEnumerator Lose()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
        UIController.Instance.Lose();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        UIController.Instance.Pause();
    }

    public virtual void EatHarmEnemy(Transform enemy)
    {
        VFXSpawner.Instance.Spawn("Smoke_Boom", enemy.position, enemy.rotation);
        SFXSpawner.Instance.PlaySound("Smoke_Boom_Audio");
    }

    public virtual void EatHarmlessEnemy()
    {
        SFXSpawner.Instance.PlaySound("Swallow_Audio");
    }

    public virtual void RegisterSubjectPointEnemySpawner(IObserver observer) =>
        this.subjectPointEnemySpawner.Attach(observer);
}
