// Данная программа "на лету" генерирует PDF-документ.
// Добавляем файл itextsharp.dll (библиотека создания файлов формата PDF) через консольное приложение NuGet,
// выполнив следующую команду:
// NuGet\Install-Package itext -Version 8.0.5

using iText;
using iText.Kernel;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace _16._CreatePDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String dest = "D:/sample.pdf";
            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdf = new PdfDocument(writer);
            Document dokument = new Document(pdf, PageSize.A4);
            dokument.SetMargins(20, 20, 20, 20);
            var font = PdfFontFactory.CreateFont("C:\\Windows\\Fonts\\Arial.ttf", "Identity-H");

            dokument.Add(new Paragraph("Привет!" + "\n" + "Мне нравится Visual C#!")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20)
                .SetFont(font));
            dokument.Close();
        }
    }
}
