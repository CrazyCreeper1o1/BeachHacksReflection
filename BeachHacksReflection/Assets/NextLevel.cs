using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
<<<<<<< HEAD
    public string TargetLevel="1";
=======
    public int TargetLevel=1;
    public string NextScene;
>>>>>>> ad06adb5b6f44395823942ed09854b79ca676f00
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
