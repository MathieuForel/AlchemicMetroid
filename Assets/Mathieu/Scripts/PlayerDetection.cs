using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "player")
        {
            this.gameObject.transform.parent.GetComponent<EnnemyRoamingBehaviour>().PlayerDetected();
            this.gameObject.transform.parent.GetComponent<EnnemyFightingBehaviour>().PlayerDetected();
        }
    }
}
