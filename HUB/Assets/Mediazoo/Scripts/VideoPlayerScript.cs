using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class VideoPlayerScript : MonoBehaviour
{
    //public string moviePath = "Mediazoo/10Sec.mp4";
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public RawImage rawImage;
    

    // Use this for initialization
    void Start()
    {
        //if (moviePath != null)
        //{
        //    Debug.Log("found");
        //    Invoke("doPlay", 1.0f);
        //}

        StartCoroutine(PlayVideo());
    }

    //void doPlay()
    //{
    //    Debug.Log("Starting Movie: " + moviePath);
    //    Handheld.PlayFullScreenMovie(moviePath, Color.black, FullScreenMovieControlMode.Full);
    //    Debug.Log("All Done!");
    //}

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();

        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }

    
}
