using exchangeRates;
using MNBDataLoad.mnbDataLoad;
using mndDataLoad;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MNBDataLoad
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            var client = new MNBArfolyamServiceSoapImpl();

            var currencies = client.GetCurrencies(new GetCurrenciesRequestBody());

            var bytes = Encoding.UTF8.GetBytes(currencies.GetCurrenciesResult);
            var stream = new MemoryStream(bytes);

            var serializer = new XmlSerializer(typeof(MNBCurrencies));
            var deserialized = (MNBCurrencies)serializer.Deserialize(stream);

            var currencyNames = string.Join(",", deserialized.Currencies.Curr);

            var getExchangeRates = client.GetExchangeRates(new GetExchangeRatesRequestBody()
            {
                currencyNames = currencyNames,
                startDate = "2015-01-01",
                endDate = "2020-04-01"
            });

            var bytes2 = Encoding.UTF8.GetBytes(getExchangeRates.GetExchangeRatesResult);
            var stream2 = new MemoryStream(bytes2);

            var serializer2 = new XmlSerializer(typeof(MNBExchangeRates));
            var deserialized2 = (MNBExchangeRates)serializer2.Deserialize(stream2);

            var sb = new StringBuilder("Date;Currency;Unit;Rate");

            var csvFile = sb.ToString();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");

                FileInfo excelFile = new FileInfo(@"D:\BCE-GTK\KPMGtest\arfolyam-letoltes.xlsx");
                excel.SaveAs(excelFile);
                
                var excelWorksheet = excel.Workbook.Worksheets["Worksheet1"];

                List<string[]> headerRow = new List<string[]>()
                {
                  new string[] { "Date", "Currency", "Unit", "Rate" }
                };

                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
                excelWorksheet.Cells[headerRange].LoadFromArrays(headerRow);

                int row = 1;
                int col;

                foreach (var day in deserialized2.Day)
                {
                    col = 1;
                    row++;
                    foreach (var rate in day.Rate)
                    {
                        sb.AppendFormat("\n{0};{1};{2};{3}", day.Date, rate.Curr, rate.Unit, rate.Text);

                        excelWorksheet.Cells[row, col].LoadFromCollection(day.Date);
                        col++;
                        excelWorksheet.Cells[row, col].LoadFromCollection(rate.Curr);                       
                        col++;
                        excelWorksheet.Cells[row, col].LoadFromCollection(rate.Unit);                        
                        col++;
                        excelWorksheet.Cells[row, col].LoadFromCollection(rate.Text);
                        
                    }
                }

                excelWorksheet.Cells[1, 2].Value = "asd";

                bool isExcelInstalled = Type.GetTypeFromProgID("Excel.Application") != null ? true : false;
                if (isExcelInstalled)
                {
                    System.Diagnostics.Process.Start(excelFile.ToString());
                }

            }


        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
