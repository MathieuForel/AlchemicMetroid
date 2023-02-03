using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyRoamingBehaviour : MonoBehaviour
{

    public float Speed;
    public float Stop;
    public float WaitingTime;
    public float StayWaiting;
    public float Range;
    public float MaxDistance;

    public float facing;

    public Vector3 Destination;


    public void Start()
    {
        StayWaiting = (MaxDistance * WaitingTime) / Speed;
        SetNewDestination();
    }

    public void Update()
    {

        Stop += Time.deltaTime;

        this.gameObject.transform.position = Vector3.MoveTowards(transform.position, Destination, Speed * 0.1f * Time.deltaTime);
        
        if(Vector3.Distance(this.gameObject.transform.position, Destination) < Range)
        {


            if (WaitingTime < Stop)
            {
                Destination = this.gameObject.transform.position;
                StayWaiting -= Time.deltaTime;
            }
            else
            {
                SetNewDestination();
            }

        }

        if (StayWaiting < 0)
        {
            SetNewDestination();
            Stop = 0;
            StayWaiting = (MaxDistance * WaitingTime) / Speed;
        }
    }

    public void SetNewDestination()
    {
        Destination = new Vector3(Random.Range(-MaxDistance, MaxDistance), Random.Range(-MaxDistance, MaxDistance));

        if((Destination.x - this.gameObject.transform.position.x) > 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        else
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(Stop <= 0)
        {
            SetNewDestination();
        }
    }

    public void PlayerDetected()
    {
        Stop = 100;
        StayWaiting = 3;
    }
}
