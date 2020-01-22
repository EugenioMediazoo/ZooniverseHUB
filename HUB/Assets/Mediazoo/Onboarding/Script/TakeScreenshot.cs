using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour {

	[SerializeField]
	GameObject blink;
	
	public GameObject backButton;
	public GameObject GalleryButton;
	public GameObject ScrenshotButton;

	private CanvasGroup CanvasG;
	private CanvasGroup GalleryButtonG;
	private CanvasGroup ScrenshotButtonG;

	private void Start()
	{
		CanvasG = backButton.GetComponent<CanvasGroup>();
		GalleryButtonG = GalleryButton.GetComponent<CanvasGroup>();
		ScrenshotButtonG = ScrenshotButton.GetComponent<CanvasGroup>();
	}

	public void TakeAShot()
	{
		StartCoroutine ("CaptureIt");
		CanvasG.alpha = 0;
		GalleryButtonG.alpha = 0;
		ScrenshotButtonG.alpha= 0;
	}

	IEnumerator CaptureIt()
	{
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		string pathToSave = fileName;
		ScreenCapture.CaptureScreenshot(pathToSave);
		yield return new WaitForEndOfFrame();
		//Instantiate (blink, new Vector2(0f, 0f), Quaternion.identity);
		blink.SetActive(true);
		Invoke("DeactivateBlink", 0.3f);
	}

	public void DeactivateBlink()
	{
		blink.SetActive(false);
		CanvasG.alpha = 1;
		GalleryButtonG.alpha = 1;
		ScrenshotButtonG.alpha = 1;
	}



}
