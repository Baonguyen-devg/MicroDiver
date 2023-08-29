using UnityEngine;

public partial class PlayerController : AutoMonoBehaviour
{
    [SerializeField] private Transform model;
    public Transform Model => this.model;
    private void LoadModel() =>
        this.model = transform.Find("Model");

    [SerializeField] private PlayerMovement movement;
    public PlayerMovement Movement => this.movement;
    private void LoadMovement() =>
        this.movement = transform.Find("Movement")?.GetComponent<PlayerMovement>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMovement();
        this.LoadModel();
    }
}
