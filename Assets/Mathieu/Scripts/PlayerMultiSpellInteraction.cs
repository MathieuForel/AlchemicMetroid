using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultiSpellInteraction : MonoBehaviour
{
    public float Power;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MultiSpell")
        {
            this.gameObject.transform.position += Vector3.up * Time.deltaTime * Power;
        }
    }
}
