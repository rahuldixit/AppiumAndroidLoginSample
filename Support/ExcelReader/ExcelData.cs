using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE2AutomatedTesting.Support
{
    public static class ExcelData
    {
        public static DataSet worksheets;

        public static void ReadData()
        {
            using (var stream = File.Open(Config.ExcelData, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                        }
                    } while (reader.NextResult());

                    worksheets = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                         ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                            FilterRow = rowReader =>
                            {
                                var hasData = false;
                                for (var i = 0; i < rowReader.FieldCount; i++)
                                {
                                    if (rowReader[i] == null || string.IsNullOrEmpty(rowReader[i].ToString()))
                                    {
                                        continue;
                                    }

                                    hasData = true;
                                    break;
                                }

                                return hasData;
                            }
                            
                        }
                    }); 
                }
            }
        }

        private static DataTable GetExcelWorkSheet(string workSheetName)
        {
            DataTable workSheet = worksheets.Tables[workSheetName];

            if (workSheet == null)
            {
                throw new Exception(string.Format("The worksheet {0} does not exist, has an incorrect name, or does not have any data in the worksheet", workSheetName));
            }

            return workSheet;
        }

        public static string GetData(string workSheetName, string testCaseId, string columnName)
        {
            DataTable workSheet = GetExcelWorkSheet(workSheetName);

            var rows = from DataRow row in workSheet.Rows
                       select row;


            var columnData = rows.FirstOrDefault(x => x.ItemArray[0].ToString() == testCaseId).Table.Rows[0][columnName].ToString();

            if (columnData == null)
            {
                throw new Exception(string.Format("The column {0} does not exist, has an incorrect name", columnName));
            }

            return columnData;
        }



    }
}
