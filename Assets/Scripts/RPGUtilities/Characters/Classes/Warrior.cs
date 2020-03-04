using UnityEngine;

namespace RPGUtilities.Characters.Classes {
	public sealed class Warrior : MonoBehaviour, ICharacterClass {

		public static Warrior Instance { get; private set; }

		void Awake() {
			Instance = this;
		}

		private Warrior() {
			
		}

		public void CalculateStats(int level, Stats statsToUpdate) {

		}
	}
}