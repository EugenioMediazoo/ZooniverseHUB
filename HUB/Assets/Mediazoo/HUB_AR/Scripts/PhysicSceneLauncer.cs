using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicSceneLauncer: MonoBehaviour
{
    public string ZooniverseAR;
    public string Onboarding;
    public string Hub;
    public string AROnboarding;
    public string ARGallery;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zooniverse"))
        {
            SceneManager.LoadScene(ZooniverseAR, LoadSceneMode.Single);
            Debug.Log(other.tag);
        }
        else if (other.CompareTag("Hub"))
        {
            SceneManager.LoadScene(Hub, LoadSceneMode.Single);
            Debug.Log(other.tag);
        }
        else if (other.CompareTag("Onboarding"))
        {
            SceneManager.LoadScene(Onboarding, LoadSceneMode.Single);
            Debug.Log(other.tag);
        }
        else if (other.CompareTag("ARGallery"))
        {
            SceneManager.LoadScene(ARGallery, LoadSceneMode.Single);
            Debug.Log(other.tag);
        }
        else if (other.CompareTag("AROnboarding"))
        {
            SceneManager.LoadScene(AROnboarding, LoadSceneMode.Single);
            Debug.Log(other.tag);
        }
    }
}
