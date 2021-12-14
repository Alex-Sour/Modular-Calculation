using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    public float charge = 1f;
    public float dischargeSpeed = 0.05f;
    public float minHeight = 0.0f;
    public float maxHeight = 114f;
    Gradient gradient;
    public Color minColor;
    public Color middleColor;
    public Color maxColor;
    private RectTransform rectTransform;
    
    //3FE847
    // Start is called before the first frame update
    void Start()
    {
        gradient = new Gradient();
        rectTransform = GetComponent<RectTransform>();
        GradientColorKey[] gck = new GradientColorKey[3];
        GradientAlphaKey[] gak = new GradientAlphaKey[2];
        gck[0].color = minColor;
        gck[0].time = 0.0F;
        gck[2].color = maxColor;
        gck[2].time = 1.0F;
        gck[1].color = middleColor;
        gck[1].time = 0.5F;
        gak[1].alpha = 1.0F;
        gak[1].time = 1.0F;
        gak[0].alpha = 1.0F;
        gak[0].time = 0.0F;
    gradient.SetKeys(gck, gak);
    }

    // Update is called once per frame
    void Update()
    {
        if (charge > 0)
        {
            charge -= dischargeSpeed * Time.deltaTime;
            if (charge < 0)
            {
                charge = 0;
            }
        }
        else
        {
            charge = 0;
        }
        Color color = gradient.Evaluate(charge);
        gameObject.GetComponent<Image>().color = color;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, Mathf.Lerp(minHeight, maxHeight, charge));
    }
}
