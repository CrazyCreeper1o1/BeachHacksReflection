using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public FadeScreen localFade;
    private void OnMouseDown()
    {
        TimerManager.main.AddTask(LoadScene, 1.1f);

        localFade.StartFadeOut();
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Level_1");
    }
}
