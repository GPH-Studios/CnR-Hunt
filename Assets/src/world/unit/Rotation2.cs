using UnityEngine;

public class Rotation2 {
    private static readonly float DEFAULT_VALUE = 0f;

	private static readonly float RAD_TO_DEG = Mathf.Rad2Deg;
	private static readonly float DEG_TO_RAD = Mathf.Deg2Rad;

	private static readonly float PI = Mathf.PI;
	private static readonly float TWO_PI = Mathf.PI * 2;

    private float valueInRads;

    public Rotation2(Rotation2 rotation) {
		Set(rotation);
    }

	public Rotation2(Vector2 vector) {
		Set(vector);
	}

	public Rotation2(Vector3 vector) {
		Set(vector);
	}

	public Rotation2(float radians) {
		valueInRads = radians;
		Clamp();
	}

	public Rotation2() : this(DEFAULT_VALUE) {}

	public float inRadians {
		get {
			return valueInRads;
		}
	}

	public float inDegrees {
		get {
			return ToDegrees(valueInRads);
		}
	}

	public void Set(Rotation2 rotation) {
		valueInRads = rotation.valueInRads;
	}

	public void Set(Vector2 vector) {
		valueInRads = Mathf.Atan2(vector.y, vector.x);
	}

	public void Set(Vector3 vector) {
		valueInRads = Mathf.Atan2(vector.y, vector.x);
	}

	public void LeftBy(Rotation2 rotation) {
		valueInRads += rotation.valueInRads;
		Clamp();
	}

	public void RightBy(Rotation2 rotation) {
		valueInRads -= rotation.valueInRads;
		Clamp();
	}

	private void Clamp() {
		if (Mathf.Abs(valueInRads) >= TWO_PI) {
			valueInRads %= TWO_PI;
		}

		if (valueInRads <= -PI || PI < valueInRads) {
			valueInRads -= Mathf.Sign(valueInRads) * TWO_PI;
		}
	}

	public static float ToRadians(float degrees) {
		return degrees * DEG_TO_RAD;
	}

	public static float ToDegrees(float radians) {
		return radians * RAD_TO_DEG;
	}

	public static Rotation2 operator +(Rotation2 r1, Rotation2 r2) {
		Rotation2 result = new Rotation2(r1);
		result.LeftBy(r2);
		return result;
	}

	public static Rotation2 operator -(Rotation2 r1, Rotation2 r2) {
		Rotation2 result = new Rotation2(r1);
		result.RightBy(r2);
		return result;
	}
}
