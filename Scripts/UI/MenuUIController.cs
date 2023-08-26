using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : AutoMonoBehaviour
{
    public virtual void PlayGame() =>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public virtual void QuitGame() => Application.Quit();
}
