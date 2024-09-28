// Эта программа имеет возможность записи какого-либо текста в буфер обмена, а затем извлечения этого текста из буфера обмена

namespace _01._BuferObmenaTXT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Введите текст в верхнее поле";
            textBox1.Clear(); textBox2.Clear();
            textBox1.TabIndex = 0;
            button1.Text = "Записать в БО";
            button2.Text = "Ихвлечь из БО";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Записываем выделенный в верхнем поле текст в буфер обмена (БО)
            if (textBox1.SelectedText != String.Empty)
            {
                Clipboard.SetDataObject(textBox1.SelectedText);
                textBox2.Text = String.Empty;
            }
            else textBox2.Text = "В верхнем поле текст не выделен";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Объявляем объект-получатель из БО
            var Recipient = Clipboard.GetDataObject();

            // Если данные в БО представлены в текстовом формате...
            if (Recipient.GetDataPresent(DataFormats.Text) == true)
                // то записать их в Text тоже в текстовом формате,
                textBox2.Text = Recipient.GetData(DataFormats.Text).ToString();
            else // иначе
                textBox2.Text = "Запишите что-либо в буфер обмена";
        }
    }
}

// Как видно из кода, при обработке события "щелчок на верхней кнопке", если текст в верхнем поле выделен,
// то записываем его (SelectedText) в буфер обмена (Clipboard) командой (методом) SetDataObject, иначе (else)
// сообщаем в нижнем поле textBox2 о том, что в верхнем поле текст не выделен.
// Нажав кнопку Извлечь из БО, пользователь нашей программы в нижнем поле должен увидеть содержимое буфера обмена.
// Для этого объявляем объектную переменную Recipient. Это объект-получатель из буфера обмена. Далее следует проверка —
// в текстовом ли формате (DataFormat.Text) данные, представленные в буфере обмена. Если формат текстовый, то в текстовое
// поле TextBox2 записываем содержимое буфера обмена, используя функцию ToString. Эта функция конвертирует строковую часть  
// объекта в строковую переменную. 