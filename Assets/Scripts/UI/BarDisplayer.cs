using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarDisplayer : MonoBehaviour
{
    private RectTransform barInner;
    private float maxWidth;

    void Start()
    {
        barInner = this.transform.GetChild(0).GetComponent<RawImage>().rectTransform;
        maxWidth = barInner.sizeDelta.x;
    }

    public void UpdateBar(float currentPercentage)
    {
        barInner.sizeDelta = new Vector2(currentPercentage * maxWidth, barInner.sizeDelta.y);
    }
}
