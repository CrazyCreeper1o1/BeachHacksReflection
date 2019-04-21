using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int TargetLevel=1;
    public string NextScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Scr_PlayerCamera>() != null)
        {
            TimerManager.main.AddTask(LoadScene, 1.1f);

            localFade.StartFadeOut();
        }
    }

    public FadeScreen localFade;

    void LoadScene()
    {
        SceneManager.LoadScene(NextScene);
    }
}
