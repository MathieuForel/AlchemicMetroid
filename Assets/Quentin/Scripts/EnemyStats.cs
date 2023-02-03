using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField, Range(0f, 20f)] private float PV = 10f;

    public GameObject Poof;
    public GameObject EnnemyEssence;
    public int EssenceAmount;
    public float DamageTaken;

    public bool FireEnnemy;
    public bool WaterEnnemy;
    public bool GrassEnnemy;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "FireSpell" && GrassEnnemy == true)
        {
            TakeDamage(5);
        }

        if (collision.gameObject.tag == "GrassSpell" && WaterEnnemy == true)
        {
            TakeDamage(5);
        }

        if (collision.gameObject.tag == "WaterSpell" && FireEnnemy == true)
        {
            TakeDamage(5);
        }

        if (collision.gameObject.tag == "FireSpell" && WaterEnnemy == true)
        {
            TakeDamage(-5/2);
        }

        if (collision.gameObject.tag == "GrassSpell" && FireEnnemy == true)
        {
            TakeDamage(-5/2);
        }

        if (collision.gameObject.tag == "WaterSpell" && GrassEnnemy == true)
        {
            TakeDamage(-5/2);
        }
    }

    public void TakeDamage(float damage)
    {
        PV -= damage;
        DamageTaken = damage;

        if(PV <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        EssenceAmount = Random.Range(2, 5);
        Instantiate(Poof, this.gameObject.transform.position, this.gameObject.transform.rotation);

        for(int i = 0; i <= EssenceAmount; i++)
        {
            Instantiate(EnnemyEssence, new Vector3(Random.Range(this.gameObject.transform.position.x - 2, this.gameObject.transform.position.x + 2), Random.Range(this.gameObject.transform.position.y - 2, this.gameObject.transform.position.y + 2)), this.gameObject.transform.rotation);
        }


    }
}
