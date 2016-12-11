using UnityEngine;
using System.Collections;
using DG.Tweening;

public class LandscapeScript : MonoBehaviour
{
	public Transform target; // Target to follow
	Vector3 targetLastPos;
	Tweener tween;
	Vector3 mousePos;
	float targetX = 0;
	float Z = 1;
	float targetY = 0;
	float mousePosHighMaxX = -0.5f;
	float mousePosHighMinX = -2.0f;
	float mousePosLowMaxX = -2.8f;
	float mousePosLowMinX = -4.3f;
	float mousePosHighMaxY = 2.0f;
	float mousePosHighMinY = 0.5f;
	float mousePosLowMaxY = -0.5f;
	float mousePosLowMinY = -2.0f;
	void Start()
	{
		// First create the "move to target" tween and store it as a Tweener.
		// In this case I'm also setting autoKill to FALSE so the tween can go on forever
		// (otherwise it will stop executing if it reaches the target)
		tween = transform.DOMove(target.position, 0.02f).SetAutoKill(false);
		// Store the target's last position, so it can be used to know if it changes
		// (to prevent changing the tween if nothing actually changes)
		targetLastPos = target.position;
	}

	void Update()
	{
		//Debug.Log (this.transform.position);
		//Debug.Log(mousePos);
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (mousePos.y < 0.9f && mousePos.y > -0.9f) {
			if (mousePos.x > mousePosHighMinX && mousePos.x < mousePosHighMaxX) {
				targetX -= 0.1f;
				target.transform.position = new Vector3 (targetX, targetY, 0);

				if (target.transform.position.x < -8) {
					targetX = 8;
				}
				if (target.transform.position.x > 0 && target.transform.position.x < 8) {
					if (this.tag == "Right") {
						target.transform.position = new Vector3 (targetX - 8, targetY, 0);
					}
					if (this.tag == "Left") {
						target.transform.position = new Vector3 (targetX + 8, targetY, 0);
					}
				} else {
					if (this.tag == "Right") {
						target.transform.position = new Vector3 (targetX + 8, targetY, 0);
					}
					if (this.tag == "Left") {
						target.transform.position = new Vector3 (targetX - 8, targetY, 0);
					}
				} 
			} else if (mousePos.x > mousePosLowMinX && mousePos.x < mousePosLowMaxX) {
				targetX += 0.1f;
				target.transform.position = new Vector3 (targetX, targetY, 0);

				if (target.transform.position.x > 8) {
					targetX = -8;
				}
				
				if (target.transform.position.x > 0 && target.transform.position.x < 8) {
					if (this.tag == "Right") {
						target.transform.position = new Vector3 (targetX - 8, targetY, 0);
					}
					if (this.tag == "Left") {
						target.transform.position = new Vector3 (targetX + 8, targetY, 0);
					}
				} else {
					if (this.tag == "Right") {
						target.transform.position = new Vector3 (targetX + 8, targetY, 0);
						if (this.tag == "Left") {
							target.transform.position = new Vector3 (targetX - 8, targetY, 0);
						}
					}
				}
			} else if (mousePos.x < mousePosLowMaxX && mousePos.x > -mousePosHighMinX) {
				target.transform.position = new Vector3 (0, 0, 0);
				if (this.tag == "Right") {
					target.transform.position = new Vector3 (8, 0, 0);
				}
				if (this.tag == "Left") {
					target.transform.position = new Vector3 (-8, 0, 0);
				}
			}
		}else {
			if (this.tag == "Right") {
				this.transform.position = new Vector3 (target.transform.position.x + 8, targetY, 0);
			}			
			if (this.tag == "Left") {
				this.transform.position = new Vector3 (target.transform.position.x - 8, targetY, 0);
			}
		}
		//if (this.transform.position.y < 0.9f && this.transform.position.y > -0.9f) {
		if (mousePos.x > -4.3f && mousePos.x < -0.5f) {
			if (mousePos.y > mousePosHighMinY && mousePos.y < mousePosHighMaxY) {
				if (target.transform.position.y > -0.9f) {
					targetY -= 0.1f;
					target.transform.position = new Vector3 (targetX, targetY, 0);
					if (this.tag == "Right") {
						target.transform.position = new Vector3 (targetX + 8, targetY, 0);
					}
					if (this.tag == "Left") {
						target.transform.position = new Vector3 (targetX - 8, targetY, 0);
					}
				}
			} else if (mousePos.y > mousePosLowMinY && mousePos.y < mousePosLowMaxY) {
				//Debug.Log ("Why?!!");
				if (target.transform.position.y < 0.9f) {
					targetY += 0.1f;
					target.transform.position = new Vector3 (targetX, targetY, 0);
					if (this.tag == "Right") {
						target.transform.position = new Vector3 (targetX + 8, targetY, 0);
					}
					if (this.tag == "Left") {
						target.transform.position = new Vector3 (targetX - 8, targetY, 0);
					}
				} else if (mousePos.y < mousePosLowMaxY && mousePos.y > -mousePosHighMinY) {
					target.transform.position = new Vector3 (0, 0, 0);
					if (this.tag == "Right") {
						target.transform.position = new Vector3 (targetX + 8, targetY, 0);
					}
					if (this.tag == "Left") {
						target.transform.position = new Vector3 (targetX - 8, targetY, 0);
					}
				}
			}
		}
		else {
			if (this.tag == "Right") {
				this.transform.position = new Vector3 (target.transform.position.x + 8, targetY, 0);
			}			
			if (this.tag == "Left") {
				this.transform.position = new Vector3 (target.transform.position.x - 8, targetY, 0);
			}
		}
		//}
		// Use an Update routine to change the tween's endValue each frame
		// so that it updates to the target's position if that changed
		if (targetLastPos == target.position) return;
		// Add a Restart in the end, so that if the tween was completed it will play again
		tween.ChangeEndValue(target.position, true).Restart();
		targetLastPos = target.position;
	}
		
}