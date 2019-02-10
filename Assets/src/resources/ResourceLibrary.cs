using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLibrary {
	private static readonly string PREFAB_DIR = "Prefabs/";
	private static readonly string SPRITE_DIR = "Sprites/";

	private static readonly string DEFAULT_ENTRY_KEY = "DEFAULT";

	private static readonly ResourceDictionary<GameObject> PREFAB_DICT = new ResourceDictionary<GameObject>(PREFAB_DIR);
	private static readonly ResourceDictionary<Sprite> SPRITE_DICT = new ResourceDictionary<Sprite>(SPRITE_DIR);

	static ResourceLibrary() {
		PREFAB_DICT.Add(DEFAULT_ENTRY_KEY, null);
		PREFAB_DICT.Add("Player", "Player");

		SPRITE_DICT.Add(DEFAULT_ENTRY_KEY, null);
		SPRITE_DICT.Add("Human", "Human");
		SPRITE_DICT.Add("Alien", "Alien");
	}

	public static GameObject GetPrefab(string name) {
		return PREFAB_DICT.Get(name);
	}

	public static Sprite GetSprite(string name) {
		return SPRITE_DICT.Get(name);
	}

	private class ResourceDictionary<ResourceType> where ResourceType : UnityEngine.Object {
		private readonly string dir;

		private readonly Dictionary<String, Func<ResourceType>> dict;

		public ResourceDictionary(string dir) {
			this.dir = dir;

			dict = new Dictionary<string, Func<ResourceType>>();
		}

		public void Add(string resourceKey, string resourceName) {
			if (resourceName == null) {
				return;
			}

			dict.Add(resourceKey, () => LoadResource(resourceName));
		}

		public ResourceType Get(string name) {
			dict.TryGetValue(name, out Func<ResourceType> func);
			if (func == null) {
				dict.TryGetValue(DEFAULT_ENTRY_KEY, out func);
			}

			ResourceType value = null;
			if (func != null) {
				value = func.Invoke();
			}

			if (value == null) {
				throw new NotImplementedException();
			}

			return value;
		}

		private string ConstructResourceName(string name) {
			return dir + name;
		}

		private ResourceType LoadResource(string name) {
			return Resources.Load<ResourceType>(ConstructResourceName(name));
		}
	}
}
