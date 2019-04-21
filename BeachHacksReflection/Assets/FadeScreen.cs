using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    SpriteRenderer CurrentSprite;
    public string TimerID;
    bool FadeIn=true;
    bool FadeOut=false;

    void Start()
    {
        CurrentSprite = GetComponent<SpriteRenderer>();
        TimerManager.main.AddTimer(1, out TimerID);
    }

    public void StartFadeOut(){
        TimerManager.main.OverrideTimer(TimerID, 1);
        FadeOut = true;
    }


    void Update()
    {
        if (FadeIn)
        {
            CurrentSprite.color = new Color(0, 0, 0, 1 - TimerManager.main.TimeSinceStart(TimerID));
            if (TimerManager.main.TimeSinceStart(TimerID) < 0)
            {
                FadeIn = false;
            }
        }
        if (FadeOut)
        {
            CurrentSprite.color = new Color(0, 0, 0, TimerManager.main.TimeSinceStart(TimerID) / 1f);
        }
    }
}
