using UnityEngine;

namespace RPGUtilities.Characters {
	public abstract class Character : MonoBehaviour {

		protected Stats stats;

		private void Awake() {
			stats = new Stats(null);
		}

		public void TakeDamage(int damageAmount) {
			stats["currentHealt"] -= damageAmount;
		}
		public void GainXP(int XPAmount) {
			stats.GainXP(XPAmount);

		}

		public abstract void Attack();
		
	}
}