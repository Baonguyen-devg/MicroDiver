using UnityEngine;

public partial class GameController : AutoMonoBehaviour
{
    private static GameController instance;
    public static GameController Instance => instance;

    [SerializeField] private float maxDeepPresent = default;
    public float MaxDeepPresent => this.maxDeepPresent;

    [SerializeField] private ISubject subjectPointEnemySpawner;
    private void LoadSubjectPointEnemySpawner() =>
        this.subjectPointEnemySpawner = GameObject.Find("Points_Enemy_Spawner")?.GetComponent<ISubject>();

    [SerializeField] private int lengthPresent = default;

    private delegate void GetKeyEscapeHandler();
    private event GetKeyEscapeHandler GetKeyEscape;

    protected override void LoadComponent() => this.LoadSubjectPointEnemySpawner();

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        GameController.instance = this;
        Application.targetFrameRate = 60;
        this.GetKeyEscape += this.PauseGame;
    }
}
