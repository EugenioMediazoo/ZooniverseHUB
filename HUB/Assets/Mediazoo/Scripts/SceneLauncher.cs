﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneLauncher : MonoBehaviour
{
    //public scenes
    public string ZooniverseAR;
    public string Hub;

    public void LaunchSceene()
    {
        GameObject _button = EventSystem.current.currentSelectedGameObject;
        if (_button != null)
        {
            if (_button.CompareTag("Zooniverse"))
            {
                SceneManager.LoadScene(ZooniverseAR, LoadSceneMode.Single);
                Debug.Log(_button.tag);
            }
            else if (_button.CompareTag("Hub"))
            {
                SceneManager.LoadScene(Hub, LoadSceneMode.Single);
                Debug.Log(_button.tag);
            }
            else
                Debug.Log("currentSelectedGameObject is untagged");
        }
    }
}
