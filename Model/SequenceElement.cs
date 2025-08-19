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
		public string Type { get; set; }
		public char KeyboardKey { get; set; }
		public int MouseX { get; set; }
		public int MouseY { get; set; }

		public SequenceElement()
		{
			StepNumber = 1;
			Delay = 100;
			Type = "Typ";
			KeyboardKey = 'a';
			MouseX = 0;
			MouseY = 0;
		}

		enum ElementType
		{
			Keyboard,
			Mouse,
			Delay
		}
	}
}
