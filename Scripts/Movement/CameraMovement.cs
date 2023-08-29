using UnityEngine;

public class CameraMovement : Movement
{
    private const float default_Distance_Stop = 5f;
    [SerializeField] private float distanceStop = default_Distance_Stop;

    [SerializeField] private Transform headPlayer;
    private void LoadPlayer() =>
        this.headPlayer = GameObject.Find("Player").transform.Find("Model")?.Find("Head");

    [SerializeField] private Transform bottomSea;
    private void LoadBottomSea() =>
        this.bottomSea = GameObject.Find("Background")?.transform.Find("Bottom_Sea")?.transform;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
        this.LoadBottomSea();
    }

    protected override void Move()
    {
        if (!this.CanMove()) return;
        Vector3 pos = new Vector3(transform.localPosition.x, this.headPlayer.localPosition.y, -10);;
        transform.parent.position = Vector3.MoveTowards(transform.position, pos, this.speed);
    }

    private bool CanMove()
    {
        if (this.headPlayer.localPosition.y >= 0) return false;
        if (this.headPlayer.localPosition.y <= this.bottomSea.localPosition.y + this.distanceStop) return false;
        return true;
    }
}