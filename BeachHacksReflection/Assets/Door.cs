using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Doors
{
    public class Door : MonoBehaviour
    {
        public bool Locked = true;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public void Unlock()
        {
            Locked = false;
            GetComponent<Animator>().SetBool("Locked", false);
            GetComponent<Collider>().enabled = false;
        }

        
    }
}
