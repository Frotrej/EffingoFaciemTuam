using EffingoFaciemTuam.UserDataHandling;

namespace EffingoFaciemTuam.Model
{
    public static class SequenceStore
    {
        public static SequenceModel ShareSequence { get; set; } = new SequenceModel();

        public static void LoadUserSequence()
        {
            var loaded = UserSequenceRepo.LoadSequenceFromJson();

            ShareSequence.Sequence.Clear();

            foreach (var el in loaded.Sequence)
                ShareSequence.Sequence.Add(el);
        }
    }
}

