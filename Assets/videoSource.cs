using UnityEngine;
using System.Collections;
/// <summary>
/// Video source.
/// idea from http://answers.unity3d.com/questions/55607/any-possibility-to-play-a-video-in-unity-free.html
/// modified for use
/// </summary>
public class videoSource : MonoBehaviour {

	public string imageFolderName = "";
	public bool battleCommence = false,Film = true;
	public ArrayList pictures;
	public float counter = 0;
	public float PictureRateInSeconds = 1;
	private float nextPic = 0;
	public Object[] img;
	public AudioClip clip;
	public Texture2D image;

	GameObject mainCamera;
	movement playMovie;
	AudioSource aud;
	// Use this for initialization
	void Start () {
		if(Film)
			PictureRateInSeconds =0.01f;

		img = Resources.LoadAll(imageFolderName);
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		playMovie = mainCamera.GetComponent<movement>(); 
	}
	
	// Update is called once per frame
	void Update () {
		if((playMovie.playVid1)&&(counter ==0)){
			audio.Play();
		}
	}

	void OnGUI(){
		if((counter>=0)&&(counter <(img.Length)-23)&&(playMovie.playVid1)){
			counter += 0.55f;
			image = img[(int)counter] as Texture2D;
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),image);
		}

		if((counter >=(img.Length)-23)&&(playMovie.playVid1)){
			if(playMovie.playVid1)
				battleCommence = true;
			counter = -1;
			playMovie.playVid1=false;
		}
	}
}