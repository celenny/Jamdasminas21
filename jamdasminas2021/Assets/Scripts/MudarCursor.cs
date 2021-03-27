using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudarCursor : MonoBehaviour
{
     public Vector2 hotSpot = Vector2.zero;
     private CursorMode cursorMode = CursorMode.Auto;    
     private Texture2D cursorTexture;
    // Start is called before the first frame update
    
    public void Start()
        {
        cursorTexture = (Texture2D)Resources.Load("Assets/Sprites/cursormao");
        }
    void OnMouseEnter()
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }

    void OnMouseExit()
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
