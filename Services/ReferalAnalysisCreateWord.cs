    using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using HIVBackend.Data;

namespace HIVBackend.Services
{
    public class ReferalAnalysisCreateWord
    {
        public void GenerateWordFile(int patientId, string docName, List<string> research, HivContext _context, string path)
        {
            var patient = _context.TblPatientCards.Where(e => e.PatientId == patientId).First();

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document))
            {
                var referralExamination = new Dictionary<string, string>()
                {
                    { "210", "Психиатр"},
                    { "231", "ЛОР"},
                    { "228", "Невролог"},
                    { "207", "Офтальмолог"},
                    { "223", "Стоматолог"},
                    { "271", "Дерматолог"},
                    { "270", "Терапевт"}
                };


                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                StyleDefinitionsPart part = wordDocument.MainDocumentPart.AddNewPart<StyleDefinitionsPart>();
                Styles styles = new();
                var paragProp = new ParagraphProperties(
                    new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Exact });

                Style style = new(paragProp)
                {
                    Type = StyleValues.Paragraph,
                    StyleId = "minSpacing",
                    CustomStyle = true,
                    Default = true,
                    StyleRunProperties = new StyleRunProperties(new FontSize() { Val = "28" })
                };
                styles.AddChild(style);
                styles.Save(part);


                Paragraph para1 = body.AppendChild(new Paragraph(
                    new Run(new RunProperties(new Bold()), new Text("Направление на анализы"))));

                Paragraph para2 = body.AppendChild(new Paragraph());
                para2.AddChild(new Run(new Text("Дата забора материала: ")));
                para2.Append(new Run(new RunProperties(new Bold()), new Text(DateTime.Now.ToString("dd.MM.yyyy"))));

                Paragraph para3 = body.AppendChild(new Paragraph());
                para3.AddChild(new Run(new Text($"ФИО: ")));
                para3.Append(new Run(new RunProperties(new Bold()), new Text(patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName)));

                Paragraph para4 = body.AppendChild(new Paragraph());
                para4.AddChild(new Run(new Text("Код контингента: ")));
                para4.Append(new Run(new RunProperties(new Bold()), new Text(_context.TblCheckCourses.FirstOrDefault(e => e.CheckCourseId == patient.CheckCourseId)?.CheckCourseShort
                    )));

                Paragraph para5 = body.AppendChild(new Paragraph());
                para5.AddChild(new Run(new Text("Пол: ")));
                para5.Append(new Run(new RunProperties(new Bold()), new Text(_context.TblSexes.Where(e => e.SexId == patient.SexId).FirstOrDefault()?.SexShort)));

                Paragraph para6 = body.AppendChild(new Paragraph());
                para6.AddChild(new Run(new Text("Ид пациента: ")));
                para6.Append(new Run(new RunProperties(new Bold()), new Text(patient.PatientId.ToString())));

                Paragraph para7 = body.AppendChild(new Paragraph());
                para7.AddChild(new Run(new Text("Дата рождения: ")));
                para7.Append(new Run(new RunProperties(new Bold()), new Text(patient.BirthDate.ToString())));

                Paragraph para8 = body.AppendChild(new Paragraph());
                para8.AddChild(new Run(new Text("ФИО лечащего врача: ")));
                para8.Append(new Run(new RunProperties(new Bold()), new Text(docName)));

                Paragraph para9 = body.AppendChild(new Paragraph(
                    new Run(new RunProperties(new Bold()), new Text("Наименование тестов:"))));

                Table table = new();
                Table table1 = new();
                TableProperties props = new(
                    new TableWidth() { Width = "100%" },
                    new TableRowHeight() { Val = 5, HeightType = HeightRuleValues.Exact },
                    new TableBorders(
                    new TopBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 1
                    },
                    new BottomBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 1
                    },
                    new LeftBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 1
                    },
                    new RightBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 1
                    },
                    new InsideHorizontalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 1
                    },
                    new InsideVerticalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 1
                    }));
                TableProperties props1 = new(
                    new TableWidth() { Width = "100%" },
                    new TableRowHeight() { Val = 5, HeightType = HeightRuleValues.Exact },
                    new TableBorders(
                    new TopBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 1
                    },
                    new BottomBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 1
                    },
                    new LeftBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 1
                    },
                    new RightBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 1
                    },
                    new InsideHorizontalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 1
                    },
                    new InsideVerticalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 1
                    }));

                table.AppendChild<TableProperties>(props);

                foreach (var item in research)
                {
                    var tr = new TableRow();
                    var tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new RunProperties(new Bold()), new Text(item))));
                    tr.Append(tc);
                    table.Append(tr);
                }

                body.AppendChild(table);

                Paragraph para10 = body.AppendChild(new Paragraph(
                   new Run(new RunProperties(new Bold()), new Text())));

                Paragraph para11 = body.AppendChild(new Paragraph(
                   new Run(new RunProperties(new Bold()), new Text("Направление на диспансеризацию"))));

                Paragraph para12 = body.AppendChild(new Paragraph());
                para12.AddChild(new Run(new Text($"ФИО: ")));
                para12.Append(new Run(new RunProperties(new Bold()), new Text(patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName)));

                Paragraph para13 = body.AppendChild(new Paragraph());
                para13.AddChild(new Run(new Text("Пол: ")));
                para13.Append(new Run(new RunProperties(new Bold()), new Text(_context.TblSexes.Where(e => e.SexId == patient.SexId).FirstOrDefault()?.SexShort)));

                Paragraph para14 = body.AppendChild(new Paragraph());
                para14.AddChild(new Run(new Text("Ид пациента: ")));
                para14.Append(new Run(new RunProperties(new Bold()), new Text(patient.PatientId.ToString())));

                Paragraph para15 = body.AppendChild(new Paragraph());
                para15.AddChild(new Run(new Text("Дата рождения: ")));
                para15.Append(new Run(new RunProperties(new Bold()), new Text(patient.BirthDate.ToString())));

                Paragraph para16 = body.AppendChild(new Paragraph());
                para16.AddChild(new Run(new Text("ФИО лечащего врача: ")));
                para16.Append(new Run(new RunProperties(new Bold()), new Text(docName)));


                table1.AppendChild<TableProperties>(props1);
                TableRow tr0 = new();
                TableCell tc01 = new(new Paragraph(new Run(new RunProperties(new Bold()), new Text("Каб№"))));
                TableCell tc02 = new(new Paragraph(new Run(new RunProperties(new Bold()), new Text("Специалист"))));
                TableCell tc03 = new(new Paragraph(new Run(new RunProperties(new Bold()), new Text("Выполнить"))));
                TableCell tc04 = new(new Paragraph(new Run(new RunProperties(new Bold()), new Text("Выполнено"))));
                tr0.Append(tc01, tc02, tc03, tc04);
                table1.Append(tr0);

                foreach (var item in referralExamination)
                {
                    TableRow tr = new();
                    TableCell tc1 = new(new Paragraph(new Run(new Text(item.Key))));
                    TableCell tc2 = new(new Paragraph(new Run(new Text(item.Value))));
                    TableCell tc3 = new(new Paragraph(new Run(new Text())));
                    TableCell tc4 = new(new Paragraph(new Run(new Text())));
                    tr.Append(tc1, tc2, tc3, tc4);
                    table1.Append(tr);
                }
                body.AppendChild(table1);
            }
        }
    }
}
