using UnityEngine;
using UnityEngine.UI;

namespace UI.ChatModule
{
    public class ChatButtonsScroll : MonoBehaviour
    {
        private ScrollRect _scrollRect;

        private void Start()
        {
            _scrollRect = ChatUiObjectsContainer.Instance.chatScrollRect;
        }

        public void OnClickTopButton()
        {
            if (_scrollRect.verticalNormalizedPosition > 0.9)
                _scrollRect.verticalNormalizedPosition = 1;
            else
                _scrollRect.verticalNormalizedPosition += 0.1f;
        }


        public void OnClickBotButton()
        {
            if (_scrollRect.verticalNormalizedPosition < 0.1)
                _scrollRect.verticalNormalizedPosition = 0;
            else
                _scrollRect.verticalNormalizedPosition -= 0.1f;
        }
    }
}