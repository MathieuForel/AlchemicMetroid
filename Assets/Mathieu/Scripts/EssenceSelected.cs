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
    public CauldronSpellBehaviour Cauldron;

    public void Start()
    {
        PlayerInventory = GameObject.FindWithTag("player").gameObject.GetComponent<PlayerInventoryBehaviour>();
        Cauldron = this.gameObject.transform.parent.gameObject.GetComponent<CauldronSpellBehaviour>();
    }

    public void FireEssenceClicked()
    {
        if (PlayerInventory.FireEssenceStock > Cauldron.FireEssenceAmount && FireEssence == false)
        {
            ResetEssenceClicked();
            FireEssence = true;
            FireSprite.SetActive(true);
        }
        else
        {
            if (FireEssence == true)
            {
                ResetEssenceClicked();
            }
        } 

        this.gameObject.transform.parent.GetComponent<CauldronSpellBehaviour>().EssenceUpdate();
    }

    public void GrassEssenceClicked()
    {
        if (PlayerInventory.GrassEssenceStock > Cauldron.GrassEssenceAmount && GrassEssence == false)
        {
            ResetEssenceClicked();
            GrassEssence = true;
            GrassSprite.SetActive(true);
        }
        else
        {
            if (GrassEssence == true)
            {
                ResetEssenceClicked();
            }
        }

        this.gameObject.transform.parent.GetComponent<CauldronSpellBehaviour>().EssenceUpdate();
    }

    public void WaterEssenceClicked()
    {
        if (PlayerInventory.WaterEssenceStock > Cauldron.WaterEssenceAmount && WaterEssence == false)
        {
            ResetEssenceClicked();
            WaterEssence = true;
            WaterSprite.SetActive(true);
        }
        else
        {
            if (WaterEssence == true)
            {
                ResetEssenceClicked();
            }
        }

        this.gameObject.transform.parent.GetComponent<CauldronSpellBehaviour>().EssenceUpdate();
    }

    public void ResetEssenceClicked()
    {
        FireEssence = false;
        GrassEssence = false;
        WaterEssence = false;
        FireSprite.SetActive(false);
        GrassSprite.SetActive(false);
        WaterSprite.SetActive(false);

        this.gameObject.transform.parent.GetComponent<CauldronSpellBehaviour>().EssenceUpdate();
    }
}
