using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerSoundEffects : MonoBehaviour
{
    AudioSource Walk;

    // Start is called before the first frame update
    void Start()
    {
        Walk = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk.volume = GetComponent<CharacterController>().velocity.magnitude;

        Walk.pitch = Mathf.Sin(Time.time/4)/16+.8f;
    }
}
