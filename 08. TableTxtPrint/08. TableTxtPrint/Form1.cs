// Программа формирует таблицу на основании двух массивов переменных с двойной точностью.
// Данную таблицу программа демонстрирует пользователю в текстовом поле TextBox.
// Есть возможность распечатать таблицу на принтере 

namespace _08._TableTxtPrint
{
    public partial class Form1 : Form
    {
        System.IO.StringReader Reader; // внешняя переменная

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Escape-последовательность для перехода на новую строку: 
            const String НС = "\r\n"; // Новая строка 
            this.Text = "Формирование таблицы";
            Double[] X = {
                   5342736.17653, 2345.3333, 234683.853749,
                   2438454.825368, 3425.72564, 5243.25,
                   537407.6236, 6354328.9876, 5342.243};
            Double[] Y = {
                   27488.17, 3806703.356, 22345.72,
                   54285.34, 2236767.3267, 57038.76,
                   201722.3, 26434.001, 2164.022};
            // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ 
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Font = new Font("Courier New", 9.0F);
            textBox1.Text = "КАТАЛОГ КООРДИНАТ" + НС;
            textBox1.Text += "---------------------------------" + НС;
            textBox1.Text += "|Пункт|      X     |     Y      |" + НС;
            textBox1.Text += "---------------------------------" + НС;
            // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ 
            for (int i = 0; i <= 8; i++)
                textBox1.Text +=
                   String.Format("| {0,3:D} | {1,10:F2} | {2,10:F2} |", i, X[i], Y[i]) + НС;
            textBox1.Text += "---------------------------------" + НС;
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Пункт меню "Печать" 
            try
            {
                // Создание потока Читатель для чтения из строки: 
                Reader = new System.IO.StringReader(textBox1.Text);
                try
                {
                    printDocument1.Print();
                }
                finally
                {
                    Reader.Close();
                }
            }
            catch (Exception Ситуация)
            {
                MessageBox.Show(Ситуация.Message);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
 
// Как видно из кода, формирование таблицы также происходит в цикле for с помощью функции String.Format.
// В фигурных скобках числа 0, 1 и 2 означают, что вместо фигурных скобок следует вставлять переменные i, X[i], Y[i].
// Выражение "3:D" означает, что переменную i следует размещать в трех символах по формату целых переменных "D".
// Выражение "10:F2" означает, что переменную X[i] следует размещать в десяти символах по фиксированному формату с двумя знаками после запятой. 
// При обработке события "щелчок на пункте меню Печать" в блоках try...finaly...catch создаем поток Reader, однако не для чтения из файла, а для
// чтения из текстовой переменной textBox1.Text. В этом случае мы обращаемся с потоком Reader так же, как при операциях с файлами, но совершенно
// не обращаясь к внешней памяти (диску).
// А также видно из кода, для того чтобы просмотреть, откорректировать и распечатать на принтере таблицу (инженерных или экономических вычислений),
// совершенно необязательно записывать эту таблицу в текстовый файл и читать его Блокнотом.