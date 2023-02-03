using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAnimation : MonoBehaviour
{

    public bool Adding;

    public float AnimationSpeed;

    void Update()
    {

        if(Adding == true)
        {
            this.gameObject.GetComponent<Slider>().value += Mathf.Cos(Time.time) * AnimationSpeed + 1;
        }
        else
        {
            this.gameObject.GetComponent<Slider>().value -= Mathf.Cos(Time.time) * AnimationSpeed + 1;
        }

    }

    public void Animate()
    {

        if(Adding == true)
        {
            Adding = false;
        }
        else
        {
            Adding = true;
        }

    }
}
