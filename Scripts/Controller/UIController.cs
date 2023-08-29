using UnityEngine;
using UnityEngine.UI;

public partial class UIController : AutoMonoBehaviour
{
    private static UIController instance;
    public static UIController Instance => instance;

    private float rateDeep = default;
    public float RateDeep => this.rateDeep;

    [SerializeField] private GameObject pauseGameUI;
    private void LoadPauseGameUI() =>
       this.pauseGameUI = transform.Find("Pause_Game").gameObject;

    [SerializeField] private GameObject loseGameUI;
    private void LoadLoseGameUI() =>
        this.loseGameUI = transform.Find("Lose_Game").gameObject;

    [SerializeField] private Text lenghtText;
    private void LoadLengthText() =>
        this.lenghtText = transform.Find("Game").Find("Length_Text").GetComponent<Text>();

    [SerializeField] private float heightScaleBox;
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

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        UIController.instance = this;
    }
}

