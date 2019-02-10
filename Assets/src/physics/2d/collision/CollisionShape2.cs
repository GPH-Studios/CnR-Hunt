using System;
using System.Numerics;

public abstract class CollisionShape2 {
	public static readonly float ALLOWABLE_ERROR = 0.0001f;

	public static readonly Vector2 DEFAULT_POS = new Vector2();
	public static readonly Rotation2 DEFAULT_ROT = new Rotation2();

	public enum Shape {
		EMPTY = 0,
		RECT = 3
	}

	private readonly Shape shape;

	private Vector2 pos;
	private Rotation2 rot;

	public CollisionShape2(Shape shape) : this(shape, DEFAULT_POS, DEFAULT_ROT) {}

	public CollisionShape2(Shape shape, Vector2 pos, Rotation2 rot) {
		this.shape = shape;
		this.pos = new Vector2(position.X, position.Y);
		this.rot = new Rotation2(rot);
	}

	public Shape shapeType {
		get {
			return shape;
		}
	}

	public Vector2 position {
		get {
			return pos;
		}
		set {
			pos = value;
		}
	}

	public Rotation2 rotation {
		get {
			return rot;
		}
		set {
			rot = value;
		}
	}

	public bool CollidesWith(CollisionShape2 other) {
		return AreColliding(this, other);
	}

	public static bool AreColliding(CollisionShape2 shape1, CollisionShape2 shape2) {
		return CollisionLogic2.AreColliding(shape1, shape2);
	}
}
