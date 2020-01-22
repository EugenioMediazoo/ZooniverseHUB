using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputEntered : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textBG;
    private LayoutGroup ContainerAlgn;

    public Sprite NewBG;
    private Image CurrentBG;

    public TextMeshProUGUI TextColor;

    private void Awake()
    {
        ContainerAlgn = textContainer.GetComponent<VerticalLayoutGroup>();
        CurrentBG = textBG.GetComponent<Image>();
        //Debug.Log(ContainerAlgn);
    }

    public void ShiftBubble()
    {
        ContainerAlgn.childAlignment = TextAnchor.MiddleRight;
        TextColor.color = Color.white;

        CurrentBG.sprite = NewBG;
        //ContainerAlgn = MiddleRight;
    }
}
