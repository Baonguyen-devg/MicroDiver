using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : AutoMonoBehaviour
{
    private static UIController instance;
    public static UIController Instance => instance;

    [SerializeField] private GameObject pauseGameUI;
    [SerializeField] private GameObject winGameUI;
    private void LoadWinGameUI() =>
        this.winGameUI = transform.Find("Win_Game").gameObject;

    [SerializeField] private GameObject loseGameUI;
    private void LoadLoseGameUI() =>
        this.loseGameUI = transform.Find("Lose_Game").gameObject;

    [SerializeField] private Text lenghtText;
    private void LoadLengthText() =>
        this.lenghtText = transform.Find("Game").Find("Length_Text").GetComponent<Text>();

    [SerializeField] private Text deepText;
    private void LoadDeepText() =>
        this.deepText = transform.Find("Game").Find("Deep_Text").GetComponent<Text>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadLengthText();
        this.LoadDeepText();
        this.LoadLoseGameUI();
        this.LoadWinGameUI();
    }

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        UIController.instance = this;
    }

    public virtual void ChangeLengthText(string textNumber) => 
        this.lenghtText.text = textNumber;

    public virtual void ChangeDeepText(string textNumber) => 
        this.deepText.text = textNumber;

    public virtual void Win() => this.winGameUI.SetActive(true);

    public virtual void Lose() => this.loseGameUI.SetActive(true);
}

