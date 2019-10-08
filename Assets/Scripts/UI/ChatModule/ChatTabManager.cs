#pragma warning disable 649
using UnityEngine;
using UnityEngine.UI;

namespace UI.ChatModule
{
    public class ChatTabManager : MonoBehaviour
    {
        public delegate void ChatChanged(int chatId);

        private Transform _bottomPanel;

        private Button[] _chatButtons;

        private GameObject[] _chatTexts;

        private int _childCount;

        private Transform _contentWithTexts;

        private ScrollRect _scrollRect;

        public event ChatChanged ChatTabSelected;


        private void Start()
        {
            Debug.LogWarning(ChatUiObjectsContainer.Instance);
            ChatUiObjectsContainer chatUiObjectsContainer = ChatUiObjectsContainer.Instance;
            _contentWithTexts = chatUiObjectsContainer.contentWithTextsObjects;
            _bottomPanel = chatUiObjectsContainer.bottomPanel;

            _childCount = _contentWithTexts.childCount;
            _chatButtons = new Button[_childCount];
            _chatTexts = new GameObject[_childCount];
            _chatButtons = _bottomPanel.GetComponentsInChildren<Button>();
            _scrollRect = GameObject.Find("Scroll View General").GetComponent<ScrollRect>();

            for (var i = 0; i < _childCount; i++)
            {
                _chatTexts[i] = _contentWithTexts.GetChild(i).gameObject;
            }
        }


        public void OnButtonChangeChat(int chatTabId)
        {
            for (var i = 0; i < _childCount; i++)
            {
                _chatButtons[i].interactable = true;
                _chatTexts[i].SetActive(false);

                if (i != chatTabId) continue;
                _chatButtons[i].interactable = false;
                _chatTexts[i].SetActive(true);
                _scrollRect.verticalNormalizedPosition = 1;
                ChatTabSelected?.Invoke(i);
            }
        }
    }
}