using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ChatBubbleDisplay : MonoBehaviour
{

    public ChatBubble chatBubble;

    //public TextMeshProUGUI nameText;
    public TextMeshProUGUI ChatText;

    public Image TextBoxBGImage;

    public GameObject TextboxContainerGO;
    public GameObject HorizontalContainerGO;

    // Start is called before the first frame update
    void Start()
    {
        ChatText.text = chatBubble.Text;

        TextBoxBGImage.sprite = chatBubble.TextBoxBG;
    }
}
