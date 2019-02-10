using System.Numerics;

public class RectangleCollisionShape2 : CollisionShape2 {
	public RectangleCollisionShape2(Vector2 position, Rotation2 rotation) : base(Shape.RECT, position, rotation) {
		
	}
}
