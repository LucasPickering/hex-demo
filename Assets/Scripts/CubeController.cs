using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GUIStyle labelStyle;
    public Color defaultColor = Color.white;
    public Color highlightColor = Color.red;

    private string message;
    private Renderer rend;

    void Start()
    {
        this.rend = this.GetComponentInChildren<Renderer>();
        this.rend.material.color = this.defaultColor;
    }

    void OnGUI()
    {
        var pos = Input.mousePosition;
        GUI.Label(new Rect(30, 30, 200, 30), this.message, this.labelStyle);
    }

    void OnMouseEnter()
    {
        var pos = this.transform.position;
        // Unity treats Y as vertical, but the hex system uses Z as vertical
        this.message = String.Format("({0}, {1}, {2})", (int)pos.x, (int)pos.z, (int)pos.y);
        this.rend.material.color = this.highlightColor;
    }

    void OnMouseExit()
    {
        this.message = "";
        this.rend.material.color = this.defaultColor;
    }
}
