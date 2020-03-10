using System.Collections;
using UnityEngine;
using RPGUtilities.Characters;
namespace RPGUtilities.Effects.Status {
	public class Poisoned : MonoBehaviour, IStatus {

		private float time;
		private readonly float delay;

		readonly Character target;

		public Poisoned(Character target, float delay) {
			this.target = target;
			time = Random.Range(1, 20);
			this.delay = delay;
		}

		public void PerformEffect() {
			StartCoroutine(DamageTarget());
		}

		private IEnumerator DamageTarget() {
			while (time > 0) {
				target.TakeDamage(20);
				yield return new WaitForSeconds(delay);
				time -= delay;
			}
			StopCoroutine(DamageTarget());
		}

		public void Stop() {
			StopAllCoroutines();
		}
	}
}