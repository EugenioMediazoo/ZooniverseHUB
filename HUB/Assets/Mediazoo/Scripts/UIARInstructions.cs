using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIARInstructions : MonoBehaviour
{
    //debug
    public bool debug;

    //Gameobjects
    public GameObject Arrows;
    public GameObject Phone;
    public GameObject Finger;
    public GameObject Tap;

    //Variables
    [Range(0.1f,5)]
    public float AnimationSpeed;

    [Range(0, 2000)]
    public int distX;

    [Range(0, 2000)]
    public int distY;

    //Color;
    public Color FingerImg;

    private void Awake()
    {
        FingerImg = Finger.GetComponent<Image>().color;

        Tap.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(FingerImg.a);

        if (debug)
        {
            //ScanEnvironment();
            HideArrows();
            debug = !debug;
        }   
    }

    public void ScanEnvironment()
    {
        //Finger.GetComponent<Image>().color.a = FingerImg;
        DOTween.To(() => FingerImg.a, x => FingerImg.a = x, 0, AnimationSpeed).SetEase(Ease.InQuad);

        //Debug.Log(Finger.GetComponent<Image>().color.a);

        Sequence ScanSlowly = DOTween.Sequence();
        ScanSlowly.Append(Phone.transform.DOLocalMoveX(distX, AnimationSpeed).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo))
          .Append(Phone.transform.DOLocalMoveX(-distX, AnimationSpeed).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo))
          .Append(Phone.transform.DOLocalMoveY(distY, AnimationSpeed).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo))
          .Append(Phone.transform.DOLocalMoveY(-distY, AnimationSpeed).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo))
          .AppendInterval(1).OnComplete(HideArrows);
    }

    public void HideArrows()
    {
        Arrows.SetActive(false);

        Finger.transform.DOLocalMoveX(0, AnimationSpeed/2).SetEase(Ease.InOutQuad);
        Finger.transform.DOLocalMoveY(0, AnimationSpeed/2).SetEase(Ease.InOutQuad);

        TapFunction();
    }

    public void TapFunction()
    {
        StartCoroutine(TapOnOff());
    }

    IEnumerator TapOnOff()
    {
        yield return new WaitForSeconds(3);

        Tap.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        
        Tap.SetActive(false);
        yield return new WaitForSeconds(0.4f);

        Tap.SetActive(true);
        yield return new WaitForSeconds(0.3f);

        Tap.SetActive(false);
    }

}
