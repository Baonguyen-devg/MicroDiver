using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AutoMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => this.model;
    protected virtual void LoadModel() =>
        this.model = transform?.Find("Model");

    [SerializeField] protected PlayerMovement movement;
    public PlayerMovement Movement => this.movement;
    protected virtual void LoadMovement() =>
        this.movement = transform?.Find("Movement")?.GetComponent<PlayerMovement>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMovement();
        this.LoadModel();
    }
}
