using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    public GameObject FireSpellPrefab;
    public GameObject GrassSpellPrefab;
    public GameObject WaterSpellPrefab;
    public GameObject MultiSpellPrefab;

    public void FireSpell()
    {
        Instantiate(FireSpellPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }

    public void GrassSpell()
    {
        Instantiate(GrassSpellPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }

    public void WaterSpell()
    {
        Instantiate(WaterSpellPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }

    public void MultiSpell()
    {
        Instantiate(MultiSpellPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
