using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : AutoMonoBehaviour
{
    private static UIController instance;
    public static UIController Instance => instance;

    [SerializeField] private GameObject pauseGameUI;
    private void LoadPauseGameUI() =>
       this.pauseGameUI = transform.Find("Pause_Game").gameObject;

    [SerializeField] private GameObject loseGameUI;
    private void LoadLoseGameUI() =>
        this.loseGameUI = transform.Find("Lose_Game").gameObject;

    [SerializeField] private Text lenghtText;
    private void LoadLengthText() =>
        this.lenghtText = transform.Find("Game").Find("Length_Text").GetComponent<Text>();

    public float rateDeep = default;

    [SerializeField] private float heightScaleBox = default;
    private void LoadHeightScaleBox() =>
        this.heightScaleBox = transform.Find("Game").Find("Deep").Find("Scale_Box_Height_1").GetComponent<RectTransform>().rect.height;

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
        this.LoadPauseGameUI();
        this.LoadHeightScaleBox();
        this.LoadPointDeepPresent();
        this.LoadPointDeepMax();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) this.Pause();
    }

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        UIController.instance = this;
    }

    public virtual void ChangeDeep(float rateDeep)
    {
        this.rateDeep = rateDeep;
        Vector2 newPositon = this.pointDeepPresent.anchoredPosition;
        newPositon.y = -rateDeep * this.heightScaleBox;
        this.pointDeepPresent.anchoredPosition = newPositon;

        Vector2 newMaxPositon = this.pointDeepMax.anchoredPosition;
        newMaxPositon.y = - GameController.Instance.MaxDeepPresent * this.heightScaleBox;
        this.pointDeepMax.anchoredPosition = newMaxPositon;
    }

    public virtual void ChangeLengthText(string textNumber) => 
        this.lenghtText.text = textNumber;

    public virtual void Pause() {
        this.pauseGameUI.SetActive(true);
        Time.timeScale = 0;
    }

    public virtual void Lose() => this.loseGameUI.SetActive(true);

    public virtual void Continue() => Time.timeScale = 1;

    public virtual void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public virtual void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public virtual void PlayClickAudio() => SFXSpawner.Instance.PlaySound("Click_Button_Audio");
}

