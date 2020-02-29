namespace RPGUtilities.Characters {
	public interface ICharacterClass {
		Stats CalculateStats(int level, Stats statsToUpdate);
	}
}