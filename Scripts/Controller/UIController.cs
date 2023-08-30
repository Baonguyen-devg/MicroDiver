using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class UIController : AutoMonoBehaviour
{
    private const float DEFAULT_RATE_DEEP = 0;

    private static UIController instance;
    public static UIController Instance => instance;

    private float rateDeep = DEFAULT_RATE_DEEP;
    public float RateDeep => this.rateDeep;

    /*Begin predicatedload of components*/
    [SerializeField] private List<Action> predicateLoad;

    [SerializeField] private GameObject pauseGameUI;
    [SerializeField] private GameObject loseGameUI;
   
    [SerializeField] private Text lenghtText;
    [SerializeField] private float heightScaleBox;
    [SerializeField] private RectTransform pointDeepPresent;

    [SerializeField] private RectTransform pointDeepMax;
    /*End predicatedload of components*/

    protected override void LoadComponent()
    {
        predicateLoad = new List<Action> 
        {
            () => this.pauseGameUI = transform.Find("Pause_Game").gameObject,
            () => this.loseGameUI = transform.Find("Lose_Game").gameObject,

            () => this.lenghtText = transform.Find("Game").Find("Length_Text").GetComponent<Text>(),
            () => this.heightScaleBox = transform.Find("Game").Find("Deep").Find("Scale_Box_Height_1").GetComponent<RectTransform>().rect.height,

            () => this.pointDeepPresent = transform.Find("Game").Find("Deep").Find("Point_Present").GetComponent<RectTransform>(),
            () => this.pointDeepMax = transform.Find("Game").Find("Deep").Find("Point_Max").GetComponent<RectTransform>()
        };

        foreach (var predicate in predicateLoad)
            predicate?.Invoke();
    }

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        UIController.instance = this;
    }
}

