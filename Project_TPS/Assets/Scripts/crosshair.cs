using UnityEngine;
using System.Collections;

public class crosshair : MonoBehaviour {
	public static float size = 0.1f;
	public static float bloom = 0f;
	public float sizeMin = 0.5f;
	public float sizeMax = 1f;
	public Texture2D crossTexture;
	//public GameObject emitter = Camera.main;
	public GameObject prefab;



	// Use this for initialization
	void OnGUI () {
		Vector3 center = Camera.main.ViewportToScreenPoint (new Vector3 (0.5f, 0.5f, 0f));
		float drawSize = sizeMax * size;

		GUI.DrawTexture (new Rect (center.x - drawSize /2, center.y - drawSize /2, drawSize, drawSize), crossTexture);


	}
	

}
