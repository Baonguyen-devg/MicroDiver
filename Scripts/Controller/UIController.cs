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

    [SerializeField] private Text maxLenghtText;
    private void LoadMaxLengthText() =>
        this.maxLenghtText = transform.Find("Game").Find("Max_Length_Text").GetComponent<Text>();

    [SerializeField] private float heightScaleBox = default;
    private void LoadHeightScaleBox() =>
        this.heightScaleBox = transform.Find("Game").Find("Deep").Find("Scale_Box").GetComponent<RectTransform>().rect.height;

    [SerializeField] private RectTransform pointDeepPresent;
    private void LoadPointDeepPresent() =>
        this.pointDeepPresent = transform.Find("Game").Find("Deep").Find("Point_Present").GetComponent<RectTransform>();

    [SerializeField] private RectTransform pointDeepMax;
    private void LoadPointDeepMax() =>
        this.pointDeepMax = transform.Find("Game").Find("Deep").Find("Point_Max").GetComponent<RectTransform>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadLengthText();
        this.LoadLoseGameUI();
        this.LoadWinGameUI();
        this.LoadMaxLengthText();
        this.LoadHeightScaleBox();
        this.LoadPointDeepPresent();
        this.LoadPointDeepMax();
    }

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        UIController.instance = this;
        this.ChangeMaxLengthText("/" + GameController.Instance.LengthRequest.ToString());
    }

    public virtual void ChangeDeep(float rateDeep)
    {
        Vector2 newPositon = this.pointDeepPresent.anchoredPosition;
        newPositon.y = -rateDeep * this.heightScaleBox;
        this.pointDeepPresent.anchoredPosition = newPositon;
    }

    public virtual void ChangeLengthText(string textNumber) => 
        this.lenghtText.text = textNumber;

    public virtual void ChangeMaxLengthText(string textNumber) =>
       this.maxLenghtText.text = textNumber;

    public virtual void Win() => this.winGameUI.SetActive(true);

    public virtual void Lose() => this.loseGameUI.SetActive(true);
}

