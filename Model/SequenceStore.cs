namespace EffingoFaciemTuam.Model
{
    public static class SequenceStore
    {
        public static SequenceModel ShareSequence { get; set; } = new SequenceModel();

        public static void LoadUserSequence()
        {
            ShareSequence = UserDataHandling.UserSequenceRepo.LoadSequenceFromJson();
		}
	}
}