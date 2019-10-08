#pragma warning disable 649
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ChatModule
{
    public class ChatMessagesHandler : MonoBehaviour
    {
        private List<string> _linesInText;
        private List<string> _linesInSystemText;
        
        private Text[] _chatTexts;

        private Transform _contentWithTexts;
        
        private InputField _inputField;
        
        private Text _systemChatText;
        
        private ScrollRect _scrollRectGeneral;
        private ScrollRect _scrollRectSystem;

        private int _linesCount;
        
        private bool _allowEnter;
        
        public delegate void MessageSent(string msgText);

        public event MessageSent SendMessageToChat;


        private void Start()
        {
            var chatUiObjectsContainer = ChatUiObjectsContainer.Instance;
            _inputField = chatUiObjectsContainer.inputField;
            _contentWithTexts = chatUiObjectsContainer.contentWithTextsObjects;
            _systemChatText = chatUiObjectsContainer.systemChatText;
            _scrollRectSystem = chatUiObjectsContainer.systemChatScrollRect;
            _scrollRectGeneral = chatUiObjectsContainer.chatScrollRect;

            _chatTexts = _contentWithTexts.gameObject.GetComponentsInChildren<Text>(true);
            _linesInText = new List<string>();
        }


        /// <summary>
        /// Убрать этот метод и кнопку на сцене после тестов
        /// </summary>
        public void AddStr()
        {
            AddStringToChat(Random.Range(0, 0.9f) < 0.4f ? "One" : "Two", "blue", 2);
        }


        public void AddStringToChat(string textToAdd, string colorOfText = "white", int chatId = 0)
        {
            var textInContainer = _chatTexts[chatId].text;
            var finalText = "\n" + "<color=" + colorOfText + ">" + textToAdd + "</color>";
            _linesInText.Add(finalText);

            if (_linesInText.Count > 100)
            {
                _linesInText.RemoveAt(0);
                textInContainer = string.Empty;
                foreach (var line in _linesInText)
                {
                    textInContainer += line;
                }
            }
            else
            {
                textInContainer += finalText;
            }

            _scrollRectGeneral.verticalNormalizedPosition = -0.015f;

            _chatTexts[chatId].text = textInContainer;
        }


        public void AddStringToSystemChat(string textToAdd, string colorOfText = "white", int chatId = 0)
        {
            var textInContainer = _systemChatText.text;
            var finalText = "\n" + "<color=" + colorOfText + ">" + textToAdd + "</color>";
            _linesInSystemText.Add(finalText);

            if (_linesInSystemText.Count > 100)
            {
                _linesInSystemText.RemoveAt(0);
                textInContainer = string.Empty;
                foreach (var line in _linesInSystemText)
                {
                    textInContainer += line;
                }
            }
            else
            {
                textInContainer += finalText;
            }

            _scrollRectSystem.verticalNormalizedPosition = -0.015f;

            _systemChatText.text = textInContainer;
        }


        private void Update()
        {
            if (_allowEnter && _inputField.text.Length > 0 &&
                Input.GetKey(KeyCode.Return))
            {
                SendMessageToChat?.Invoke(_inputField.text);
                _allowEnter = false;
                _inputField.text = "";
            }
            else
            {
                _allowEnter = _inputField.isFocused;
            }
        }
    }
}