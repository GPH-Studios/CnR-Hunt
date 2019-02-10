using System;

public class CollisionLogic2 {
	public static bool AreColliding(CollisionShape2 shape1, CollisionShape2 shape2) {
		if (shape2.shapeType < shape1.shapeType) {
			CollisionShape2 temp = shape1;
			shape2 = shape1;
			shape1 = temp;
		}

		if (shape1.shapeType == CollisionShape2.Shape.EMPTY) {
			return false;
		}

		throw new NotImplementedException("No implementation to compare " + shape1.shapeType + " and " + shape2.shapeType);
	}

    public static bool AreColliding(RectangleCollisionShape2 rect1, RectangleCollisionShape2 rect2) {
		return false;
	}
}
