using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LifeSpan;
    public float Life;

    public float Speed;

    public SpriteRenderer _SpriteRenderer;
    public GameObject Poof;
    public void Start()
    {
        Life = LifeSpan;
        _SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));

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
    }

    public void OnDestroy()
    {
        Instantiate(Poof, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
