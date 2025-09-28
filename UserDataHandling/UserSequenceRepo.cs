using EffingoFaciemTuam.Model;
using System.Text.Json;
using System.IO;

namespace EffingoFaciemTuam.UserDataHandling
{
	internal static class UserSequenceRepo
	{

		public static void SaveSequenceToJson(SequenceModel sequence)
		{
			string json = JsonSerializer.Serialize(sequence);
			File.WriteAllText("UserSequence.json", json);
		}

		public static SequenceModel LoadSequenceFromJson()
		{
			if (!File.Exists("UserSequence.json"))
			{
				return new SequenceModel();
			}
			string json = File.ReadAllText("UserSequence.json");
			SequenceModel? sequence = JsonSerializer.Deserialize<SequenceModel>(json);
			return sequence ?? new SequenceModel();
		}
	}
}