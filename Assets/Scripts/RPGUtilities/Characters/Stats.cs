using System.Collections.Generic;
using RPGUtilities.Characters.Classes;
namespace RPGUtilities.Characters {
	[System.Serializable]
	public class Stats {

		public static readonly int MAX_LEVLE = 99;

		private readonly ICharacterClass clazz;

		private readonly List<StatSet> stats;

		public Stats(ICharacterClass clazz) {
			stats = new List<StatSet> {
				new StatSet { Key = "MaxHealth", Value = 0 },
				new StatSet { Key = "CurrentHealth", Value = 0 },
				new StatSet { Key = "MaxMagicPoints", Value = 0 },
				new StatSet { Key = "CurrentMagicPoints", Value = 0 },

				new StatSet { Key = "Attack", Value = 0 },
				new StatSet { Key = "Magic", Value = 0 },
				new StatSet { Key = "Defense", Value = 0 },
				new StatSet { Key = "Velocity", Value = 0 },
				new StatSet { Key = "XPToNextLevel", Value = 0},
				new StatSet { Key = "CurrentXP", Value = 0},
				new StatSet { Key = "Level", Value = 0 }
			};

			this.clazz = clazz;

			UnityEngine.Debug.Log(clazz);
			this.clazz?.CalculateStats(1, this);
		}

		public int this[string key] {
			get {
				int i = 0;
				int length = stats.Count;
				while (i < length) {
					if (stats[i].Equals(key))
						return stats[i].Value;
					i++;
				}
				return -1;
			}

			set {
				int i = 0;
				int length = stats.Count;
				while (i < length) {
					if (stats[i].Equals(key)) {
						stats[i].Value = value;
						return;
					}
					i++;
				}
			}
		}

		public void GainXP(int XPAmount) {
			if (this["level"] < MAX_LEVLE) {
				this["currentXP"] = this["currentXP"] + XPAmount;
				if (this["currentXP"] >= this["XPToNextLevel"]) {
					LevelUp();
				}
			}
		}

		private void LevelUp() {
			this["level"]++;
			this["currentXP"] -= this["XPToNextLevel"];
			clazz?.CalculateStats(this["level"], this);
			if (this["level"] == MAX_LEVLE) {
				this["currentXP"] = 0;
				this["XPToNextLevel"] = 0;
			}
		}

		public override string ToString() {
			string s = "";
			foreach(StatSet st in stats) {
				s += st.ToString();
			}
			return s;
		}

		public static Stats operator +(Stats s1, Stats s2) {

			for(int i = 0; i < s1.stats.Count; i++) {
				s1.stats[i] += s2.stats[i];
			}

			return s1;
		}

		public static Stats operator -(Stats s1, Stats s2) {

			for(int i = 0; i < s1.stats.Count; i++) {
				s1.stats[i] -= s2.stats[i];
			}

			return s1;
		}

		private class StatSet {
			public string Key;
			public int Value;

			public StatSet() {

			}

			public override bool Equals(object obj) {
				if (obj is StatSet s) {
					return Key.Equals(s.Key) && Value == s.Value;
				}
				else if (obj is string str) {
					str = str.ToCharArray()[0].ToString().ToUpper() + str.Substring(1);
					return Key.Equals(str);
				}

				return false;
			}

			public override string ToString() {
				return Key + ":   " + Value;
			}

			public static StatSet operator +(StatSet s1, StatSet s2) {

				if (s1.Key.Equals(s2.Key))
					s1.Value += s2.Value;
				return s1;
			}

			public static StatSet operator -(StatSet s1, StatSet s2) {

				if (s1.Key.Equals(s2.Key))
					s1.Value -= s2.Value;
				return s1;
			}
		}
	}
}