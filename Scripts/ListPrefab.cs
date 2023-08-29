using System.Collections.Generic;
using UnityEngine;

public class ListPrefab : AutoMonoBehaviour
{
    [SerializeField] private List<Transform> prefabs = new List<Transform>();
    public List<Transform> Prefabs => this.prefabs;
    public virtual void LoadPrefabs()
    {
        this.prefabs.Clear();
        foreach (Transform prefab in transform)
            this.prefabs.Add(prefab);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
    }
}
