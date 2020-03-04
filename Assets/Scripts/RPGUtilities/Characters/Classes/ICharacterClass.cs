namespace RPGUtilities.Characters.Classes {
	public interface ICharacterClass {
		void CalculateStats(int level, Stats statsToUpdate);
	}
}