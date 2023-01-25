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

    public void FireEssenceClicked()
    {
        if (FireEssence == true)
        {
            ResetEssenceClicked();
        }
        else
        {
            ResetEssenceClicked();
            FireEssence = true;
            FireSprite.SetActive(true);
        }
    }

    public void GrassEssenceClicked()
    {
        if(GrassEssence == true) 
        {
            ResetEssenceClicked();
        }
        else
        {
            ResetEssenceClicked();
            GrassEssence = true;
            GrassSprite.SetActive(true);
        }
    }

    public void WaterEssenceClicked()
    {
        if (WaterEssence == true)
        {
            ResetEssenceClicked();
        }
        else
        {
            ResetEssenceClicked();
            WaterEssence = true;
            WaterSprite.SetActive(true);
        }
    }

    public void ResetEssenceClicked()
    {
        FireEssence = false;
        GrassEssence = false;
        WaterEssence = false;
        FireSprite.SetActive(false);
        GrassSprite.SetActive(false);
        WaterSprite.SetActive(false);
    }
}
