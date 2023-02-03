using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            this.gameObject.transform.parent.GetComponent<EnnemyRoamingBehaviour>().PlayerDetected();
            this.gameObject.transform.parent.GetComponent<EnnemyFightingBehaviour>().PlayerDetected();
        }
    }
}
