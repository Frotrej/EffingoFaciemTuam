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
        MainWindow _mainWindow;
        static List<RowOfData> _rowsOfData = new List<RowOfData>();

        public DataHolder(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        struct RowOfData
        {
            public int rowId;
            public string mainName;
            public string suffixName;
        }

        private void LoadData(int id, string name, string suffix)
        {
            

            RowOfData rowToAdd = new RowOfData();

            rowToAdd.rowId = id;
            rowToAdd.mainName = name; 
            rowToAdd.suffixName = suffix;

            _rowsOfData.Add(rowToAdd);
        }

        public void Get_LoadData()
        {
			_rowsOfData.Clear();

			LoadData(1, _mainWindow.TextBox1.Text, _mainWindow.TextBox1.Text);
			LoadData(2, _mainWindow.TextBox2.Text, _mainWindow.TextBox2.Text);
			LoadData(3, _mainWindow.TextBox3.Text, _mainWindow.TextBox3.Text);
			LoadData(4, _mainWindow.TextBox4.Text, _mainWindow.TextBox4.Text);
			LoadData(5, _mainWindow.TextBox5.Text, _mainWindow.TextBox5.Text);
			LoadData(6, _mainWindow.TextBox6.Text, _mainWindow.TextBox6.Text);
			LoadData(7, _mainWindow.TextBox7.Text, _mainWindow.TextBox7.Text);
		}

        public void CopyDataToClipboard()
        {
            string copy = "";
			
			foreach (var item in _rowsOfData)
			{
				copy += ($"Mlyn: {item.rowId} ({item.mainName}{item.suffixName})\n");
			}

			Clipboard.SetText(copy);
		}
    }
}
