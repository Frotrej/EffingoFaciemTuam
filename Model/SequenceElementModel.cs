using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffingoFaciemTuam.Model
{
	public class SequenceElement
	{
		public int StepNumber { get; set; }
		public int Delay { get; set; }
		public ElementType Type { get; set; }
		public char KeyboardKey { get; set; }
		public int MouseX { get; set; }
		public int MouseY { get; set; }
		public enum ElementType
		{
			Klawiatura, //keyboard
			Mysz //mouse
		};

		//for UI dropdown
		public static Array StepTypes => Enum.GetValues(typeof(ElementType));

		/*public SequenceElement()
		{
			StepNumber = 1;
			Delay = 100;
			Type = ElementType.Klawiatura;
			KeyboardKey = 'a';
			MouseX = 0;
			MouseY = 0;
		}*/
		public SequenceElement(ElementType type, int X, int Y)
		{
			StepNumber = 1;
			Delay = 100;
			Type = type;
			KeyboardKey = '-';
			MouseX = X;
			MouseY = Y;
		}
		public SequenceElement(ElementType type, char key)
		{
			StepNumber = 1;
			Delay = 100;
			Type = type;
			KeyboardKey = key;
			MouseX = 0;
			MouseY = 0;
		}

	}
}
