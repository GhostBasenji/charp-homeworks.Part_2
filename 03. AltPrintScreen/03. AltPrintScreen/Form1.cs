// Программная имитация нажатия клавиш <Alt>+<PrintScreen> методом Send класса SendKeys 

namespace _03._AltPrintScreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Имитируем нажатие <Alt>+<PrintScreen>";
            button1.Text = "методом Send класса SendKeys";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Метод SendKeys.Send посылает сообщение активному приложению о нажатии клавиш <Alt>+<PrintScreen>
            SendKeys.Send("%{PRTSC}");
            
            // Так можно получить символьное представление клавиши:
            // var S = Keys.PrintScreen.ToString();
        }
    }
}


// Для имитации нажатия сочетания клавиш <Alt>+<PrintScreen> современная система программирования Visual Studio в пространстве имен System.Windows.Forms имеет класс SendKeys,
// который предоставляет методы для отправки приложению сообщений о нажатиях клавиш, в том числе и нашей комбинации клавиш <Alt>+<PrintScreen>.

// Метод Send класса SendKeys посылает сообщение активному приложению о нажатии комбинации клавиш <Alt>+<PrintScreen>. На жатие клавиши <PrintScreen> генерирует код "{PRTSC}".
// Чтобы указать сочетание клавиш <Alt><PrintScreen>, следует в этот код добавить символ процента: "%{PRTSC}".
// Коды других клавиш можно посмотреть по адресу: http://msdn.microsoft.com/ru-ru/library/system.windows.forms.sendkeys.aspx