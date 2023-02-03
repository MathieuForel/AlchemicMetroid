using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSpellBehaviour : MonoBehaviour
{
    public float LifeSpan;
    public float Life;

    public SpriteRenderer _SpriteRenderer;
    public GameObject Poof;
    void Start()
    {
        Life = LifeSpan;
        _SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "¨Player")
        {
            Destroy(this.gameObject);
        }
    }

    public void OnDestroy()
    {
        Instantiate(Poof, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
