using UnityEngine;
using UnityEngine.SceneManagement;

public partial class UIController : AutoMonoBehaviour
{
    public virtual void ChangeDeep(float rateDeep)
    {
        this.rateDeep = rateDeep;
        this.ChangeAnchoredPosition(rateDeep, this.pointDeepPresent);
        this.ChangeAnchoredPosition(GameController.Instance.MaxDeepPresent, this.pointDeepMax);
    }

    private void ChangeAnchoredPosition(float rateDeep, RectTransform pointDeep)
    {
        Vector2 newPositon = pointDeep.anchoredPosition;
        newPositon.y = -rateDeep * this.heightScaleBox;
        pointDeep.anchoredPosition = newPositon;
    }

    public virtual void ChangeLengthText(string textNumber) =>
        this.lenghtText.text = textNumber;

    public virtual void Pause() => this.pauseGameUI.SetActive(true);

    public virtual void Lose() => this.loseGameUI.SetActive(true);

    public virtual void Continue() => Time.timeScale = 1;

    public virtual void PlayAgain() => 
        this.LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex);

    public virtual void Menu() => 
        this.LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex - 1);

    private void LoadSceneByIndex(int index)
    {
        this.Continue();
        SceneManager.LoadScene(index);
    }

    public virtual void PlayClickAudio() => 
        SFXSpawner.Instance.PlaySound("Click_Button_Audio");
}

