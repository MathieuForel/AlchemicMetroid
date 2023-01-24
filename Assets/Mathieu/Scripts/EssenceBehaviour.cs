using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceBehaviour : MonoBehaviour
{

    public bool TouchedPlayer;
    public GameObject Player;
    public Vector3 PlayerPosition;
    public float PlayerDistance;
    public Vector3 EssencePosition;
    public float SphereColliderRadius;

    public void Start()
    {
        SphereColliderRadius = this.gameObject.GetComponent<SphereCollider>().radius;
        EssencePosition = this.gameObject.transform.position;
    }

    public void FixedUpdate()
    {

        EssencePosition = this.gameObject.transform.position;

        if (TouchedPlayer == true)
        {
            this.gameObject.transform.position -=  (EssencePosition - PlayerPosition) * Time.deltaTime * (SphereColliderRadius / (PlayerDistance + 0.5f));
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            TouchedPlayer = true;
            Player = other.gameObject;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "player")
        {
            Player = other.gameObject;
            PlayerPosition = other.transform.position;
            PlayerDistance = Mathf.Abs((PlayerPosition.x - EssencePosition.x) + (PlayerPosition.y - EssencePosition.y));
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            TouchedPlayer = false;
        }
    }
}
