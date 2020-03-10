using UnityEngine;
using System.Collections.Generic;
namespace RPGUtilities.Characters.Classes {
	public sealed class Warrior : MonoBehaviour, ICharacterClass {

		private static readonly Dictionary<string, int> modificatori = new Dictionary<string, int> {
			{ "MaxHealth", 5 },
			{ "MaxMagicPoints", 1 },
			
			{ "Attack", 15 },
			{ "Magic", 3 },
			{ "Defense", 9 },
			{ "Velocity", 7 },
		};

		public static Warrior Instance { get; private set; }

		void Awake() {
			Instance = this;
		}

		private Warrior() {

		}

		public void CalculateStats(int level, Stats statsToUpdate) {
			int newMaxLife = Mathf.RoundToInt(modificatori["MaxHealth"] * Mathf.Pow(level, 2) / 20) + 10;
			statsToUpdate["CurrentHealth"] += newMaxLife - statsToUpdate["MaxHealth"];
			statsToUpdate["MaxHealth"] = newMaxLife;

			int newMaxMagic = Mathf.RoundToInt(modificatori["MaxMagicPoints"]* Mathf.Pow(level, 2) / 20) + 10;
			statsToUpdate["CurrentHealth"] += newMaxMagic - statsToUpdate["MaxMagicPoints"];
			statsToUpdate["MaxMagicPoints"] = newMaxMagic;
		}
	}
}