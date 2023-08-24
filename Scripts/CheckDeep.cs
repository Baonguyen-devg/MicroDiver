using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeep : AutoMonoBehaviour
{
    [SerializeField] private float rateDeep = default;
    [SerializeField] private int maxDeep = default;

    [SerializeField] private float firstDeep = default;
    [SerializeField] private List<Transform> listModel;
    protected virtual void LoadHeadPlayer() =>
        this.listModel = transform.parent.Find("Model")?.GetComponent<ListPrefab>().Prefabs;

    protected override void LoadComponent() => this.LoadHeadPlayer();
 
    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        this.firstDeep = Mathf.Abs(this.listModel[0].localPosition.y);
    }

    private void Update()
    {
        int deep = (int)(Mathf.Abs(this.listModel[0].localPosition.y - this.firstDeep) / this.rateDeep);
        this.maxDeep = Mathf.Max(this.maxDeep, deep);
        GameController.Instance.UpdateDeep(this.maxDeep);
    }
}
