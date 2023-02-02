using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpellBehaviour : MonoBehaviour
{
    public float LifeSpan;
    public float Life;
    public float WaitTime;
    public float MaxWaitTime;

    public SpriteRenderer _SpriteRenderer;
    public GameObject Poof;
    void Start()
    {
        WaitTime = MaxWaitTime;

        Life = LifeSpan;
        _SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        LifeSpanManager();
        WaitTime -= Time.deltaTime;

        if(WaitTime > 0)
        {
            this.gameObject.transform.Translate(new Vector3(1 * Time.deltaTime / 3, 1 * Time.deltaTime, 0));
        }
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
        if (collision.gameObject.tag != "player")
        {
            Destroy(this.gameObject);
        }
    }

    public void OnDestroy()
    {
        Instantiate(Poof, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
