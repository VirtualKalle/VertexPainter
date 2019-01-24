using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colorbutton : MonoBehaviour {


    [SerializeField] VertexPaint vertexPaint;
    [SerializeField] Image BrushIcon;
    
    public void SetBrushColor()
    {
        Color selectedColor = GetComponent<Button>().colors.normalColor;
        vertexPaint.SetColor(selectedColor);
        BrushIcon.color = selectedColor;
    }
    
}
