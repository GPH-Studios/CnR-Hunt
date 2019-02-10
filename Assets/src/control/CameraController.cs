using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private static readonly float MOVE_THRESHOLD = .95f;
	private static readonly float CAMERA_SPEED = .25f;

	private static readonly Vector3 DELTA_X = new Vector3(CAMERA_SPEED, 0, 0);
	private static readonly Vector3 DELTA_Y = new Vector3(0, CAMERA_SPEED, 0);

	private Camera c;

	void Start() {
		c = gameObject.GetComponent<Camera>();
	}

	void Update() {
		Vector3 mousePosOnScreen = Input.mousePosition;
		Vector3 screenPosDiff = c.ScreenToViewportPoint(mousePosOnScreen);

		if (screenPosDiff.x < 1 - MOVE_THRESHOLD) {
			transform.position -= DELTA_X;
		} else if (screenPosDiff.x > MOVE_THRESHOLD) {
			transform.position += DELTA_X;
		}

		if (screenPosDiff.y < 1 - MOVE_THRESHOLD) {
			transform.position -= DELTA_Y;
		} else if (screenPosDiff.y > MOVE_THRESHOLD) {
			transform.position += DELTA_Y;
		}
	}
}
