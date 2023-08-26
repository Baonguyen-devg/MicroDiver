using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : AutoMonoBehaviour
{
    private static GameController instance;
    public static GameController Instance => instance;

    [SerializeField] private float deepRequest = 1f;

    [SerializeField] private int lengthPresent = default;
    [SerializeField] private float maxDeepPresent = default;
    public float MaxDeepPresent => this.maxDeepPresent;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        GameController.instance = this;
        Application.targetFrameRate = 60;
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

    public virtual void LoseGame()
    {
        StartCoroutine(this.Lose());
    }

    private IEnumerator Lose()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
        UIController.Instance.Lose();
    }

    public virtual void PauseGame()
    {
        Time.timeScale = 0;
        UIController.Instance.Pause();
    }
}
