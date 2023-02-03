using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofBehaviour : MonoBehaviour
{
    public float LifeSpan;
    public float Life;

    public void Start()
    {
        Life = LifeSpan;
    }

    void Update()
    {
        Life -= Time.deltaTime;
        if (Life < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
