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
    public Gradient gradient;
    private RectTransform rectTransform;
    
    //3FE847
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
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
