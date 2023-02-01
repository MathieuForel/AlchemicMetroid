using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float LifeSpan;
    public float Life;

    public float Speed;
    public float SideValue;
    public float SideSpeed;

    public SpriteRenderer _SpriteRenderer;
    public GameObject Poof;
    public void Start()
    {
        Life = LifeSpan;
        _SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        this.gameObject.transform.Translate(new Vector3(Speed * Time.deltaTime, Mathf.Cos(Time.time * SideSpeed) * SideValue, 0));

        Debug.Log(Mathf.Cos(Time.time * SideValue));
        LifeSpanManager();
    }

    public void LifeSpanManager()
    {
        Life -= Time.deltaTime;
        if (Life < 0)
        {
            Destroy(this.gameObject);
        }

        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(_SpriteRenderer.color.r, _SpriteRenderer.color.g, _SpriteRenderer.color.b, Life / LifeSpan);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "player")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "ennemy")
        {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>(), true);
        }
    }

    public void OnDestroy()
    {
        Instantiate(Poof, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
