using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	//Tween levels for zoom of camera
	public int[] tween = new int[4];
	public GameObject target;

	//settings
	public float hOffset; //horizontal offset += right -= left
	public float vOffset; //vertical offset += down -= up
	public float behind; //trailing distance of camera
	public float speed; //movement speed
	public float maxP; //max proportion of lerp used for slow stop
	public float minD; //min distance before stopping camera

	// Use this for initialization
	void Start () {
		transform.position = get_toLoc ();

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 toLoc = get_toLoc ();
		float distance = Vector3.Distance (transform.position, toLoc);


		if (speed / distance * Time.deltaTime > maxP) {
			Debug.Log((Time.deltaTime * speed) / distance);
			if (distance < minD) {
				transform.position = get_toLoc ();
			} else {
				Vector3.Lerp (
				transform.position,
				toLoc, 
				maxP * Time.deltaTime);
			}
		} else {
			transform.position = Vector3.Lerp (
			transform.position, 
			toLoc,
			speed / distance * Time.deltaTime);
			
		}
	}

	Vector3 get_toLoc() {
		Vector3 output = new Vector3 (
			target.transform.position.x + hOffset,
			target.transform.position.y + vOffset,
			target.transform.position.z - behind);

		return output;
	}

}
