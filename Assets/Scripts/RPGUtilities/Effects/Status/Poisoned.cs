using System.Collections;
using UnityEngine;
using RPGUtilities.Characters;
namespace RPGUtilities.Effects.Status {
	public class Poisoned : MonoBehaviour, IStatus {

		private float time;
		private const float delay = 2.0f;

		Character target;

		public Poisoned(Character target) {
			this.target = target;
			time = Random.Range(1, 20);
		}

		public void PerformEffect() {
			StartCoroutine(DamageTarget());
		}

		private IEnumerator DamageTarget() {
			while (time > 0) {
				target.TakeDamage(20);
				yield return new WaitForSeconds(delay);
				time -= (int) delay;
			}
			StopCoroutine(DamageTarget());
		}

		public void Stop() {
			StopAllCoroutines();
		}
	}
}