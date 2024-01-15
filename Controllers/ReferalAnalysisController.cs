using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferalAnalysisController : ControllerBase
    {
        private readonly HivContext _context;
        private readonly IWebHostEnvironment _appEnvironment;
        public ReferalAnalysisController(HivContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        //[Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            GenerateWordFile();
            return Ok();
        }

        private void GenerateWordFile()
        {

            string path_from = "D:\\work\\HIV\\HIVBackend\\HIVBackend\\ReportAnalyzes.docx";
            // Create a document by supplying the filepath. 
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(path_from, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                //// Добавляем стили
                //StylesPart stylesPart = mainPart.AddNewPart<StylesPart>();
                //stylesPart.Styles = new Styles();

                //// Добавляем стиль для заголовка
                //Style headingStyle = new Style()
                //{
                //    Type = StyleValues.Paragraph,
                //    StyleId = "Heading1",
                //    CustomStyle = true,
                //    StyleName = new StyleName() { Val = "Heading 1" },
                //    BasedOn = new BasedOn() { Val = "Normal" },
                //    NextParagraphStyle = new NextParagraphStyle() { Val = "Normal" }
                //};

                Paragraph para1 = body.AppendChild(new Paragraph(
                    new Run(new Text("Направление на анализы"))));

                Paragraph para2 = body.AppendChild(new Paragraph(
                    new Run(new Text($"Дата забора материала: {DateTime.Now.ToString("dd.MM.yyyy")}"))));

                Paragraph para3 = body.AppendChild(new Paragraph(
                    new Run(new Text("ФИО: Иванов Иван Иванович"))));

                Paragraph para4 = body.AppendChild(new Paragraph(
                    new Run(new Text("Пол: м"))));

                Paragraph para5 = body.AppendChild(new Paragraph(
                    new Run(new Text("Ид пациента: 1611"))));

                Paragraph para6 = body.AppendChild(new Paragraph(
                    new Run(new Text("Дата рождения: 11.01.2023"))));

                Paragraph para7 = body.AppendChild(new Paragraph(
                    new Run(new Text("ФИО лечешего врача: Иванов Иван Иванович"))));

                Paragraph para8 = body.AppendChild(new Paragraph(
                    new Run(new Text("Наименование тестов:"))));
            }
        }
    }
}
