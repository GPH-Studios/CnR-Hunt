using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgent : Agent {
	private static readonly float SPEED = .1f;

	// a^2 + b^2 = c^2, and a = b, so 2(a^2) = c^2
	// so a = SQRT((c^2) / 2), where c = SPEED
	private static readonly float COMP_SPEED = Mathf.Sqrt(Mathf.Pow(SPEED, 2) / 2);

	private PlayerInput input;

	public PlayerAgent() : base() {
		;
	}

	public override void PerformUpdate(EntityIF entity) {
		if (!(entity is Player)) {
			return;
		}
		Player player = (Player) entity;

		Representation playerRep = player.GetRepresentation();
		if (playerRep == null) {
			return;
		}

		if (input == null) {
			input = playerRep.GetComponent<PlayerInput>();
			if (input == null) {
				return;
			}
			input.enabled = true;
		}

		int xDir = 0;
		int yDir = 0;
		if (input.moveLeft) {
			xDir--;
		}
		if (input.moveRight) {
			xDir++;
		}
		if (input.moveDown) {
			yDir--;
		}
		if (input.moveUp) {
			yDir++;
		}

		Vector2 velocity = new Vector2(xDir, yDir);
		float magnitude = xDir == 0 || yDir == 0 ? SPEED : COMP_SPEED;
		velocity *= magnitude;

		player.AdjustPosition(velocity);
		player.SetRotation(input.mouseDirection);
	}
}
