using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBody : AutoMonoBehaviour
{
    private static IncreaseBody instance;
    public static IncreaseBody Instance => instance;

    [SerializeField] private List<Transform> bodyPrefabs;
    protected virtual void LoadBodyPrefabs() =>
        this.bodyPrefabs = gameObject.GetComponent<ListPrefab>().Prefabs;

    protected override void LoadComponent() => this.LoadBodyPrefabs();

    protected override void LoadComponentInAwakeAfter() => IncreaseBody.instance = this;

    public virtual void Increase()
    {
        Transform newBody = Instantiate(this.bodyPrefabs[this.bodyPrefabs.Count - 2]);
        newBody.name = this.bodyPrefabs[this.bodyPrefabs.Count - 2].name;

        newBody.SetParent(transform);
        gameObject.GetComponent<ListPrefab>().LoadPrefabs();
    }
}
