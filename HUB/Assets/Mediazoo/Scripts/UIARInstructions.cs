using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIARInstructions : MonoBehaviour
{
    //debug
    public bool debug;

    //Gameobjects
    public GameObject Arrows;
    public GameObject Phone;
    public GameObject Finger;

    //Variables
    [Range(0.1f,5)]
    public float AnimationSpeed;

    [Range(-20, 20)]
    public int distX;

    [Range(-20, 20)]
    public int distY;

    private void Awake()
    {
        //AnimationSpeed = 1;
    }

    private void Update()
    {
        if (debug)
        {
            ScanEnvironment();
            debug = !debug;
        }
    }

    public void ScanEnvironment()
    {
        //Phone.transform.DOMoveX(-30, AnimationSpeed).SetEase(Ease.InOutQuad).SetLoops(2,LoopType.Yoyo);

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(Phone.transform.DOMoveX(-15, AnimationSpeed).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo))
          .Append(Phone.transform.DOMoveY(15, AnimationSpeed).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo));
          //.Append(Phone.transform.DOMoveY(-5, AnimationSpeed).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo))
          //.Append(Phone.transform.DOMoveY(5, AnimationSpeed).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo));
    }
}
