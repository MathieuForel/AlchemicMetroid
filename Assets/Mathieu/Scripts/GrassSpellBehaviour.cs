using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpellBehaviour : MonoBehaviour
{
    public float LifeSpan;
    public float Life;
    public float WaitTime;
    public float MaxWaitTime;

    public SpriteRenderer _SpriteRenderer;
    public GameObject GrassSpellPrefab;
    public GameObject Poof;
    void Start()
    {
        WaitTime = MaxWaitTime;
        Life = LifeSpan;
        _SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        LifeSpanManager();
        this.gameObject.transform.Translate(Vector3.right * Time.deltaTime);

        WaitTime -= Time.deltaTime;

        if (WaitTime < 0)
        {
            WaitTime = 10000;
            Duplicate();
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

    public void Duplicate()
    {
        WaitTime = 10000;
        Instantiate(GrassSpellPrefab, this.gameObject.transform.position, Quaternion.Euler(0, 0, this.gameObject.transform.right.z + 25), this.gameObject.transform);
        Instantiate(GrassSpellPrefab, this.gameObject.transform.position, Quaternion.Euler(0, 0, this.gameObject.transform.right.z - 25), this.gameObject.transform);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ennemy")
        {
            Destroy(this.gameObject);
        }
    }

    public void OnDestroy()
    {
        Instantiate(Poof, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
