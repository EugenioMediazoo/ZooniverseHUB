using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Instatiate : MonoBehaviour
{
    public GameObject ChatContainer;

    public GameObject ChatLeft;
    public GameObject ChatRight;

    public ChatBubble bltest;

    private string blright;

    private void Start()
    {
        blright = "test";
    }
    

    // Update is called once per frame
    void Update()
    {

        //var newChatBubble = Instantiate(ChatLeft);
        //newChatBubble.transform.parent = ChatContainer.transform;

        if (Input.GetKeyDown(KeyCode.L))
        {
            var newChatBubble = Instantiate(ChatLeft, ChatContainer.transform);
            newChatBubble.GetComponent<ChatBubbleDisplay>().chatBubble = bltest;

            //ChatLeft.transform.SetParent(ChatContainer.transform);

            //    var newChatBubble = Instantiate(ChatLeft);
            //    newChatBubble.transform.parent = ChatContainer.transform;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            var newChatBubble = Instantiate(ChatRight, ChatContainer.transform);
            var newTextTMP = GameObject.Find("HorizontalChat_SO/Textbox Container/Textbox BG/Text (TMP)");
            Debug.Log(newTextTMP.name);
            newTextTMP.GetComponent<TextMeshProUGUI>();
            
           //textmeshproUGUI textmesh;


            
            //Instantiate(ChatRight);
        }
    }
}
