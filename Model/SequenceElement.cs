using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffingoFaciemTuam.Model
{
	public class SequenceElement
	{
		public string Typ { get; set; }
		public char KeyboardKey { get; set; }
		public int MouseX { get; set; }
		public int MouseY { get; set; }

		public SequenceElement()
		{
			Typ = "Typ";
			KeyboardKey = 'a';
			MouseX = 0;
			MouseY = 0;
		}
	}
}
