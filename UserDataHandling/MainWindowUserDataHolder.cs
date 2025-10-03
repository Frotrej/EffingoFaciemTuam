using System.Windows;

namespace EffingoFaciemTuam.UserDataHandling
{
	class MainWindowUserDataHolder
	{
		private static readonly MainWindowUserDataHolder _instance = new MainWindowUserDataHolder();

		static MainWindowUserDataHolder() { }
		private MainWindowUserDataHolder() { }
		public static MainWindowUserDataHolder Instance {  get { return _instance; } }

		private List<RowOfData> _rowsOfData = new List<RowOfData>();

		struct RowOfData
		{
			public int rowId;
			public string mainName;
			public string suffixName;
		}

		private void SaveDataToList(int id, string name, string suffix)
		{
			RowOfData rowToAdd = new RowOfData();

			rowToAdd.rowId = id;
			rowToAdd.mainName = name;
			rowToAdd.suffixName = suffix;

			_rowsOfData.Add(rowToAdd);
		}

		public void LoadDataFromView(MainWindow mainWindow)
		{
			_rowsOfData.Clear();

			SaveDataToList(1, mainWindow.TextBox1.Text, mainWindow.SuffixValue1.Text);
			SaveDataToList(2, mainWindow.TextBox2.Text, mainWindow.SuffixValue2.Text);
			SaveDataToList(3, mainWindow.TextBox3.Text, mainWindow.SuffixValue3.Text);
			SaveDataToList(4, mainWindow.TextBox4.Text, mainWindow.SuffixValue4.Text);
			SaveDataToList(5, mainWindow.TextBox5.Text, mainWindow.SuffixValue5.Text);
			SaveDataToList(6, mainWindow.TextBox6.Text, mainWindow.SuffixValue6.Text);
			SaveDataToList(7, mainWindow.TextBox7.Text, mainWindow.SuffixValue7.Text);
			SaveDataToList(8, mainWindow.TextBox8.Text, mainWindow.SuffixValue8.Text);
			SaveDataToList(9, mainWindow.TextBox9.Text, mainWindow.SuffixValue9.Text);
		}

		public string GetRowOfData(int id)
		{
			RowOfData row = new RowOfData();
			row = _rowsOfData[id];

			return $"{row.rowId}: {row.mainName}{row.suffixName}";
		}
	}
}
