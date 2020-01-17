using System.Collections;
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
    public GameObject ChatF;

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

    private float SP;

    private void Awake()
    {
        time = 0.5f;
        //blright = "test";
        SP = ChatContainer.GetComponent<VerticalLayoutGroup>().spacing;

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            var newChatBubble = Instantiate(ChatRight, ChatContainer.transform);
            var newTextTMP = GameObject.Find("HorizontalChatR/Textbox Container/Textbox BG/Text (TMP)");
            //newTextTMP.GetComponent<TextMeshProUGUI>().SetText(blright2);
            newTextTMP.GetComponent<TextMeshProUGUI>().SetText("The first number is {0} and the 2nd is {1:2} and the 3rd is {3:0}.", 4, 6.345f, 3.5f);
        }
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

        newChatBubble = Instantiate(ChatRight, ChatContainer.transform);
        var newTextTMP = newChatBubble.GetComponent<ChatReference>().Text;
        newTextTMP.SetText("Hello World");
        //newTextTMP.GetComponent<TextMeshProUGUI>().SetText(blright);

        newChatBubble.GetComponent<ChatBubbleDisplay>().chatBubble = brtest2;
    }

    private string label02= "Hello World";

    public void F()
    {
        newChatBubble = Instantiate(ChatF, ChatContainer.transform);
        var newTextTMP = newChatBubble.GetComponent<ChatReference>().Text;
        newTextTMP.text = label02;

        var newTextCanvas = newChatBubble.GetComponent<CanvasGroup>();
        DOTween.To(() => newTextCanvas.alpha, x => newTextCanvas.alpha = x, 1, time).SetEase(Ease.InQuad);
    }

    private string label01 = "Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <font=\"Bangers SDF\" material=\"Bangers SDF - Drop Shadow\">TextMesh<#40a0ff>Pro</color></font><sprite=0> and Unity<sprite=1>";

    public void G()
    {
        newChatBubble = Instantiate(ChatF, ChatContainer.transform);
        var newTextTMP = newChatBubble.GetComponent<ChatReference>().Text;
        newTextTMP.text = label01;

        var newTextCanvas = newChatBubble.GetComponent<CanvasGroup>();
        Debug.Log(newTextCanvas.alpha);
        DOTween.To(() => newTextCanvas.alpha, x => newTextCanvas.alpha = x, 1, time).SetEase(Ease.InQuad);
        Debug.Log(newTextCanvas.alpha);
        //newTextTMP.SetText("Hi how are you doing, this is gonna be a really long message buahahahahah!!!");
        //SP = 0.01f;
        //SP = 0f;

        //var RT = newChatBubble.GetComponent<RectTransform>().sizeDelta;
        //Debug.Log(RT);
        //RT = RT + new Vector2(0,218);
    }

        //public void Order()
        //{
        //    this.GetComponent<VerticalLayoutGroup>().spacing = 0.1f;
        //    this.GetComponent<VerticalLayoutGroup>().spacing = 0.0f;
        //}
    }
