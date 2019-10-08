#pragma warning disable 649
using UnityEngine;

namespace UI.ChatModule
{
    public class ChatsResizer : MonoBehaviour
    {
        private float _position, _secondPosition;
        private bool _cursorPositionBlock;


        public void Update()
        {
            /*
        Debug.Log(GetComponent<RectTransform>().rect.height + "S");
        Debug.Log(chatSize.GetComponent<RectTransform>().rect.height + "C");
        if (cursorPositionBlock)
        {
            Debug.LogWarning(Input.mousePosition.y - position);
        }
        */
        }


        // Functions to track resizing of panel with chat
        public void OnCursorDown()
        {
            Debug.LogWarning("DOWN");
            _position = Input.mousePosition.y;
            _cursorPositionBlock = true;
        }


        public void OnCursorUp()
        {
            Debug.LogWarning(_position + " UP");
            _cursorPositionBlock = false;
            _secondPosition = Input.mousePosition.y;
            _position = _secondPosition - _position;
        }
    }
}