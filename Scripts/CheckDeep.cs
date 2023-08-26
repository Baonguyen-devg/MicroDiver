using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeep : AutoMonoBehaviour
{
    [SerializeField] private float rateDeep = default;
    [SerializeField] private int maxDeep = default;

    [SerializeField] protected Transform bottomSea;
    protected virtual void LoadBottomSea() =>
        this.bottomSea = GameObject.Find("Background")?.transform.Find("Bottom_Sea")?.transform;

    [SerializeField] private float firstDeep = default;
    [SerializeField] private List<Transform> listModel;
    protected virtual void LoadHeadPlayer() =>
        this.listModel = transform.parent.Find("Model")?.GetComponent<ListPrefab>().Prefabs;

    protected override void LoadComponent()
    {
        this.LoadBottomSea();
        this.LoadHeadPlayer();
    }
 
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        this.firstDeep = Mathf.Abs(this.listModel[0].localPosition.y) + 5;
        this.maxDeep = Mathf.Abs((int)this.bottomSea.localPosition.y) + 5;
    }

    private void Update()
    {
        float deep = Mathf.Abs(this.listModel[0].localPosition.y - this.firstDeep) / this.maxDeep;
        deep = Mathf.Clamp(deep, 0, 1);
        GameController.Instance.UpdateDeep(deep);
    }
}
