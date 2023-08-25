using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSpawner : Spawner
{ 
    private static VFXSpawner instance;
    public static VFXSpawner Instance => instance;

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        VFXSpawner.instance = this;
    }
}
