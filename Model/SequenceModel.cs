using System.Collections.ObjectModel;
using System.Windows;

namespace EffingoFaciemTuam.Model
{
	public class SequenceModel
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
		public void RemoveLastElementFromSequence()
		{
			if (Sequence.Count <= 0)
			{
				MessageBox.Show("Brak elementów do usunięcia.");
				return;
			}
			Sequence.RemoveAt(Sequence.Count - 1);
		}
	}
}
