using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryBehaviour : MonoBehaviour
{
    public int FireEssenceStock;
    public int GrassEssenceStock;
    public int WaterEssenceStock;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fire")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            FireEssenceStock += 1;
            this.gameObject.transform.GetChild(0).GetComponentInChildren<TextMesh>().text = FireEssenceStock.ToString();
        }

        if (collision.gameObject.tag == "grass")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            GrassEssenceStock += 1;
            this.gameObject.transform.GetChild(1).GetComponentInChildren<TextMesh>().text = GrassEssenceStock.ToString();
        }

        if (collision.gameObject.tag == "water")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            WaterEssenceStock += 1;
            this.gameObject.transform.GetChild(2).GetComponentInChildren<TextMesh>().text = WaterEssenceStock.ToString();
        }
    }
}