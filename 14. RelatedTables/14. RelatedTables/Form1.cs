using System.Data;
using System.Diagnostics.PerformanceData;
using System.Windows.Forms;

namespace _14._RelatedTables
{
    public partial class Form1 : Form
    {
        // Внешние переменные:
        Boolean ShowClients;
        DataSet DataSet;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Переключатель таблиц"; button1.TabIndex = 0;
            this.Text = "Связанные таблицы"; ShowClients = true;

            // Родительская таблица "Клиенты":
            var Table = new DataTable("Клиенты");
            // Создаем первый столбец в таблице:
            var Column = new DataColumn("Название организации");
            Column.ReadOnly = true; // Его нельзя модифицировать
            // Значения в каждой строке столбца должны быть уникальными:
            Column.Unique = true;
            // Добавляем этот столбец в таблицу:
            Table.Columns.Add(Column);
            // Добавляем второй и третий столбцы в таблицу:
            Table.Columns.Add("Контактное лицо");
            Table.Columns.Add("Телефон");
            // Создаем набор данных:
            DataSet = new DataSet();
            // Добавляем таблицу "Клиенты" в набор данных:
            DataSet.Tables.Add(Table);
            // Заполняем строки (ряды) в таблице:
            Table.Rows.Add("НИИАСС", "Погребицкий Олег", "095 345 22 37");
            Table.Rows.Add("КНУБА", "Юрий Александрович", "050 456 21 03");
            Table.Rows.Add("МИИГАИК", "Стороженко Светлана", "067 456 56 72");

            // Дочерняя таблица "Заказы":
            Table = new DataTable("Заказы");
            // Создаем первый столбец в таблице "Заказы":
            var Column1 = new DataColumn("Номер заказа");
            Column1.DataType = Type.GetType("System.Int32");
            Column1.ReadOnly = true; Column1.Unique = true;
            Table.Columns.Add(Column1);
            // Добавляем второй и третий столбцы в таблицу:
            Table.Columns.Add("Объем заказа");
            Table.Columns.Add("Организация-заказчик");
            DataSet.Tables.Add(Table);
            // Заполняем строки (ряды) в таблице: 
            Table.Rows.Add(1, "230000", "НИИАСС");
            Table.Rows.Add(2, "178900", "КНУБА");
            Table.Rows.Add(3, "300000", "НИИАСС");
            Table.Rows.Add(4, "345000", "МИИГАИК");
            Table.Rows.Add(5, "308000", "КНУБА");


            // Создаем связи между таблицами. Связываем одинаковые столбцы в двух таблицах:
            var Parent = DataSet.Tables["Клиенты"].Columns["Название организации"];
            var Child = DataSet.Tables["Заказы"].Columns["Организация-заказчик"];
            var Relateion1 = new DataRelation("Ссылка на заказы клиента", Parent, Child);

            // В родительской таблице значения в связываемом столбце должны быть уникальными, а в дочерней - нет.
            DataSet.Tables["Заказы"].ParentRelations.Add(Relateion1);

            // Источник данных для dataGridView:
            dataGridView1.DataSource = DataSet.Tables["Клиенты"];
            this.Text = dataGridView1.Columns[0].HeaderText = "Родительская таблица \"Клиенты\"";
            dataGridView1.Font = new Font("Consolas", 11);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Показываем либо "таблицу Клиенты", либо таблицу "Заказы":
            ShowClients = !ShowClients;
            if(ShowClients == true)
            {
                dataGridView1.DataSource = DataSet.Tables["Клиенты"];
                dataGridView1.Columns[0].HeaderText = "Родительская таблица \"Клиенты\"";
            }
            else
            {
                dataGridView1.DataSource = DataSet.Tables["Заказы"];
                dataGridView1.Columns[0].HeaderText = "Дочерняя таблица \"Заказы\"";
            }
        }
    }
}


// ПРИМЕЧАНИЕ: ЭЛЕМЕНТ DATAGRID 
// Обычно для отображения таблиц пользуются элементом управления DataGridView.
// DataGridView поддерживает ряд простых и сложных функций, отсутствующих в элементе управления DataGrid. Кроме того, архитектура элемента управления DataGridView
// упрощает его расширение и настройку по сравнению с DataGrid. Почти для всех целей следует использовать элемент управления DataGridView. Единственная функция, доступная
// в элементе управления DataGrid и недоступная в DataGridView, — иерархическое отображение данных из двух связанных таблиц в едином элементе управления. Для отображения
// данных из двух связанных таблиц требуется два элемента управления DataGridView. Поэтому для отображения двух связанных таблиц более технологичным вариантом будет использовать
// именно элемент DataGrid. 