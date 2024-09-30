// Программа читает буфер обмена, и если данные в нем представлены в формате растровой графики, то записывает их в BMP-файл 

namespace _04._BufferObmenaSaveBMP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Сохраняю копию буфера обмена в BMP-файл";
            button1.Text = "Сохранить";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Объявляем объект-получатель из буфера обмена
            var Recipient = Clipboard.GetDataObject();
            Bitmap Rastr;

            // Если данные в буфере обмена представлены в формате Bitmap...
            if (Recipient.GetDataPresent(DataFormats.Bitmap) == true)
            {
                // то записать их из буфера обмена в переменную Rastr в формате Bitmap
                var Object = Recipient.GetData(DataFormats.Bitmap);
                Rastr = (Bitmap)Object;

                // Сохраняем изображение в файл Clip.bmp
                Rastr.Save(@"D:\Clip.BMP");

                // this.Text = "Сохранено в файле D:\Clip.BMP": 
                // button1.Text = "Еще записать?";

                MessageBox.Show(@"Ищображение из буфера обмена записано в файл D:\Clip.BMP", "Успешно");
            }
            else
                // В буфере обмена нет данных в формате изображений
                MessageBox.Show("В буфере обмена нет данных в формате Bitmap", 
                    "Запишите какое-либо изображение в буфер обмена");
        }
    }
}


// В коде при обработке события "щелчок на кнопке Сохранить" объявляем объектную переменную Recipient. Это объект-получатель из буфера обмена. Далее
// следует проверка — записаны ли данные, представленные в буфере обмена, в формате растровой графики Bitmap. Если да, то записать данные из буфера обмена
// в переменную Rastr в формате Bitmap с помощью объектной переменной Recipien, используя неявное преобразование в переменную типа Bitmap. Сохранить изображение
// Rastr на винчестер очень просто, воспользовавшись методом Save(). Чтобы не излишне запутать читателя и упростить программу, я не стал организовывать запись
// файла в диалоге. При необходимости читатель сделает это самостоятельно, воспользовавшись элементом управления SaveFileDialog.