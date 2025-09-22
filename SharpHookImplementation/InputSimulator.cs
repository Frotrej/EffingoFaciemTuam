using EffingoFaciemTuam.Model;
using SharpHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffingoFaciemTuam.SharpHookImplementation
{
	internal static class InputSimulator
	{
		public static void SimulateSequence(SequenceModel sequence)
		{

			foreach (var element in sequence.Sequence)
			{
				if (element.Type == SequenceElement.ElementType.Klawiatura)
				{
					
					SimulateKeyboardInput_KbdShortcut(element);
				}
				if (element.Type == SequenceElement.ElementType.Mysz)
				{
					SimulateMouse_Click(element);
				}
			}
			
		}

		private static void SimulateMouse_Click(SequenceElement element)
		{
			var simulator = new EventSimulator();
			Thread.Sleep(element.Delay);
			//simulator.SimulateMouseMovement(element.MouseX, element.MouseY);		
			simulator.SimulateMousePress(element.MouseX, element.MouseY, SharpHook.Data.MouseButton.Button1);
			//Thread.Sleep(50);
			simulator.SimulateMouseRelease(SharpHook.Data.MouseButton.Button1);

		}

		private static void SimulateKeyboardInput_KbdShortcut(SequenceElement element)
		{
			var simulator = new EventSimulator();
			foreach (var item in element.KeyboardKeys)
			{
				Thread.Sleep(element.Delay);
				simulator.SimulateKeyPress(item);
			}

			foreach (var item in element.KeyboardKeys.Reverse())
			{
				Thread.Sleep(element.Delay);
				simulator.SimulateKeyRelease(item);
			}
		}
	}
}
