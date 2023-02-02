using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronSpellBehaviour : MonoBehaviour
{

    public EssenceSelected Slot1;
    public EssenceSelected Slot2;
    public EssenceSelected Slot3;

    public int FireEssenceAmount;
    public int GrassEssenceAmount;
    public int WaterEssenceAmount;

    public GameObject Player;
    public PlayerInventoryBehaviour PlayerInventory;
    public SpellCasting PlayerSpell; 

    public GameObject FireBall;
    public GameObject Thorns;
    public GameObject Nimbus;
    public GameObject Geyser;

    public void Start()
    {
        Slot1 = this.gameObject.transform.GetChild(0).GetComponent<EssenceSelected>();
        Slot2 = this.gameObject.transform.GetChild(1).GetComponent<EssenceSelected>();
        Slot3 = this.gameObject.transform.GetChild(2).GetComponent<EssenceSelected>();

        EssenceUpdate();

        Player = GameObject.FindWithTag("player").gameObject;
        PlayerInventory = GameObject.FindWithTag("player").gameObject.GetComponent<PlayerInventoryBehaviour>();
        PlayerSpell = GameObject.FindWithTag("player").gameObject.GetComponent<SpellCasting>();
    }


    public void EssenceUpdate()
    {
        FireEssenceAmount = 0;
        GrassEssenceAmount = 0;
        WaterEssenceAmount = 0;


        if (Slot1.FireEssence) { FireEssenceAmount += 1; }
        if (Slot2.FireEssence) { FireEssenceAmount += 1; }
        if (Slot3.FireEssence) { FireEssenceAmount += 1; }

        if (Slot1.GrassEssence) { GrassEssenceAmount += 1; }
        if (Slot2.GrassEssence) { GrassEssenceAmount += 1; }
        if (Slot3.GrassEssence) { GrassEssenceAmount += 1; }

        if (Slot1.WaterEssence) { WaterEssenceAmount += 1; }
        if (Slot2.WaterEssence) { WaterEssenceAmount += 1; }
        if (Slot3.WaterEssence) { WaterEssenceAmount += 1; }
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            SpellActivation();
        }
    }

    public void SpellActivation()
    {
        if(FireEssenceAmount == 3)
        {
            FireSpell();
        }

        if (GrassEssenceAmount == 3)
        {
            GrassSpell();
        }

        if (WaterEssenceAmount == 3)
        {
            WaterSpell();
        }

        if (FireEssenceAmount == 1 && GrassEssenceAmount == 1 && WaterEssenceAmount == 1)
        {
            MultiSpell();
        }
    }

    public void FireSpell()
    {
        PlayerInventory.FireEssenceStock -= 3;
        PlayerSpell.FireSpell();
        UsedSpell();
    }

    public void GrassSpell()
    {
        PlayerInventory.GrassEssenceStock -= 3;
        PlayerSpell.GrassSpell();
        UsedSpell();
    }

    public void WaterSpell()
    {
        PlayerInventory.WaterEssenceStock -= 3;
        PlayerSpell.WaterSpell();
        UsedSpell();
    }

    public void MultiSpell()
    {
        PlayerInventory.FireEssenceStock -= 1;
        PlayerInventory.GrassEssenceStock -= 1;
        PlayerInventory.WaterEssenceStock -= 1;
        PlayerSpell.MultiSpell();
        UsedSpell();
    }

    public void UsedSpell()
    {
        Slot1.ResetEssenceClicked();
        Slot2.ResetEssenceClicked();
        Slot3.ResetEssenceClicked();
        EssenceUpdate();
    }
}
