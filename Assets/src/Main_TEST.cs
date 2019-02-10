using UnityEngine;

public class Main_TEST : MonoBehaviour {
	private static Player p1;
	private static Player p2;

    void Start() {
		p1 = new Player();
		p2 = new Player();

		p1.SetAgent(new PlayerAgent());
		p2.SetRepresentationSprite("Alien");
	}
	
    void Update() {
		if (p1 == null) {
			p1 = new Player();
		}
		if (p2 == null) {
			p2 = new Player();
		}

		//p1.SetAgent(new PlayerAgent());
		//p2.SetRepresentationSprite("Alien");

		p1.UpdateRepresentation();
		p2.UpdateRepresentation();
    }
}
