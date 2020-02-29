using UnityEngine;

namespace RPGUtilities.Characters {
	public abstract class Character : MonoBehaviour {

		protected Stats stats;

		protected Effects.Status.IStatus status;

		private bool died;

		private void Awake() {
			stats = new Stats(null);
			status = null;
		}

		public void TakeDamage(int damageAmount) {
			stats["currentHealt"] -= damageAmount;
			if (stats["currentHealt"] <= 0) {
				stats["currentHealt"] = 0;
				died = true;
				status.Stop();
				// Die
			}
		}
		public void GainXP(int XPAmount) {
			if (!died) {
				stats.GainXP(XPAmount);
			}

		}

		public abstract void Attack();

	}
}