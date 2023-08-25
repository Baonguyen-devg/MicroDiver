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
        this.firstDeep = Mathf.Abs(this.listModel[0].localPosition.y);
        this.maxDeep = Mathf.Abs((int)this.bottomSea.localPosition.y);
    }

    private void Update()
    {
        float deep = Mathf.Abs(this.listModel[0].localPosition.y - this.firstDeep) / this.maxDeep;
        GameController.Instance.UpdateDeep(deep);
    }
}
