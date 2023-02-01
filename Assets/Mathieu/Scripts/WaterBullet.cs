using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    public float LifeSpan;
    public float Life;

    public float Speed;
    public float MaxSize;
    public float MaxSizeModification;

    public SpriteRenderer _SpriteRenderer;
    public GameObject Poof;
    public void Start()
    {
        Life = LifeSpan;
        _SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        this.gameObject.transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
        this.gameObject.transform.localScale += new Vector3(-1.1f + (MaxSize * 5) / this.gameObject.transform.localScale.x, 1.1f - this.gameObject.transform.localScale.y / (MaxSize * 10), 0) * MaxSizeModification;
        LifeSpanManager();
        if(this.gameObject.GetComponent<Collider>().isTrigger == true)
        {
            this.gameObject.GetComponent<Collider>().isTrigger = false;
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
        if (collision.gameObject.layer == 6 )
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

        if (collision.gameObject.tag == "player")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "platform")
        {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>(), true);
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
