using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EffingoFaciemTuam
{
    class DataHolder
    {
        static List<RowOfData> rowsOfData = new List<RowOfData>();


        struct RowOfData
        {
            public int rowId;
            public string mainName;
            public string suffixName;
        }

        public void LoadData(object sender, RoutedEventArgs e)
        {
            rowsOfData.Clear();

            RowOfData loadThis = new RowOfData();

            loadThis.rowId = 1;
            //loadThis.mainName = sender.Text

           // rowsOfData.Add();
        }

    }
}
