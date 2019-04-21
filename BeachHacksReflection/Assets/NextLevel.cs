﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string TargetLevel="1";
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
        SceneManager.LoadScene("Level_"+TargetLevel);
    }
}
