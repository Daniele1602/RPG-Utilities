using System.Collections.Generic;
namespace RPGUtilities.Characters {
	public class Stats {

		public static readonly int MAX_LEVLE = 99;

		private Dictionary<string, int> stats;

		private ICharacterClass clazz;

		public Stats(ICharacterClass clazz) {
			stats = new Dictionary<string, int> {
				{ "MaxHealth", 0 },
				{ "CurrentHealth", 0 },
				{ "MaxMagicPoints", 0 },
				{ "CurrentMagicPoints", 0 },

				{ "Attack", 0 },
				{ "Magic", 0 },
				{ "Defense", 0 },
				{ "Velocity", 0 },
				{ "XPToNextLevel", 5},
				{ "CurrentXP", 0},
				{ "Level", 0 }
			};

			this.clazz = clazz;
			
		}

		public int this[string key] {
			get {
				key = key.ToUpper();
				int value = 0, i = 0;
				List<string> keys = new List<string>(stats.Keys);
				while (i < stats.Count) {
					if (keys[i].ToUpper().Equals(key)) {
						value = stats[keys[i]];
						break;
					}
					i++;
				}
				return value;
			}

			set {
				key = key.ToUpper();
				int i = 0;
				List<string> keys = new List<string>(stats.Keys);
				while (i < stats.Count) {
					if (keys[i].ToUpper().Equals(key)) {
						stats[keys[i]] = value;
						break;
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
			foreach (string key in stats.Keys) {
				s += key + ":  " + stats[key]+System.Environment.NewLine;
			}
			return s;
		}

		public static Stats operator +(Stats s1, Stats s2) {

			List<string> keys = new List<string>(s1.stats.Keys);
			foreach (string key in keys) {
				s1[key] = s1[key] + s2[key];
			}

			return s1;
		}

		public static Stats operator -(Stats s1, Stats s2) {

			List<string> keys = new List<string>(s1.stats.Keys);
			foreach (string key in keys) {
				s1[key] = s1[key] - s2[key];
			}

			return s1;
		}
	}
}