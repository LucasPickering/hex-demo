using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private string message;
    private Renderer ren;
    public GUIStyle labelStyle;

    void Start()
    {
        this.ren = this.GetComponentInChildren<Renderer>();
    }

    void OnGUI()
    {
        var pos = Input.mousePosition;
        GUI.Label(new Rect(pos.x, pos.y, 200, 30), this.message, this.labelStyle);
    }

    void OnMouseEnter()
    {
        this.message = this.transform.position.ToString();
        this.ren.material.color = Color.red;
    }

    void OnMouseExit()
    {
        this.message = "";
        this.ren.material.color = Color.white;
    }
}
