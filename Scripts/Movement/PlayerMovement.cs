using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    private const float default_Distance_Body = 1f;

    [SerializeField] private List<Transform> listModel;
    private void LoadHeadPlayer() =>
        this.listModel = transform.parent.Find("Model")?.GetComponent<ListPrefab>().Prefabs;

    [SerializeField] private float distanceBody = default_Distance_Body;

    protected override void LoadComponent() => this.LoadHeadPlayer();

    protected override void Update()
    {
        if (Time.timeScale == 0) return;
        Vector3 mousePosition = InputController.Instance.GetMousePosition();
        this.LookAtTarget(mousePosition, this.listModel[0]);
        this.Move(this.listModel[0], mousePosition);

        for (int i = 1; i < this.listModel.Count; i++)
        {
            this.LookAtTarget(this.listModel[i - 1].position, this.listModel[i]);
            this.Move(this.listModel[i], this.listModel[i - 1].position);
        }
    }

    private void LookAtTarget(Vector3 direction, Transform objectMove)
    {
        Vector3 diff = direction - objectMove.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        objectMove.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }

    private void Move(Transform objectMove, Vector3 target)
    {
        if (Vector3.Distance(objectMove.position, target) <= this.distanceBody) this.speed = 0.015f;
        else this.speed = 0.04f;
        Vector3 direc = target - objectMove.position;
        direc.z = 0; direc.Normalize();
        objectMove.position = Vector3.Lerp(objectMove.position, objectMove.position + direc, this.speed);
    }

    protected override void Move() { /*FOR OVERRIDE*/ }
}
