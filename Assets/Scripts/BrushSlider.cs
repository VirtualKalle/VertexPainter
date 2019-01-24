using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BrushSlider : MonoBehaviour {

    [SerializeField] VertexPaint vertexPaint;
    [SerializeField] RectTransform iconRect;
    private Vector2 initialIconRect;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        initialIconRect = iconRect.sizeDelta;
        SetIconSize();
        GetSetBrushSize();
    }

    public void GetSetBrushSize()
    {
        vertexPaint.SetBrushSize(slider.value * 0.3f);
    }

    public void SetIconSize()
    {
        
        iconRect.sizeDelta = initialIconRect * (0.2f + slider.value/slider.maxValue);
    }

}
