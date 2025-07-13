using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EffingoFaciemTuam
{
	class DataHolder
	{
		private static readonly DataHolder _instance = new DataHolder();

		static DataHolder() { }
		private DataHolder() { }
		public static DataHolder Instance {  get { return _instance; } }

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

		public void GetDataAndPassToSaveIt(MainWindow mainWindow)
		{
			_rowsOfData.Clear();

			SaveDataToList(1, mainWindow.TextBox1.Text, mainWindow.SuffixValue1.Text);
			SaveDataToList(2, mainWindow.TextBox2.Text, mainWindow.SuffixValue2.Text);
			SaveDataToList(3, mainWindow.TextBox3.Text, mainWindow.SuffixValue3.Text);
			SaveDataToList(4, mainWindow.TextBox4.Text, mainWindow.SuffixValue4.Text);
			SaveDataToList(5, mainWindow.TextBox5.Text, mainWindow.SuffixValue5.Text);
			SaveDataToList(6, mainWindow.TextBox6.Text, mainWindow.SuffixValue6.Text);
			SaveDataToList(7, mainWindow.TextBox7.Text, mainWindow.SuffixValue7.Text);
		}

		public string GetRowOfData(int id)
		{
			RowOfData row = new RowOfData();
			row = _rowsOfData[id];

			return ($"{row.rowId}: {row.mainName}{row.suffixName}");
		}

		public void CopyDataToClipboard()
		{
			string copy = "";

			foreach (var item in _rowsOfData)
			{
				copy += ($"Mlyn: {item.rowId}: {item.mainName}{item.suffixName}\n");
			}

			Clipboard.SetText(copy);
		}
	}
}
