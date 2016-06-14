using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class CursorChange : MonoBehaviour
{
    public Texture2D cursorTexture;
    private Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        print("My Cursor Has Changed.");
        //Sets the Cursor to the cursor texture that has been applied in the inspector. 
    }

}