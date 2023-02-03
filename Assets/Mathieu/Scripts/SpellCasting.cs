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

    public GameObject PlayerBody;
    public void FireSpell()
    {
        Instantiate(FireSpellPrefab, new Vector3(this.gameObject.transform.position.x + this.gameObject.transform.localScale.x * (PlayerBody.transform.rotation.y - 0.5f) * -2, this.gameObject.transform.position.y), PlayerBody.transform.rotation);
    }

    public void GrassSpell()
    {
        Instantiate(GrassSpellPrefab, new Vector3(this.gameObject.transform.position.x + this.gameObject.transform.localScale.x * (PlayerBody.transform.rotation.y - 0.5f) * -2, this.gameObject.transform.position.y), PlayerBody.transform.rotation);
    }
    public void WaterSpell()
    {
        Instantiate(WaterSpellPrefab, new Vector3(this.gameObject.transform.position.x + this.gameObject.transform.localScale.x * (PlayerBody.transform.rotation.y - 0.5f) * -2, this.gameObject.transform.position.y), PlayerBody.transform.rotation);
    }

    public void MultiSpell()
    {
        Instantiate(MultiSpellPrefab, new Vector3(this.gameObject.transform.position.x + this.gameObject.transform.localScale.x * (PlayerBody.transform.rotation.y - 0.5f) * -2, this.gameObject.transform.position.y), PlayerBody.transform.rotation);
    }
}
