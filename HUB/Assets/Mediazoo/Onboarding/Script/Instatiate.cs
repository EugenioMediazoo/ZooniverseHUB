﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;


public class Instatiate : MonoBehaviour
{
    public GameObject ChatContainer;

    public GameObject ChatLeft;
    public GameObject ChatRight;

    //public string blright;
    //private TextMeshProUGUI TM;
    [HideInInspector]
    public GameObject newChatBubble;

    //Variables
    [Range(0.1f, 5)]
    public float time;

    //ScriptableObjects
    public ChatBubble bltest;
    public ChatBubble brtest;
    public ChatBubble brtest2;


    private void Awake()
    {
        time = 0.5f;
        //blright = "test";
    }
    

    // Update is called once per frame
    void Update()
    {

        //var newChatBubble = Instantiate(ChatLeft);
        //newChatBubble.transform.parent = ChatContainer.transform;
        

        if (Input.GetKeyDown(KeyCode.L))
        {
            newChatBubble = Instantiate(ChatLeft, ChatContainer.transform);

            newChatBubble.GetComponent<ChatBubbleDisplay>().chatBubble = bltest;

            //newChatBubble.transform.localScale = new Vector3(1, 1, 1);
            //newChatBubble.transform.localScale = new Vector3(0, 1, 1);
          
            //newChatBubble.transform.DOScaleX(1, time).SetEase(Ease.InQuint)/*.OnComplete(Order)*/;

            //this.GetComponent<VerticalLayoutGroup>().spacing = 0.1f;
            //this.GetComponent<VerticalLayoutGroup>().spacing = 0.0f;




            //newChatBubble = Instantiate(ChatLeft, ChatContainer.transform);
            //newChatBubble.GetComponent<ChatBubbleDisplay>().chatBubble = bltest;

            //var BG = GameObject.Find("HorizontalChatL_SO(Clone)/Textbox Container/Textbox BG");
            //BG.transform.localScale = new Vector3(0, 0, 0);
            //BG.transform.DOScale(1, time).SetEase(Ease.InQuint);

            //ChatLeft.transform.SetParent(ChatContainer.transform);

            //    var newChatBubble = Instantiate(ChatLeft);
            //    newChatBubble.transform.parent = ChatContainer.transform;
            //ChatLeft.transform.SetParent(ChatContainer.transform);

            //    var newChatBubble = Instantiate(ChatLeft);
            //    newChatBubble.transform.parent = ChatContainer.transform;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            newChatBubble = Instantiate(ChatRight, ChatContainer.transform);
            newChatBubble.GetComponent<ChatBubbleDisplay>().chatBubble = brtest;

            newChatBubble = Instantiate(ChatRight, ChatContainer.transform);
            newChatBubble.GetComponent<ChatBubbleDisplay>().chatBubble = brtest2;
        }

            //if (Input.GetKeyDown(KeyCode.R))
            //{
            //    var newChatBubble = Instantiate(ChatRight, ChatContainer.transform);
            //    var newTextTMP = GameObject.Find("HorizontalChatR/Textbox Container/Textbox BG/Text (TMP)");
            //    newTextTMP.GetComponent<TextMeshProUGUI>().SetText(blright);
            //}
        }


    public void L()
    {
        newChatBubble = Instantiate(ChatLeft, ChatContainer.transform);
        newChatBubble.GetComponent<ChatBubbleDisplay>().chatBubble = bltest;
    }
    public void R()
    {
        newChatBubble = Instantiate(ChatRight, ChatContainer.transform);
        newChatBubble.GetComponent<ChatBubbleDisplay>().chatBubble = brtest;
    }

    //public void Order()
    //{
    //    this.GetComponent<VerticalLayoutGroup>().spacing = 0.1f;
    //    this.GetComponent<VerticalLayoutGroup>().spacing = 0.0f;
    //}
}