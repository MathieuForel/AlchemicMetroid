using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFightingBehaviour : MonoBehaviour
{
    public GameObject Player;
    public float Angle;
    public float Range;
    public float Cooldown;
    public float Coolingdown;
    public Vector3 Direction;

    public GameObject ShootPattern;

    public GameObject Bullet;

    public void Start()
    {
        ShootPattern = this.gameObject.transform.GetChild(0).gameObject;
    }

    public void FixedUpdate()
    {
        Coolingdown -= Time.deltaTime;
    }


    public void PlayerDetected()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Direction = Player.transform.position - this.gameObject.transform.position;
        Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        ShootPattern.transform.rotation = Quaternion.Euler(0, 0, Random.Range(Angle - Range, Angle + Range));
        
        if(Coolingdown <= 0)
        {
            shoot();
            Coolingdown = Cooldown;
        }
    }

    public void shoot()
    {
        for(int i = 0; i < ShootPattern.transform.childCount; i++)
        {
            Instantiate(Bullet, ShootPattern.transform.GetChild(i).position, ShootPattern.transform.GetChild(i).transform.rotation);
        }
    }
}
