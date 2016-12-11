using UnityEngine;
using System.Collections;
using DG.Tweening;

public class LandscapeScrollScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (this.transform.position.x < -8) {
			//this.GetComponent<LandscapeScript> ().enabled = false;
			this.transform.position = new Vector3 (8, 0, 0);
			//this.name = "Landscape Right";
		} else if (this.transform.position.x < 0 && this.transform.position.x > -8){
			//this.name = "Landscape";
			//this.GetComponent<LandscapeScript> ().enabled = true;
			//this.transform.DOMove(new Vector3(-2,0,0), 2).SetRelative();
		}
		//else if (this.transform.position.x > 8) {
			//this.GetComponent<LandscapeScript> ().enabled = false;
			//this.transform.DOMove (new Vector3 (-8, 0, 0), 0.25f);
		//} //else if (this.transform.position.x > - 8 && this.transform.position.x < 8){
			//this.GetComponent<LandscapeScript> (). enabled = true;
		//}
	
	}
}
