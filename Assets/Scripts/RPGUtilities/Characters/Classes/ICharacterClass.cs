namespace RPGUtilities.Characters.Classes {
	public interface ICharacterClass {
		Stats CalculateStats(int level, Stats statsToUpdate);
	}
}