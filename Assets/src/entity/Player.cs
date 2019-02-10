public class Player : Entity {
	public Player() : base("Player") {
		SetRepresentationSprite("Human");

		CreateRepresentation();
	}
}
