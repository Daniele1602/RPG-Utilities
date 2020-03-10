using UnityEngine;

namespace Tools.Initialization {
	public class Initializer : MonoBehaviour {

		[SerializeField]
		private System.Collections.Generic.List<MonoBehaviour> scriptsToInitialize;

		void Awake() {
			scriptsToInitialize?.ForEach(script => {
				script.SendMessage("Awake");
			});
		}
	}
}