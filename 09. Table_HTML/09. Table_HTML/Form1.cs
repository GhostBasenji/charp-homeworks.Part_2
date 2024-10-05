// Вывод таблицы в интернет-браузер. Здесь реализован несколько необычный подход к выводу таблицы для ее просмотра и
// печати на принтере. Программа записывает таблицу в текстовый файл в формате HTML. 
// Теперь у пользователя появляется возможность прочитать эту таблицу с помощью интернет-браузера

using System.Text;

namespace _09._Table_HTML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Таблица в формате HTML";
            String[] Names = {
                 "Андрей — раб", "Света-X", "ЖЭК",
                 "Справка по тел", "Александр Степанович", "Мама — дом",
                 "Карапузова Таня", "Погода сегодня", "Театр Браво"};
            String[] Telephones = {
                 "274-88-17", "+38(067)7030356",
                 "22-345-72", "009", "223-67-67 доп 32-67", "570-38-76",
                 "201-72-23-прямой моб", "001", "216-40-22"};
            var text = "<title>Пример таблицы</title>" +
                       "<table border><caption>" +
                       "Таблица телефонов</caption>" + "\r\n";
            for (int i = 0; i <= 8; i++)
                text += String.Format("<tr><td>{0}<td>{1}", Names[i], Telephones[i]) + "\r\n";
            text = text + "</table/";

            // Записываем таблицу в текстовый файл D:\Tabl_tel.html
            // Создаем экземпляр StreamWriter для записи в файл
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var Writer = new
                System.IO.StreamWriter(@"D:/Tabl_tel.html", false,
                System.Text.Encoding.GetEncoding(1251));
            Writer.Write(text); Writer.Close();
            try
            {
                System.Diagnostics.Process.Start("Chrome", @"D:\Tabl_tel.html");
            }
            catch (Exception Ситуация)
            {
                MessageBox.Show(Ситуация.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
