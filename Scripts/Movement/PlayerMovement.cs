using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    private const float default_Distance_Body = 1f;

    [SerializeField] private List<Transform> listModel;
    protected virtual void LoadHeadPlayer() =>
        this.listModel = transform.parent.Find("Model")?.GetComponent<ListPrefab>().Prefabs;

    [SerializeField] private float distanceBody = default_Distance_Body;

    protected override void LoadComponent() => this.LoadHeadPlayer();

    protected override void Update()
    {
        Vector3 mousePosition = InputController.Instance.GetMousePosition();
        this.LookAtTarget(mousePosition, this.listModel[0]);
        this.Move(this.listModel[0]);

        for (int i = 1; i < this.listModel.Count; i++)
        {
            this.LookAtTarget(this.listModel[i - 1].position, this.listModel[i]);
            if (Vector3.Distance(this.listModel[i].position, this.listModel[i - 1].position) <= this.distanceBody) continue;
            this.Move(this.listModel[i]);
        }
    }

    protected virtual void LookAtTarget(Vector3 direction, Transform objectMove)
    {
        Vector3 diff = direction - objectMove.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        objectMove.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }

    protected virtual void Move(Transform objectMove) =>
        objectMove.Translate(Vector3.up * this.speed * Time.fixedDeltaTime);

    protected override void Move() { /*FOR OVERRIDE*/ }
}
