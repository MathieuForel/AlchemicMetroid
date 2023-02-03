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
        PlayerPosition = this.transform.position;
        SphereColliderRadius = this.gameObject.GetComponent<CircleCollider2D>().radius;
        EssencePosition = this.gameObject.transform.position;
    }

    public void Update()
    {
        EssencePosition = this.gameObject.transform.position;

        if (TouchedPlayer == true)
        {
            this.gameObject.transform.position -=  (EssencePosition - PlayerPosition) * Time.deltaTime * (SphereColliderRadius / (PlayerDistance + 0.5f));
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            TouchedPlayer = true;
            Player = other.gameObject;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player = other.gameObject;
            PlayerPosition = other.transform.position;
            PlayerDistance = Mathf.Abs((PlayerPosition.x - EssencePosition.x) + (PlayerPosition.y - EssencePosition.y));
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            TouchedPlayer = false;
        }
    }
}
