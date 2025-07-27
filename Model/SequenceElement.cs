using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffingoFaciemTuam.Model
{
	class SequenceElement
	{
		string Typ { get; set; }
		char KeyboardKey { get; set; }
		int MouseX { get; set; }
		int MouseY { get; set; }

		public SequenceElement()
		{
			Typ = "Typ";
			KeyboardKey = 'a';
			MouseX = 0;
			MouseY = 0;
		}
	}
}
