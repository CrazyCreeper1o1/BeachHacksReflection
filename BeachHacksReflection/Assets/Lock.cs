using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Doors
{
    public class Lock : MonoBehaviour
    {
        public bool Locked=true;

        private void OnCollisionEnter(Collision collision)
        {
            if (!Locked) { return; }



            if (IsGhost(collision.gameObject.layer) == IsGhost(gameObject.layer))
            {


                Scr_Item ItemScript = collision.collider.gameObject.GetComponent<Scr_Item>();
                if (ItemScript != null)
                {
                    if (ItemScript.ItemID == Scr_Item.ItemList.Key)
                    {
                        Destroy(ItemScript.gameObject);
                        UnlockLock();
                    }
                }
            }
        }
        public void UnlockLock()
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().velocity = transform.forward * 5;

            Locked = false;
        }

        public bool IsGhost(LayerMask _layer)
        {
            if (_layer == 14)
            {
                return true;
            }
            if (_layer == 16)
            {
                return true;
            }
            if (_layer == 18)
            {
                return true;
            }
            if (_layer == 19)
            {
                return true;
            }
            return false;
        }
    }
}