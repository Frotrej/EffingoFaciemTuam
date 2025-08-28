using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffingoFaciemTuam.Model
{
	class SequenceModel
	{

		private ObservableCollection<SequenceElement> sequence = new ObservableCollection<SequenceElement>();

		public ObservableCollection<SequenceElement> Sequence
		{
			get { return sequence; }
			set { sequence = value; }
		}

		public void AddElementToSequence(SequenceElement element)
		{
			element.StepNumber = Sequence.Count + 1;

			Sequence.Add(element);
		}
		public void RemoveElementFromSequence(SequenceElement element) { Sequence.Remove(element); }
	}
}
