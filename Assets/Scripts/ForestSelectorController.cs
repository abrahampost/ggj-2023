using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSelectorController : MonoBehaviour
{
    public Texture2D cursorTexture;
    
    void Start()
    {
        UnityEngine.Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseEnter() {
        UnityEngine.Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
