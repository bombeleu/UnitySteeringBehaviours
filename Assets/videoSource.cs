using UnityEngine;
using System.Collections;
/// <summary>
/// Video source.
/// idea from http://answers.unity3d.com/questions/55607/any-possibility-to-play-a-video-in-unity-free.html
/// modified for use
/// </summary>
public class videoSource : MonoBehaviour {

	public string imageFolderName = "";
	public bool battleCommence = false, loop = false,Film = true;
	public ArrayList pictures;
	public float counter = 0;
	public float PictureRateInSeconds = 1;
	private float nextPic = 0;
	public Object[] img;
	public AudioClip clip;
	public Texture2D image;

	GameObject giggle;
	movement playMovie;
	AudioSource aud;
	// Use this for initialization
	void Start () {
		if(Film)
			PictureRateInSeconds =0.01f;

		img = Resources.LoadAll(imageFolderName);
		giggle = GameObject.FindGameObjectWithTag("MainCamera");
		playMovie = giggle.GetComponent<movement>(); 
	}
	
	// Update is called once per frame
	void Update () {
		if((playMovie.playVid1)&&(counter ==0)){
			audio.Play();
		}
	}

	void OnGUI(){
		if((counter <(img.Length)-23)&&(playMovie.playVid1)){
			counter += 0.55f;
			image = img[(int)counter] as Texture2D;
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),image);
		}

		if((counter >=(img.Length)-23)&&(!battleCommence)){
			battleCommence = true;
			playMovie.playVid1=false;
		}
	}
}