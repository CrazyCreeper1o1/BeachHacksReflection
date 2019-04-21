using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientFlipper : MonoBehaviour
{
    public double currentTime;
    private AudioManager am;
    double speedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<AudioManager>();
        speedMultiplier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime * speedMultiplier;
        //Debug.Log("Current Time: " + currentTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentTime = (120 - currentTime);
        speedMultiplier = 0.8f;
        //Debug.Log("Time: " + currentTime);
        am.StopSound("Ambient");
        am.PlaySound("AmbientReverse", currentTime);
        
    }

    private void OnTriggerExit(Collider other)
    {
        currentTime = (120 - currentTime);
        speedMultiplier = 1f;
        //Debug.Log("Time: " + currentTime);
        am.StopSound("AmbientReverse");
        am.PlaySound("Ambient", currentTime);
        
    }

}
