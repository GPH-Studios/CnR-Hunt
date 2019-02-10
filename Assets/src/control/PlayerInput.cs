using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	private static readonly string CAMERA_NAME = "Main Camera";

    private enum Inputs {
		UP = 0,
		DOWN = 1,
		LEFT = 2,
		RIGHT = 3
	}

	private static Dictionary<KeyCode, Inputs> INPUT_DICT = new Dictionary<KeyCode, Inputs> {
		{ KeyCode.W, Inputs.UP },
		{ KeyCode.S, Inputs.DOWN },
		{ KeyCode.A, Inputs.LEFT },
		{ KeyCode.D, Inputs.RIGHT }
	};

	private Camera mainCamera;

	private bool[] inputFlags;
	private Vector2 mousePosition;
	private Rotation2 mouseRotation;

	public bool moveUp {
		get {
			return GetInputFlagFor(Inputs.UP);
		}
	}

	public bool moveDown {
		get {
			return GetInputFlagFor(Inputs.DOWN);
		}
	}

	public bool moveLeft {
		get {
			return GetInputFlagFor(Inputs.LEFT);
		}
	}

	public bool moveRight {
		get {
			return GetInputFlagFor(Inputs.RIGHT);
		}
	}

	public Vector2 mousePoint {
		get {
			return mousePosition;
		}
	}

	public Rotation2 mouseDirection {
		get {
			return mouseRotation;
		}
	}

	void Start() {
		mainCamera = GameObject.Find(CAMERA_NAME).GetComponent<Camera>();

		inputFlags = new bool[INPUT_DICT.Count];
		mousePosition = new Vector2();
		mouseRotation = new Rotation2();
	}

	void Update() {
		foreach (KeyCode code in INPUT_DICT.Keys) {
			INPUT_DICT.TryGetValue(code, out Inputs input);
			inputFlags[(int)input] = Input.GetKey(code);
		}

		if (mainCamera != null) {
			Vector3 mousePositionOnScreen = Input.mousePosition;
			Vector3 pointLocation = mainCamera.ScreenToWorldPoint(mousePositionOnScreen);
			Vector3 pointDirection = pointLocation - transform.position;
			mousePosition.Set(pointLocation.x, pointLocation.y);
			mouseRotation.Set(pointDirection);
		}
	}

	private bool GetInputFlagFor(Inputs input) {
		if (inputFlags == null) {
			return false;
		}

		return inputFlags[(int) input];
	}

	private bool GetInputFlagFor(KeyCode code) {
		INPUT_DICT.TryGetValue(code, out Inputs input);
		return GetInputFlagFor(input);
	}
}
