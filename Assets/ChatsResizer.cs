using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class ChatsResizer : MonoBehaviour
{
    [SerializeField] private Transform chatSize;
    private Rect rected;
    private float position, secondPosition;
    private bool cursorPositionBlock;
    private float width;


    private void Start()
    {
        rected = GetComponent<RectTransform>().rect;
        width = rected.width;
    }

    public void Update()
    {
        Debug.Log(GetComponent<RectTransform>().rect.height + "S");
        Debug.Log(chatSize.GetComponent<RectTransform>().rect.height + "C");
        if (cursorPositionBlock)
        {
            rected.size= new Vector2(width, Input.mousePosition.y - position);
            rected.Set(rected.x, rected.y, width, Input.mousePosition.y - position);
            // rected.size = new Vector2(width, Input.mousePosition.y - position);
            //Debug.LogWarning(Input.mousePosition.y - position);
        }
    }


    public void OnCursorDown()
    {
        Debug.LogWarning("DOWN");
        position = Input.mousePosition.y;
        cursorPositionBlock = true;
    }


    public void OnCursorUp()
    {
        cursorPositionBlock = false;
        secondPosition = Input.mousePosition.y;
        position = secondPosition - position;
        Debug.LogWarning(position);
    }
}