using UnityEngine;
using System.Collections;
using DG.Tweening;



public class RaycastUIManager : MonoBehaviour

{
    public GameObject LionessUI;
    public GameObject GorillaUI;

    public ParticleSystem lioness_Particles;
    public ParticleSystem gorilla_Particles;

    [Range(0.01f, 3f)]
    public float time;

    private bool lioness_tapped;
    private bool gorilla_tapped;

    private bool lionessSwipeUp;
    private bool gorillaSwipeUp;

    public bool taPlioness;
    public bool taPgorilla;

    private void Awake()
    {
        lioness_tapped = false;
        gorilla_tapped = false;

        lionessSwipeUp = false;
        gorillaSwipeUp = false;
        
        //london.SetActive(false);

        //taPlioness = false;
        //taPgorilla = false;
    }

    void Update()
    {
        //if(taPlioness)
        //{
        //    Debug.Log("Lionesse tapped");
        //    lioness_Particles.Stop();
        //    LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
        //    lioness_tapped = true;
        //    taPlioness = false;
        //    lionessSwipeUp = true;
        //}

        //if(taPgorilla)
        //{
        //    Debug.Log("Gorilla tapped");
        //    gorilla_Particles.Stop();
        //    GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
        //    gorilla_tapped = true;
        //    taPgorilla = false;
        //    gorillaSwipeUp = true;
        //}


        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Debug.Log("running");

            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {

                if (raycastHit.collider.CompareTag("lioness"))
                {
                    Debug.Log("Lionesse tapped");
                    lioness_Particles.Stop();
                    LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
                    lioness_tapped = true;
                    lionessSwipeUp = true;
                }

                if (raycastHit.collider.CompareTag("gorilla"))
                {
                    Debug.Log("Gorilla tapped");
                    gorilla_Particles.Stop();
                    GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
                    gorilla_tapped = true;
                    gorillaSwipeUp = true;
                }
            }

            if (gorilla_tapped && lioness_tapped)
            {
                //london.SetActive(true);
                //londonUI.transform.DOMoveY(970, time).SetEase(Ease.OutBack);

            }
        }
    }

    public void UISlider()
    {
        if (lionessSwipeUp)
            LionessSlider();
        if (gorillaSwipeUp)
            GorillaSlider();
    }


    public void LionessSlider()
    {
        LionessUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack);
        lionessSwipeUp = false;
    }

    public void GorillaSlider()
    {
        GorillaUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack);
        gorillaSwipeUp = false;
    }
}