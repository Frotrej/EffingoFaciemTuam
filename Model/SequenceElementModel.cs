using SharpHook.Data;
using System.Windows.Media;

namespace EffingoFaciemTuam.Model
{
	public class SequenceElement
	{
		public int StepNumber { get; set; }
		public int Delay { get; set; }
		public ElementType Type { get; set; }
		public HashSet<KeyCode>? KeyboardKeys { get; set; }
		public string KeyboardKeysString { get; set; }
		public int MouseX { get; set; }
		public int MouseY { get; set; }
		public enum ElementType
		{
			Klawiatura, //keyboard
			Mysz //mouse
		};

		//for UI dropdown
		public static Array StepTypes => Enum.GetValues(typeof(ElementType));

		public SequenceElement()
		{
			StepNumber = 1;
			Delay = 100;
			KeyboardKeys = new HashSet<KeyCode>();
			KeyboardKeysString = "-";
			MouseX = 0;
			MouseY = 0;
		}
		public SequenceElement(int X, int Y)
		{
			StepNumber = 1;
			Delay = 100;
			Type = ElementType.Mysz;
			KeyboardKeys = new HashSet<KeyCode>();
			KeyboardKeysString = "-";
			MouseX = X;
			MouseY = Y;
		}
		public SequenceElement(HashSet<KeyCode>? keyboardKeys)
		{
			StepNumber = 1;
			Delay = 100;
			Type = ElementType.Klawiatura;
			KeyboardKeys = new HashSet<KeyCode>();
			MouseX = 0;
			MouseY = 0;

			if (keyboardKeys != null && keyboardKeys.Count > 0)
				KeyboardKeysString = string.Join("+", keyboardKeys);
			else
				KeyboardKeysString = "-";
		}

		public void TranslateToString(HashSet<KeyCode>? keyboardKeys)
		{
			if (keyboardKeys != null && keyboardKeys.Count > 0)
				KeyboardKeysString = string.Join("+", keyboardKeys.Select(k => k.ToString().Replace("Vc", "")));
			else
				KeyboardKeysString = "-";
		}
	}
}
