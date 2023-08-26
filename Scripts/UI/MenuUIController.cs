using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : AutoMonoBehaviour
{
    [SerializeField] private AudioSource clickAudio;
    private void LoadClickAudio() =>
        this.clickAudio = GameObject.Find("Button_Audio_Source")?.GetComponent<AudioSource>();

    protected override void LoadComponent() => this.LoadClickAudio();

    public virtual void PlayGame()
    {
        this.clickAudio.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public virtual void QuitGame()
    {
        this.clickAudio.Play();
        Application.Quit();
    }

    public virtual void PlayClickAudio() => this.clickAudio.Play();
}
