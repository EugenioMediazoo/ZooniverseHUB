using UnityEngine;
using System.Collections;
using Vuforia;


public class touchInput : MonoBehaviour

{
    public GameObject islands;
    //public GameObject london;

    public GameObject lioness;
    public GameObject gorilla;

    private bool lioness_tapped;
    private bool gorilla_tapped;

    private void Start()
    {
        lioness.SetActive(true);
        lioness_tapped = false;
        gorilla_tapped = false;
        //london.SetActive(false);
    }

    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Debug.Log("running");


            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {

                if (raycastHit.collider.CompareTag("lioness"))
                {
                    Debug.Log("tapped");
                    lioness.SetActive(false);
                    lioness_tapped = true;
                }

                if (raycastHit.collider.CompareTag("gorilla"))
                {
                    Debug.Log("Gorilla tapped");
                    gorilla.SetActive(false);
                    gorilla_tapped = true;
                }
            }

            if (gorilla_tapped && lioness_tapped)
            {
                //london.SetActive(true);

            }
        }
    }
}