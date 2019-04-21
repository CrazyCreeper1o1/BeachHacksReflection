using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int TargetLevel=1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Scr_PlayerCamera>() != null)
        {
            SceneManager.LoadScene("Level_" + TargetLevel);
        }
    }
}
