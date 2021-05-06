using Core31TestProject.Interfaces;
using Core31TestProject.Models;
using Core31TestProject.Services;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Core31TestProject.MainTestFiles
{
    public class FBranchMainEntrance : TestBaseForMainEntrance
    {
        public override void MainRun()
        {
            #region Tested
            //ExcelDataReaderTest();
            //DocumentFormat_OpenXmlTest();
            //Console.WriteLine(GetExcelCol(701));
            //Console.WriteLine(GetExcelColIndex("aa"));
            //FilePathTest();
            //Task.WaitAll(FtpServiceTEST());
            //Task.WaitAll(SftpSingleFileServiceTest()); 
            //Task.WaitAll(Sftp_MultipleTasksDownFilesTest());
            //Task.WaitAll(ForeachLoopEmpty());
            //Task.WaitAll(MD5CreateTEST());
            //Task.WaitAll(StringTest());
            //Task.WaitAll(ForEachFilterTEST());
            //Task.WaitAll(RelectTest());
            //Task.WaitAll(StringFormatTest());
            //Task.WaitAll(MockTest());
            //Task.WaitAll(ReflectTest());
            Task.WaitAll(NewtonJsonPropertiesTest());
            #endregion

            //GZFileExtractTest();

        }

        private async Task NewtonJsonPropertiesTest()
        {
            string[] strList = null;    // new string[] {  };//"aaa"
            if ((strList?.Length) > 0)
            {
                var svl = strList[0];
            }


            JsonPropertiesIgnoreTestClass jpit = new JsPEx();
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(jpit);

            string json = "{'HellWorld':'DeSerialize', Name:'JJJJJ'}";
            var jpit1 = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonPropertiesIgnoreTestClass>(json);
            var jpit2 = Newtonsoft.Json.JsonConvert.DeserializeObject<JsPEx>(json);
            var jpit3 = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            var outJson = Newtonsoft.Json.JsonConvert.SerializeObject(jpit3, Newtonsoft.Json.Formatting.Indented);
        }

        private async Task ReflectTest()
        {
            var type = typeof(Base2);
            var properties = type.GetProperties();
        }
        private async Task MockTest()
        {
            //InvocationAction
            int ix = 0, rx = 0;
            var mockInt = new Mock<IMockTest>();
            mockInt.Setup(x => x.GetInt(It.IsAny<int>()))
                .Callback<int>((i) => { ix = i; })
                .Returns<int>(i => { rx = i; return StGetInt(rx); });
            var op = mockInt.Object;
            var cw = op.GetInt(2);
            var x1 = op.GetInt(1);
        }

        public static string StGetInt(int ix)
        {
            return ix.ToString() + 100;
        }
        private async Task StringFormatTest()
        {
            var dicItem = new Dictionary<string, string> { { "aaa", "v=aaa" }, { "bbb", "v=bbb" } };
            Console.WriteLine(dicItem["aaa"]);
            Console.WriteLine(dicItem.GetValueOrDefault("ccc"));

            bool? atm = null;
            Console.WriteLine(atm.HasValue);
            Console.WriteLine($"Date Now - '{DateTime.Now:MM-dd-yyyy}'");
            Console.WriteLine(DateTime.UtcNow.ToString());
            string aaa = "aaa";
            Console.WriteLine(!(aaa is "aaa"));
            Console.WriteLine(333.25555.ToString("C4"));
        }

        public static string CreateCacheID(string type, params string[] keys)
            => $"{type}||{string.Join("||", keys)}";
        private async Task RelectTest()
        {
            List<Base2> list = new List<Base2>();
            int loop = 30;
            for (int i = 0; i < loop; i++)
            {
                list.Add(new Base2 { Acx = i });
            }

            var skippedList = list.Skip(20).ToList();

            var express = list.Where(x => x.Acx < 15);
            foreach (var xx in express)
            {
                xx.Acx += 50;
            }

            var mvr = express.ToList();

            int? ix = null, mx = null;
            ix = mx + 9;
            Console.WriteLine(ix.HasValue);
            Console.WriteLine(mx + 9);
            Console.WriteLine(ix > (mx + 9));
            //Console.WriteLine(new DateTime(44158));
            //Console.WriteLine($"------------------");
            Console.WriteLine(DateTime.ParseExact("21/11/2020","dd/MM/yyyy", null).ToString());
            Console.WriteLine($"------------------");
            Console.WriteLine(CreateCacheID("String", "here", "there", "other"));
            Console.WriteLine("------------------");
            var task = Task.Run(async () =>
            {
                return await Task.FromResult(111);
            });
            var rsl = await task;
            Console.WriteLine(rsl);

            IBCI exb = new ExFromBase();
            var type = exb.GetType();
            Console.WriteLine(type.Name);
        }

        private async Task ForEachFilterTEST()
        {
            List<Employee> emps = new List<Employee>();
            for (int i = 0; i < 50; i++)
            {
                emps.Add(new Employee { ID = i, Age = 30, FName = $"Index - {i}", Sex = 'M' });
            }
            foreach (var item in emps.Where(x => x.Sex == 'M'))
            {
                item.Sex = 'F';
            }

        }

        private int GetIntFromExcelColumn(string str)
        {
            int result = 0;
            var array = str.ToUpper().ToCharArray();
            //for (int i = array.Length - 1; i > -1; i--)
            //{
            //    result += (int)Math.Pow(26, array.Length - i - 1) * (array[i] - 'A' + 1);
            //}
            for (int i = 0; i < array.Length; i++)
            {
                result += (int)Math.Pow(26, array.Length - i - 1) * (array[i] - 'A' + 1);
            }
            return result - 1;
        }
        private static string GetShippingSequenceLoop(int shipSequence)
        {
            var result = "";
            int major, sequence = shipSequence;
            do
            {
                major = sequence / 26;
                var minor = sequence % 26;
                result = ((char)(minor + 'A')).ToString() + result;
                sequence = major - 1;
            } while (major > 0);
            return result;
        }
        private async Task StringTest()
        {
            int aa = 0;
            Console.WriteLine(++aa);
            for (int i = aa; i < 0; i++)
            {
                string prf = GetShippingSequenceLoop(i);
                Console.WriteLine($"{prf} - {i} - {GetIntFromExcelColumn(prf)}");
            }
            Console.WriteLine("-----------------------");
            string temp = "0123456789A";
            Console.WriteLine(temp[2..]);
            Console.WriteLine(GetShippingCodeByDigital("TR31GGG4001", 35));
            Console.WriteLine(
                string.Concat("aa", "", null, "ss")
                );
        }
        private string GetShippingCodeByDigital(string orderNumber, int shipSequence)
        {
            Regex reg = new Regex("[0-9]{2}");

            {//--
                var matches = reg.Matches(orderNumber);
                var reped = reg.Replace(orderNumber, GetShippingSequence(shipSequence), 1, matches[1].Index);
                //--
            }
            return reg.Replace(orderNumber, GetShippingSequence(shipSequence), 1);
        }
        private string GetShippingCode(string orderNumber, int shipSequence)
        {
            string prefix = "";
            Regex reg = new Regex("[a-zA-Z]+");
            var matches = reg.Matches(orderNumber);
            if (matches.Count > 0 && matches[0].Index == 0)
                prefix = matches[0].Value;
            var leftString = orderNumber[prefix.Length..];
            prefix += GetShippingSequence(shipSequence);
            if (leftString.Length > 2)
                leftString = leftString[2..];
            else
                leftString = "";
            return prefix + leftString;
        }
        private static string GetShippingSequence(int colIndex)
        {
            var major = colIndex / 26;
            var minor = colIndex % 26;
            var last = ((char)(minor + 'A')).ToString();
            if (major > 0)
                return GetShippingSequence(major - 1) + last;
            return last;
        }

        private async Task MD5CreateTEST()
        {
            var md5String = GetHashCode("111111");
            Console.WriteLine(md5String);
        }
        private string GetHashCode(string str)
        {
            string rsl = "";
            using (MD5 md5 = MD5.Create())
            {
                byte[] md5Bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                md5.Clear();
                rsl = BitConverter.ToString(md5Bytes).Replace("-", "");
            }
            return rsl;
        }

        private async Task ForeachLoopEmpty()
        {
            int loop = 100000;
            List<int> list = new List<int>(loop);
            Console.WriteLine(DateTime.Now);
            foreach (var itm in list)
            {
                var itsc = itm;
                var ob = itm > 300;
            }
            Console.WriteLine(DateTime.Now);
        }

        private async Task Sftp_MultipleTasksDownFilesTest()
        {
            SFTPService sftp = new SFTPService();
            FTPSettings ftpSettings = new FTPSettings { Server = new FTPServer() };
            ftpSettings.OutPutPath = @"D:\Temp\FTPOutputFiles\";
            ftpSettings.RootPath = "XXXXXXXX";
            ftpSettings.SemaphoreSlimInit = 3;
            ftpSettings.SemaphoreSlimMax = 5;
            ftpSettings.Server.Host = "XXXXXXXX";
            ftpSettings.Server.Port = 22;
            ftpSettings.Server.UserId = "XXXXXXXX";
            ftpSettings.Server.Password = "XXXXXXXX";
            var list = await sftp.DownLoadAsync(ftpSettings);
        }

        private async Task SftpSingleFileServiceTest()
        {
            TransferSetting setting = new TransferSetting();
            setting.Host = "XXXXXXXX";
            setting.Protocol = "sftp";
            setting.Port = 22;
            setting.User = "XXXXXXXX";
            setting.Password = "XXXXXXXX";
            setting.RemotePath = "XXXXXXXX";
            setting.LocalPath = @"D:\Temp\FTPOutputFiles\";

            SftpSingleFileService sftp = new SftpSingleFileService(setting);
            var flist = (await sftp.GetFilesAsync()).ToList();
            var localPath = await sftp.DownloadFileAsync(flist[0]);
            //await sftp.DeleteFileAsync(flist[0]);

            //var flocal = @"D:\Temp\FTPOutputFiles\105454.TXT.gz";
            //await sftp.UploadFileAsync(flocal);
        }

        private async Task FtpServiceTEST()
        {
            FTPSettings ftpSettings = new FTPSettings
            {
                OutPutPath = @"D:\Temp\FTPOutputFiles",
                RootPath = "Input",
                SemaphoreSlimInit = 2,
                SemaphoreSlimMax = 3,
                Server = new FTPServer
                {
                    Host = "ftp://localhost",
                    Port = 21,
                    UserId = @"XXXXXXXX",
                    Password = "XXXXXXXX"
                }
            };
            FTPService ftp = new FTPService();
            var dlList = await ftp.DownLoadAsync(ftpSettings);
            //await ftp.DeleteFilesAsync(dlList, ftpSettings);
        }

        private void GZFileExtractTest()
        {
            string srcGzFile = @"D:\Temp\OFP\20201125_105454.TXT.gz";
            string destFolder = @"D:\Temp\OFP\Extracts";
            Decompress(new FileInfo(srcGzFile), destFolder);
        }

        public static void Decompress(FileInfo fileToDecompress, string outputPath)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.Name;
                string newFileName = $"{outputPath}\\{currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length)}";

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
        }

        private void FilePathTest()
        {
            string exlPath = @"D:\Temp\20201009.xlsx.csvx";
            var fn = Path.GetFileName(exlPath);
            var fnf = Path.GetFileNameWithoutExtension(exlPath);
            var pth = Path.GetDirectoryName(exlPath);

            Console.WriteLine(fn);
            Console.WriteLine(fnf);
            Console.WriteLine(pth);
        }

        public static string GetExcelCol(int colIndex)
        {
            var major = colIndex / 26;
            var minor = colIndex % 26;
            var last = ((char)(minor + 'A')).ToString();
            if (major > 0)
                return GetExcelCol(major - 1) + last;
            return last;
        }

        public static int GetExcelColIndex(string x)
        {
            var result = 0;
            var arr = x.ToUpper().ToCharArray();
            for (int i = x.Length - 1; i >= 0; i--)
            {
                result += (arr[i] - 'A' + 1) * (int)Math.Pow(26, x.Length - i - 1);
            }
            return result - 1;
        }

        private void DocumentFormat_OpenXmlTest()
        {
            var filePath = @"D:\Temp\20201009.xlsx";
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, true))
            {
                WorkbookPart wbPart = doc.WorkbookPart;

                SharedStringTablePart shareStringPart;
                if (wbPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                    shareStringPart = wbPart.GetPartsOfType<SharedStringTablePart>().First();
                else
                    shareStringPart = wbPart.AddNewPart<SharedStringTablePart>();
                //string[] shareStringItemValues = shareStringPart.GetItemValues().ToArray();

                Worksheet worksheet = wbPart.WorksheetParts.First().Worksheet;
                //statement to get the sheetdata which contains the rows and cell in table  
                SheetData sheetData = worksheet.GetFirstChild<SheetData>();
                var count = sheetData.Count();

                var row1 = sheetData.GetRow(2);
                var cells = row1.Elements<Cell>().ToList();
                var countCells = cells.Count();

                //for (int i = 0; i < countCells; i++)
                //{
                //    var cell = cells[0];
                //    var type = cell.CellReference.Value; // D2, the lication tag of the cell
                //    var str = cell.GetValue(shareStringPart);
                //    string dtStr = DateTime.FromOADate(44112.771203703807).ToString();

                //    //cells[i].SetValue(i.ToString(), shareStringPart);
                //}

                //var c = cells.First();
                //var str = c.GetValue(shareStringItemValues);

                var celltoAppend = new Cell().SetValue("XXXXXXDEEEEEEEEEEEEEEEEEEE", shareStringPart);
                //celltoAppend.CellReference = new StringValue("AS2");
                row1.AppendChild(
                    celltoAppend
                    );
                //row1.InsertAt(celltoAppend, 0);

                //foreach (var itm in sheetData)
                //{
                //    var childCouunt = itm.ChildElements.Count;
                //    foreach (var cel in itm.ChildElements)
                //    {
                //        var str = cel.InnerText;
                //    }
                //}

                //Append row to Excel
                //sheetData.AppendChild(row);

                doc.Close();
            }
        }

        private void ExcelDataReaderTest()
        {
            StringBuilder sb = new StringBuilder();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var filePath = @"D:\Temp\MITEMEXTRACT.xlsx";
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                            var lineSb = new StringBuilder();
                            // reader.GetDouble(0);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                lineSb.Append(reader[i] ?? "/");
                            }
                            lineSb.Append(Environment.NewLine);
                            sb.Append(lineSb);
                            var sstr = lineSb.ToString();
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    //var result = reader.AsDataSet();

                    // The result of each spreadsheet is in result.Tables
                }

                var str = sb.ToString();
            }
        }
    }


    public static class OpenXmlExcelExtentions
    {
        public static Sheet GetSheet(this WorkbookPart workbookPart, string sheetName)
        {
            return workbookPart.Workbook
                .GetFirstChild<Sheets>()
                .Elements<Sheet>().Where(s => s.Name == sheetName).FirstOrDefault();
        }

        /// <summary>
        /// Given a worksheet and a row index, return the row.
        /// </summary>
        /// <param name="sheetData"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static Row GetRow(this SheetData sheetData, uint rowIndex)
        {
            return sheetData.
                  Elements<Row>().Where(r => r.RowIndex == rowIndex).FirstOrDefault();
        }
        public static Cell GetCell(this SheetData sheetData, string columnName, uint rowIndex)
        {
            Row row = GetRow(sheetData, rowIndex);

            if (row == null)
                return null;

            return row.Elements<Cell>().Where(c => string.Compare
                      (c.CellReference.Value, columnName +
                      rowIndex, true) == 0).FirstOrDefault();
        }

        // https://msdn.microsoft.com/en-us/library/office/cc861607.aspx
        // Given a column name, a row index, and a WorksheetPart, inserts a cell into the worksheet.
        // If the cell already exists, returns it.
        public static Cell GetOrCreateCell(this SheetData sheetData, string columnName, uint rowIndex)
        {
            string cellReference = columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            return row.GetOrCreateCell(cellReference);
        }
        public static Cell GetOrCreateCell(this Row row, string cellReference)
        {
            // If there is not a cell with the specified column name, insert one.
            if (row.Elements<Cell>().Where(c => c?.CellReference?.Value == cellReference).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (cell.CellReference.Value.Length == cellReference.Length)
                    {
                        if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                        {
                            refCell = cell;
                            break;
                        }
                    }
                }

                Cell newCell = new Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);
                return newCell;
            }
        }

        public static string GetValue(this Cell cell, SharedStringTablePart shareStringPart)
        {
            if (cell == null)
                return null;
            string cellvalue = cell.InnerText;
            if (cell.DataType != null)
            {
                if (cell.DataType == CellValues.SharedString)
                {
                    int id = -1;
                    if (Int32.TryParse(cellvalue, out id))
                    {
                        SharedStringItem item = GetItem(shareStringPart, id);
                        if (item.Text != null)
                        {
                            //code to take the string value
                            cellvalue = item.Text.Text;
                        }
                        else if (item.InnerText != null)
                        {
                            cellvalue = item.InnerText;
                        }
                        else if (item.InnerXml != null)
                        {
                            cellvalue = item.InnerXml;
                        }
                    }
                }
            }
            return cellvalue;
        }
        public static string GetValue(this Cell cell, string[] shareStringPartValues)
        {
            if (cell == null)
                return null;
            string cellvalue = cell.InnerText;
            if (cell.DataType != null)
            {
                if (cell.DataType == CellValues.SharedString)
                {
                    int id = -1;
                    if (Int32.TryParse(cellvalue, out id))
                    {
                        cellvalue = shareStringPartValues[id];
                    }
                }
            }
            return cellvalue;
        }

        public static Cell SetValue(this Cell cell, object value = null, SharedStringTablePart shareStringPart = null, int shareStringItemIndex = -1, uint styleIndex = 0)
        {
            if (value == null)
            {
                cell.CellValue = new CellValue();
                if (shareStringItemIndex != -1)
                {
                    cell.CellValue = new CellValue(shareStringItemIndex.ToString());
                    cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                }
            }
            else if (value is string str)
            {
                if (shareStringPart == null)
                {
                    cell.CellValue = new CellValue(str);
                    cell.DataType = new EnumValue<CellValues>(CellValues.String);
                }
                else
                {
                    // Insert the text into the SharedStringTablePart.
                    int index = shareStringPart.GetOrInsertItem(str, false);
                    // Set the value of cell
                    cell.CellValue = new CellValue(index.ToString());
                    cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                }
            }
            else if (value is int || value is short || value is long ||
              value is float || value is double || value is uint ||
              value is ulong || value is ushort || value is decimal)
            {
                cell.CellValue = new CellValue(value.ToString());
                cell.DataType = new EnumValue<CellValues>(CellValues.Number);
            }
            else if (value is DateTime date)
            {
                cell.CellValue = new CellValue(date.ToString("yyyy-MM-dd")); // ISO 861
                cell.DataType = new EnumValue<CellValues>(CellValues.Date);
            }
            else if (value is XmlDocument xd)
            {
                if (shareStringPart == null)
                {
                    throw new Exception("Param [shareStringPart] can't be null when value type is XmlDocument.");
                }
                else
                {
                    int index = shareStringPart.GetOrInsertItem(xd.OuterXml, true);
                    // Set the value of cell
                    cell.CellValue = new CellValue(index.ToString());
                    cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                }
            }

            if (styleIndex != 0)
                cell.StyleIndex = styleIndex;

            return cell;
        }

        // https://msdn.microsoft.com/en-us/library/office/gg278314.aspx
        // Given text and a SharedStringTablePart, creates a SharedStringItem with the specified text
        // and inserts it into the SharedStringTablePart. If the item already exists, returns its index.
        public static int GetOrInsertItem(this SharedStringTablePart shareStringPart, string content, bool isXml)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if ((!isXml && item.InnerText == content) || (isXml && item.OuterXml == content))
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            if (isXml)
                shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(content));
            else
                shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new Text(content)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }
        private static SharedStringItem GetItem(this SharedStringTablePart shareStringPart, int id)
        {
            return shareStringPart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
        }

        /// <summary>
        ///  https://docs.microsoft.com/en-us/office/open-xml/how-to-merge-two-adjacent-cells-in-a-spreadsheet
        /// </summary>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        public static MergeCells GetOrCreateMergeCells(this Worksheet worksheet)
        {
            MergeCells mergeCells;
            if (worksheet.Elements<MergeCells>().Count() > 0)
            {
                mergeCells = worksheet.Elements<MergeCells>().First();
            }
            else
            {
                mergeCells = new MergeCells();

                // Insert a MergeCells object into the specified position.
                if (worksheet.Elements<CustomSheetView>().Count() > 0)
                {
                    worksheet.InsertAfter(mergeCells, worksheet.Elements<CustomSheetView>().First());
                }
                else if (worksheet.Elements<DataConsolidate>().Count() > 0)
                {
                    worksheet.InsertAfter(mergeCells, worksheet.Elements<DataConsolidate>().First());
                }
                else if (worksheet.Elements<SortState>().Count() > 0)
                {
                    worksheet.InsertAfter(mergeCells, worksheet.Elements<SortState>().First());
                }
                else if (worksheet.Elements<AutoFilter>().Count() > 0)
                {
                    worksheet.InsertAfter(mergeCells, worksheet.Elements<AutoFilter>().First());
                }
                else if (worksheet.Elements<Scenarios>().Count() > 0)
                {
                    worksheet.InsertAfter(mergeCells, worksheet.Elements<Scenarios>().First());
                }
                else if (worksheet.Elements<ProtectedRanges>().Count() > 0)
                {
                    worksheet.InsertAfter(mergeCells, worksheet.Elements<ProtectedRanges>().First());
                }
                else if (worksheet.Elements<SheetProtection>().Count() > 0)
                {
                    worksheet.InsertAfter(mergeCells, worksheet.Elements<SheetProtection>().First());
                }
                else if (worksheet.Elements<SheetCalculationProperties>().Count() > 0)
                {
                    worksheet.InsertAfter(mergeCells, worksheet.Elements<SheetCalculationProperties>().First());
                }
                else
                {
                    worksheet.InsertAfter(mergeCells, worksheet.Elements<SheetData>().First());
                }
                worksheet.Save();
            }
            return mergeCells;
        }

        /// <summary>
        ///  Given the names of two adjacent cells, merges the two cells.
        ///  Create the merged cell and append it to the MergeCells collection.
        ///  When two cells are merged, only the content from one cell is preserved:
        ///  the upper-left cell for left-to-right languages or the upper-right cell for right-to-left languages.
        /// </summary>
        /// <param name="mergeCells"></param>
        /// <param name="cell1Name"></param>
        /// <param name="cell2Name"></param>
        public static void MergeTwoCells(this MergeCells mergeCells, string cell1Name, string cell2Name)
        {
            MergeCell mergeCell = new MergeCell() { Reference = new StringValue(cell1Name + ":" + cell2Name) };
            mergeCells.Append(mergeCell);
        }

        public static IEnumerable<string> GetItemValues(this SharedStringTablePart shareStringPart)
        {
            foreach (var item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.Text != null)
                {
                    //code to take the string value
                    yield return item.Text.Text;
                }
                else if (item.InnerText != null)
                {
                    yield return item.InnerText;
                }
                else if (item.InnerXml != null)
                {
                    yield return item.InnerXml;
                }
                else
                {
                    yield return null;
                }
            };
        }
        public static XmlDocument GetCellAssociatedSharedStringItemXmlDocument(this SheetData sheetData, string columnName, uint rowIndex, SharedStringTablePart shareStringPart)
        {
            Cell cell = GetCell(sheetData, columnName, rowIndex);
            if (cell == null)
                return null;
            if (cell.DataType == CellValues.SharedString)
            {
                int id = -1;
                if (Int32.TryParse(cell.InnerText, out id))
                {
                    SharedStringItem ssi = shareStringPart.GetItem(id);
                    var doc = new XmlDocument();
                    doc.LoadXml(ssi.OuterXml);
                    return doc;
                }
            }
            return null;
        }
    }
}
