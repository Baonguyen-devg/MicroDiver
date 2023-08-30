using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeep : AutoMonoBehaviour
{
    [SerializeField] private int maxDeep = default;
    [SerializeField] private float firstDeep = default;

    /*Begin predicatedload of components*/
    [SerializeField] private List<Action> predicateLoad;

    [SerializeField] private Transform bottomSea;
    [SerializeField] private List<Transform> listModel;
    /*End predicatedload of components*/

    protected override void LoadComponent()
    {
        predicateLoad = new List<Action>
        {
            () => this.bottomSea = GameObject.Find("Background")?.transform.Find("Bottom_Sea")?.transform,
            () => this.listModel = transform.parent.Find("Model")?.GetComponent<ListPrefab>().Prefabs
        };

        foreach (var predicate in predicateLoad)
            predicate?.Invoke();
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
