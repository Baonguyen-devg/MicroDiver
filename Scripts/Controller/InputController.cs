using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : AutoMonoBehaviour
{
    private static InputController instance;
    public static InputController Instance => instance;

    protected override void LoadComponentInAwakeAfter()
    {
        base.LoadComponentInAwakeAfter();
        InputController.instance = this;
    }

    public virtual Vector3 GetMousePosition() => 
        Camera.main.ScreenToWorldPoint(Input.mousePosition);      
}
