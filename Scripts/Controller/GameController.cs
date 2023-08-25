using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : AutoMonoBehaviour
{
    private static GameController instance;
    public static GameController Instance => instance;

    [SerializeField] private int lengthRequest = default;
    public int LengthRequest => lengthRequest;

    [SerializeField] private int deepRequest = default;

    [SerializeField] private int lengthPresent = default;
    [SerializeField] private float deepPresent = default;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        GameController.instance = this;
    }

    private void Update()
    {
        if (this.lengthPresent >= this.lengthRequest && this.deepPresent >= this.deepRequest)
            this.WinGame();
    }

    public virtual void IncreaseLength(int number)
    {
        this.lengthPresent = this.lengthPresent + number;
        IncreaseBody.Instance.Increase();
        UIController.Instance.ChangeLengthText(this.lengthPresent.ToString());

    }

    public virtual void UpdateDeep(float number)
    {
        
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

    public virtual void WinGame()
    {
        Time.timeScale = 0;
        UIController.Instance.Win();
    }
}
