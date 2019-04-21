using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scr_ResetScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("r"))
        {
                TimerManager.main.AddTask(LoadScene, 1.1f);

                localFade.StartFadeOut();
        }
    }

    public FadeScreen localFade;

    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
