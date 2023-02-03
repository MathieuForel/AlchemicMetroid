using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBullet : MonoBehaviour
{
    public float LifeSpan;
    public float Life;

    public float Speed;
    public float RotationRange;
    public float RotationCooldown;
    public float RotationCoolingdown;

    public float RandomRotation;
    public float RandomRotationCooldown;
    public float RandomRotationCoolingdown;

    public SpriteRenderer _SpriteRenderer;
    public GameObject Poof;
    public void Start()
    {
        Life = LifeSpan;
        _SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        RotationCoolingdown = RotationCooldown;
    }
    public void Update()
    {
        this.gameObject.transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));


        RandomRotationCoolingdown -= Time.deltaTime;

        if (RandomRotationCoolingdown <= 0)
        {
            RandomRotation = Mathf.Clamp(Random.Range(-RotationRange, RotationRange), RotationRange * -3, RotationRange * 3);
            RandomRotationCoolingdown = RandomRotationCooldown;
        }


        RotationCoolingdown -= Time.deltaTime;

        if(RotationCoolingdown <= 0)
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, RandomRotation));
            RotationCoolingdown = RotationCooldown;
        }

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
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    public void OnDestroy()
    {
        Instantiate(Poof, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
