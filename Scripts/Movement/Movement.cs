using UnityEngine;

public abstract class Movement : AutoMonoBehaviour
{
    protected const float default_Speed = 1f;
    protected const float default_Maximum_Speed = 10;
    protected const float default_Minimum_Speed = 0.01f;

    [SerializeField] protected float speed = default_Speed;
    [SerializeField] protected float maximumSpeed = default_Maximum_Speed;
    [SerializeField] protected float minimumSpeed = default_Minimum_Speed;

    [SerializeField] protected bool isMovingFast = false;

    protected virtual void Update() => this.Move();

    public virtual void IncreaseSpeed(float speed) =>
        this.speed = Mathf.Min(a: this.maximumSpeed, b: this.speed + speed);

    public virtual void DecreaseSpeed(float speed) =>
        this.speed = Mathf.Max(a: this.minimumSpeed, b: this.speed - speed);

    protected abstract void Move();
}
