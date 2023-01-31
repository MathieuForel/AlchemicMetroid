using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceSelected : MonoBehaviour
{

    public bool FireEssence;
    public bool GrassEssence;
    public bool WaterEssence;

    public GameObject FireSprite;
    public GameObject GrassSprite;
    public GameObject WaterSprite;

    public PlayerInventoryBehaviour PlayerInventory;

    public void Start()
    {
        PlayerInventory = GameObject.FindWithTag("player").gameObject.GetComponent<PlayerInventoryBehaviour>();
    }

    public void FireEssenceClicked()
    {
        if (FireEssence == true && PlayerInventory.FireEssenceStock > 0)
        {
            ResetEssenceClicked();
        }
        else
        {
            ResetEssenceClicked();
            FireEssence = true;
            FireSprite.SetActive(true);
        }

        this.gameObject.transform.parent.GetComponent<CauldronSpelllBehaviour>().EssenceUpdate();
    }

    public void GrassEssenceClicked()
    {
        if(GrassEssence == true && PlayerInventory.GrassEssenceStock > 0) 
        {
            ResetEssenceClicked();
        }
        else
        {
            ResetEssenceClicked();
            GrassEssence = true;
            GrassSprite.SetActive(true);
        }

        this.gameObject.transform.parent.GetComponent<CauldronSpelllBehaviour>().EssenceUpdate();
    }

    public void WaterEssenceClicked()
    {
        if (WaterEssence == true && PlayerInventory.WaterEssenceStock > 0)
        {
            ResetEssenceClicked();
        }
        else
        {
            ResetEssenceClicked();
            WaterEssence = true;
            WaterSprite.SetActive(true);
        }

        this.gameObject.transform.parent.GetComponent<CauldronSpelllBehaviour>().EssenceUpdate();
    }

    public void ResetEssenceClicked()
    {
        FireEssence = false;
        GrassEssence = false;
        WaterEssence = false;
        FireSprite.SetActive(false);
        GrassSprite.SetActive(false);
        WaterSprite.SetActive(false);

        this.gameObject.transform.parent.GetComponent<CauldronSpelllBehaviour>().EssenceUpdate();
    }
}
