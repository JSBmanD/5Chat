using UnityEngine;
using UnityEngine.UI;

namespace UI.ChatModule
{
    public class ChatUiObjectsContainer : MonoBehaviour
    {
        public static ChatUiObjectsContainer Instance;
    
        public ScrollRect chatScrollRect;
        public ScrollRect systemChatScrollRect;
        
        public InputField inputField;
        
        [HideInInspector]
        public Transform contentWithTextsObjects;
        public Transform bottomPanel;
        
        public Text systemChatText;
    
        private void Start()
        {
            if (Instance == null)
                Instance = this;

            contentWithTextsObjects = chatScrollRect.content;
        }
    }
}
