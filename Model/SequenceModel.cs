using EffingoFaciemTuam.UserDataHandling;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

		public SequenceModel()
		{
			Sequence.CollectionChanged += User_CollectionChanged;
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

		private void User_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
		{
			UserSequenceRepo.SaveSequenceToJson(this);
		}
	}
}
