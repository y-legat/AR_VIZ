using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.WebCam;

public class PhotoController : MonoBehaviour {

    PhotoCapture photoCapture;

	// Use this for initialization
	void Start () {
        photoCapture = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PhotoModeActive()
    {
        PhotoCapture.CreateAsync(true, OnPhotoCaptureCreated);
    }

    public void OnPhotoCaptureCreated(PhotoCapture captureObject)
    {
        photoCapture = captureObject;
        Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();

        CameraParameters c = new CameraParameters();
        c.hologramOpacity = 1f;
        c.cameraResolutionWidth = cameraResolution.width;
        c.cameraResolutionHeight = cameraResolution.height;
        c.pixelFormat = CapturePixelFormat.BGRA32;

        captureObject.StartPhotoModeAsync(c, OnPhotoModeStarted);
    }

    private void OnPhotoModeStarted(PhotoCapture.PhotoCaptureResult result)
    {
        if (result.success)
        {
            string filename = string.Format(@"CapturedImage{0}_n.jpg", Time.time);
            string filePath = System.IO.Path.Combine(Application.persistentDataPath, filename);

            gameObject.GetComponent<AudioSource>().Play();
            photoCapture.TakePhotoAsync(filePath, PhotoCaptureFileOutputFormat.JPG, OnCapturedPhotoToDisk);
        }
        else
        {
            Debug.LogError("Unable to start photo mode!");
        }
    }

    void OnCapturedPhotoToDisk(PhotoCapture.PhotoCaptureResult result)
    {
        if (result.success)
        {
            Debug.Log("Saved Photo to disk!");
            photoCapture.StopPhotoModeAsync(OnStoppedPhotoMode);
        }
        else
        {
            Debug.Log("Failed to save Photo to disk");
        }
    }

    void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
    {
        photoCapture.Dispose();
        photoCapture = null;
    }
}
