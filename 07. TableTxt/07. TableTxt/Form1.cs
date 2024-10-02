// Программа формирует таблицу из двух строковых массивов в текстовом поле, используя функцию String.Format. Кроме того, в программе
// участвует элемент управления MenuStrip для организации раскрывающегося меню, с помощью которого пользователь выводит сформированную
// таблицу в Блокнот с целью последующего редактирования и вывода на печать

using System.Text;

namespace _07._TableTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Escape-последовательность для перехода на новую строку:
            const String HC = "\r\n"; // Новая строка
            this.textBox1.Multiline = true;
            this.ClientSize = new Size(438, 272);
            this.textBox1.Size = new Size(415, 229);
            this.Text = "Формирование таблицы";
            String[] Names = {
                "Андрей - раб", "Света-Х", "ЖЭК",
                "Справка по тел", "Александр Степанович",
                "Мама - дом", "Карапузова Таня",
                "Погода сегодня", "Театр Браво" };
            String[] Telephones = {
                "274-88-17", "+38(067)7030356",
                "22-345-72", "009", "223-67-67 доп 32-67",
                "570-38-76", "201-72-23-прямой моб",
                "001", "216-40-22"};
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Font = new Font("Courier New", 9.0F);
            textBox1.Text = "ТАБЛИЦА ТЕЛЕФОНОВ" + HC + HC;
            var i = 0;
            foreach (var Name in Names)
            {
                textBox1.Text += String.Format(
                    "{0, -21} {1, -21}" + HC, Name, Telephones[i]);
                i = i + 1;
            }
            // Или формирование таблицы с помощью обычного пошагового цикла: 
            // for (i = 0; i <= 8; i++) 
            //    textBox1.Text += String.Format( 
            //            "{0, -21} {1, -21}", Имена[i], Тлф[i]) + НС;
            textBox1.Text += HC + "ПРИМЕЧАНИЕ:" +
                HC + "для корректного отображения таблицы" +
                HC + "в Блокноте укажите шрифт Courier New";

            // Запись таблицы в текстовый файл D:\Table.txt. 
            // Создаем экземпляр StreamWriter для записи в файл
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var Writer = new System.IO.StreamWriter(@"D:\Table.txt", false,
               System.Text.Encoding.GetEncoding(1251));
            Writer.Write(textBox1.Text);
            Writer.Close();
        }

        private void показатьВТаблицеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Notepad", @"D:\Table.txt");
            }
            catch (Exception Situation)
            {
                // Отчет об ошибках
                MessageBox.Show(Situation.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

// Чтобы в текстовом поле TextBox таблица отображалась корректно, мы заказали шрифт Courier New. Особенность этого шрифта
// заключается в том, что каждый символ (буква, точка, запятая и др.) этого шрифта имеет одну и ту же ширину, как это было
// на пишущей машинке. Поэтому, пользуясь шрифтом Courier New, удобно строить таблицы. Таким же замечательным свойством
// обладает, например, шрифт Consolas.
// Далее в пошаговом цикле For мы использовали оператор +=, он означает сцепить текущее содержание текстовой переменной textBox1.Text
// с текстом, представленным справа. Функция String.Format возвращает строку, сформированную по формату. Формат заключен в кавычки.
// Ноль в первых фигурных скобках означает вставить вместо нуля переменную Names[i], а единица во вторых фигурных скобках — вставить вместо
// единицы строку Telephones[i]. Число 21 означает, что длина строки в любом случае будет состоять из 21 символа (недостающими символами
// будут пробелы), причем знак "минус" заставляет прижимать текст влево. Использование константы НС означает, что следует начать текст с новой строки.
// После формирования всех строк textBox1.Text записываем их в текстовый файл D:\Table.txt через StreamWriter с кодовой таблицей Windows 1251.
// При выборе пользователем пункта меню Показать таблицу в Блокноте система создает событие, которое обрабатывается в соответствующей процедуре.
// Здесь вызываем программу операционной системы Блокнот (notepad.exe) для открытия файла D:\Table.txt.