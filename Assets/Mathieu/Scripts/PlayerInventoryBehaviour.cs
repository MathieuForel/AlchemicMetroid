using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerInventoryBehaviour : MonoBehaviour
{
    public int FireEssenceStock;
    public int GrassEssenceStock;
    public int WaterEssenceStock;

    public void FixedUpdate()
    {
        this.gameObject.transform.GetChild(0).GetComponentInChildren<TextMesh>().text = FireEssenceStock.ToString();
        this.gameObject.transform.GetChild(1).GetComponentInChildren<TextMesh>().text = GrassEssenceStock.ToString();
        this.gameObject.transform.GetChild(2).GetComponentInChildren<TextMesh>().text = WaterEssenceStock.ToString();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            FireEssenceStock += 1;

        }

        if (collision.gameObject.tag == "Grass")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            GrassEssenceStock += 1;

        }

        if (collision.gameObject.tag == "Water")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            WaterEssenceStock += 1;

        }
    }
}
