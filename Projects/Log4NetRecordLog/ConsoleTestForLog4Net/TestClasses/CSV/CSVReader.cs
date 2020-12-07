using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestForLog4Net.TestClasses.CSV
{
    public class CSVReader
    {
        public DataTable GetData(Stream stream)
        {
            using (stream)
            {
                using (StreamReader input = new StreamReader(stream, Encoding.GetEncoding("shift_jis")))
                {
                    using (CsvReader csv = new CsvReader(input, false))
                    {
                        DataTable dt = new DataTable();
                        int columnCount = csv.FieldCount;
                        for (int i = 0; i < columnCount; i++)
                        {
                            dt.Columns.Add("col" + i.ToString());
                        }

                        while (csv.ReadNextRecord())
                        {
                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < columnCount; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(csv[i]))
                                {
                                    dr[i] = csv[i];
                                }
                            }
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }

                }
            }
        }
    }
}
