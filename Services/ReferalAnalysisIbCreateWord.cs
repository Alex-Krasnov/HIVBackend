using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using HIVBackend.Data;

namespace HIVBackend.Services
{
    public class ReferalAnalysisIbCreateWord
    {
        public void GenerateWordFile(int patientId, string docName, HivContext _context, string path)
        {
            var patient = _context.TblPatientCards.Where(e => e.PatientId == patientId).First();

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document))
            {
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

                string addr = "", addrFact = "";
                addr += "рег. " + _context.TblRegions.FirstOrDefault(e => e.RegionId == patient.RegionId)?.RegionLong;
                addr += " г. " + patient.CityName;
                addr += " нас. пункт " + patient.LocationName;
                addr += " тел. " + patient.AddrInd;
                addr += " ул. " + patient.AddrStreet;
                addr += " д. " + patient.AddrHouse;
                addr += " к. " + patient.AddrExt;
                addr += " кв. " + patient.AddrFlat;

                addrFact += "рег. " + _context.TblRegions.FirstOrDefault(e => e.RegionId == patient.FactRegionId)?.RegionLong;
                addrFact += " г. " + patient.FactCityName;
                addrFact += " нас. пункт " + patient.FactLocationName;
                addrFact += " тел. " + patient.FactAddrInd;
                addrFact += " ул. " + patient.FactAddrStreet;
                addrFact += " д. " + patient.FactAddrHouse;
                addrFact += " к. " + patient.FactAddrExt;
                addrFact += " кв. " + patient.FactAddrFlat;

                Paragraph para8 = body.AppendChild(new Paragraph());
                para8.AddChild(new Run(new Text("Адрес: ")));
                para8.Append(new Run(new RunProperties(new Bold()), new Text(addr)));

                Paragraph para9 = body.AppendChild(new Paragraph());
                para9.AddChild(new Run(new Text("Адрес фактический: ")));
                para9.Append(new Run(new RunProperties(new Bold()), new Text(addrFact)));

                Paragraph para10 = body.AppendChild(new Paragraph());
                para10.AddChild(new Run(new Text("ФИО лечащего врача: ")));
                para10.Append(new Run(new RunProperties(new Bold()), new Text(docName)));

                Paragraph para11 = body.AppendChild(new Paragraph(
                    new Run(new RunProperties(new Bold()), new Text("Наименование тестов:"))));

                Table table = new();
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

                table.AppendChild<TableProperties>(props);

                var tr = new TableRow();
                var tc = new TableCell();
                tc.Append(new Paragraph(new Run(new RunProperties(new Bold()), new Text("ИБ"))));
                tr.Append(tc);
                table.Append(tr);

                body.AppendChild(table);
            }
        }
    }
}
