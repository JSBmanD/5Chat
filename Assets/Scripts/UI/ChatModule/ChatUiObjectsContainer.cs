using UnityEngine;
using UnityEngine.UI;

namespace UI.ChatModule
{
    public class ChatUiObjectsContainer : MonoBehaviour
    {
        public static ChatUiObjectsContainer Instance;
    
        public ScrollRect chatScrollRect;
        public InputField inputField;
        public Transform bottomPanel;
        [HideInInspector]
        public Transform contentWithTextsObjects;
        public Text systemChatText;
    
        private void Start()
        {
            if (Instance == null)
                Instance = this;

            contentWithTextsObjects = chatScrollRect.content;
        }
    }
}
