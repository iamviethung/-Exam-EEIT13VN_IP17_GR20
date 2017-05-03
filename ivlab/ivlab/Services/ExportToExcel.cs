using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ivlab.Core.Models;
using Microsoft.Office.Interop.Excel;
using Telerik.Windows.Controls.Charting;

namespace ivlab.Services
{
    public class ExportToExcel
    {

        public void ExportData(ObservableCollection<RefTimestamp> dataIn,List<bool> compBools, out bool isSuccess)
        {


            try
            {
                //Initiallise
                Microsoft.Office.Interop.Excel.Application excel;
                Microsoft.Office.Interop.Excel.Workbook workBook;
              

                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.DisplayAlerts = false;
                excel.Visible = false;
                workBook = excel.Workbooks.Add(Type.Missing);
                int compCount = 0;
                foreach (var compBool in compBools)
                {

                    Microsoft.Office.Interop.Excel.Worksheet workSheet_t1;

                    Microsoft.Office.Interop.Excel.Range cellRange;

                    if (compBool)
                    {
                        workSheet_t1 = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;

                        workSheet_t1.Cells.Font.Size = 11;

                        //HEADER
                        workSheet_t1.Cells[2, 1] = "Min Value";
                        workSheet_t1.Cells[2, 2] = "Max Value";
                        workSheet_t1.Cells[2, 3] = "Current Value";
                        workSheet_t1.Cells[2, 4] = "Timestamp";



                        switch (compCount)
                        {
                            case 0:
                            {
                                workSheet_t1.Name = "Tank 1";
                                workSheet_t1.Cells[1, 1] = "Tank 1";
                                workSheet_t1.Cells[1, 2] = dataIn[0].RootRefObject.tank1.description;
                                var rowcount = 3;
                                foreach (var refTimestamp in dataIn)
                                {

                                        workSheet_t1.Cells[rowcount, 1] = refTimestamp.RootRefObject.tank1.min;
                                        workSheet_t1.Cells[rowcount, 2] = refTimestamp.RootRefObject.tank1.max;
                                        workSheet_t1.Cells[rowcount, 3] = refTimestamp.RootRefObject.tank1.actual;
                                        workSheet_t1.Cells[rowcount, 4] = refTimestamp.Timestamp;
                                        rowcount++;
                                        cellRange = workSheet_t1.Range[workSheet_t1.Cells[1, 1], workSheet_t1.Cells[rowcount, 4]];
                                        cellRange.EntireColumn.AutoFit();
                                    }
                                break;
                            }
                            case 1:
                            {
                                    workSheet_t1.Name = "Tank 2";
                                    workSheet_t1.Cells[1, 1] = "Tank 2";
                                    workSheet_t1.Cells[1, 2] = dataIn[0].RootRefObject.tank2.description;
                                    var rowcount = 3;
                                    foreach (var refTimestamp in dataIn)
                                    {

                                        workSheet_t1.Cells[rowcount, 1] = refTimestamp.RootRefObject.tank2.min;
                                        workSheet_t1.Cells[rowcount, 2] = refTimestamp.RootRefObject.tank2.max;
                                        workSheet_t1.Cells[rowcount, 3] = refTimestamp.RootRefObject.tank2.actual;
                                        workSheet_t1.Cells[rowcount, 4] = refTimestamp.Timestamp;
                                        rowcount++;
                                        cellRange = workSheet_t1.Range[workSheet_t1.Cells[1, 1], workSheet_t1.Cells[rowcount, 4]];
                                        cellRange.EntireColumn.AutoFit();
                                    }
                                    break;
                            }
                            case 2:
                            {
                                    workSheet_t1.Name = "Tank 3";
                                    workSheet_t1.Cells[1, 1] = "Tank 3";
                                    workSheet_t1.Cells[1, 2] = dataIn[0].RootRefObject.tank3.description;
                                    var rowcount = 3;
                                    foreach (var refTimestamp in dataIn)
                                    {

                                        workSheet_t1.Cells[rowcount, 1] = refTimestamp.RootRefObject.tank3.min;
                                        workSheet_t1.Cells[rowcount, 2] = refTimestamp.RootRefObject.tank3.max;
                                        workSheet_t1.Cells[rowcount, 3] = refTimestamp.RootRefObject.tank3.actual;
                                        workSheet_t1.Cells[rowcount, 4] = refTimestamp.Timestamp;
                                        rowcount++;
                                        cellRange = workSheet_t1.Range[workSheet_t1.Cells[1, 1], workSheet_t1.Cells[rowcount, 4]];
                                        cellRange.EntireColumn.AutoFit();
                                    }
                                    break;
                                }
                            case 3:
                            {
                                    workSheet_t1.Name = "Pumpe 1";
                                    workSheet_t1.Cells[1, 1] = "Pumpe 1";
                                    workSheet_t1.Cells[1, 2] = dataIn[0].RootRefObject.pumpe1.description;
                                    var rowcount = 3;
                                    foreach (var refTimestamp in dataIn)
                                    {

                                        workSheet_t1.Cells[rowcount, 1] = refTimestamp.RootRefObject.pumpe1.min;
                                        workSheet_t1.Cells[rowcount, 2] = refTimestamp.RootRefObject.pumpe1.max;
                                        workSheet_t1.Cells[rowcount, 3] = refTimestamp.RootRefObject.pumpe1.actual;
                                        workSheet_t1.Cells[rowcount, 4] = refTimestamp.Timestamp;
                                        rowcount++;
                                        cellRange = workSheet_t1.Range[workSheet_t1.Cells[1, 1], workSheet_t1.Cells[rowcount, 4]];
                                        cellRange.EntireColumn.AutoFit();
                                    }
                                    break;
                                }
                            case 4:
                            {

                                    workSheet_t1.Name = "Pumpe 2";
                                    workSheet_t1.Cells[1, 1] = "Pumpe 2";
                                    workSheet_t1.Cells[1, 2] = dataIn[0].RootRefObject.pumpe1.description;
                                    var rowcount = 3;
                                    foreach (var refTimestamp in dataIn)
                                    {

                                        workSheet_t1.Cells[rowcount, 1] = refTimestamp.RootRefObject.pumpe2.min;
                                        workSheet_t1.Cells[rowcount, 2] = refTimestamp.RootRefObject.pumpe2.max;
                                        workSheet_t1.Cells[rowcount, 3] = refTimestamp.RootRefObject.pumpe2.actual;
                                        workSheet_t1.Cells[rowcount, 4] = refTimestamp.Timestamp;
                                        rowcount++;
                                        cellRange = workSheet_t1.Range[workSheet_t1.Cells[1, 1], workSheet_t1.Cells[rowcount, 4]];
                                        cellRange.EntireColumn.AutoFit();
                                    }
                                    break;
                                }


                            case 5:
                            {
                                    workSheet_t1.Name = "Pumpe 3";
                                    workSheet_t1.Cells[1, 1] = "Pumpe 3";
                                    workSheet_t1.Cells[1, 2] = dataIn[0].RootRefObject.pumpe3.description;
                                    var rowcount = 3;
                                    foreach (var refTimestamp in dataIn)
                                    {

                                        workSheet_t1.Cells[rowcount, 1] = refTimestamp.RootRefObject.pumpe3.min;
                                        workSheet_t1.Cells[rowcount, 2] = refTimestamp.RootRefObject.pumpe3.max;
                                        workSheet_t1.Cells[rowcount, 3] = refTimestamp.RootRefObject.pumpe3.actual;
                                        workSheet_t1.Cells[rowcount, 4] = refTimestamp.Timestamp;
                                        rowcount++;
                                        cellRange = workSheet_t1.Range[workSheet_t1.Cells[1, 1], workSheet_t1.Cells[rowcount, 4]];
                                        cellRange.EntireColumn.AutoFit();
                                    }
                                    break;
                                }
                            case 6:
                            {
                                    workSheet_t1.Name = "Adg 1";
                                    workSheet_t1.Cells[1, 1] = "Adg 1";
                                    workSheet_t1.Cells[1, 2] = dataIn[0].RootRefObject.adg1.description;
                                    var rowcount = 3;
                                    foreach (var refTimestamp in dataIn)
                                    {

                                        workSheet_t1.Cells[rowcount, 1] = refTimestamp.RootRefObject.adg1.min;
                                        workSheet_t1.Cells[rowcount, 2] = refTimestamp.RootRefObject.adg1.max;
                                        workSheet_t1.Cells[rowcount, 3] = refTimestamp.RootRefObject.adg1.actual;
                                        workSheet_t1.Cells[rowcount, 4] = refTimestamp.Timestamp;
                                        rowcount++;
                                        cellRange = workSheet_t1.Range[workSheet_t1.Cells[1, 1], workSheet_t1.Cells[rowcount, 4]];
                                        cellRange.EntireColumn.AutoFit();
                                    }
                                    break;
                            }
                            case 7:
                            {
                                    workSheet_t1.Name = "Adg 2";
                                    workSheet_t1.Cells[1, 1] = "Adg 2";
                                    workSheet_t1.Cells[1, 2] = dataIn[0].RootRefObject.adg2.description;
                                    var rowcount = 3;
                                    foreach (var refTimestamp in dataIn)
                                    {

                                        workSheet_t1.Cells[rowcount, 1] = refTimestamp.RootRefObject.adg2.min;
                                        workSheet_t1.Cells[rowcount, 2] = refTimestamp.RootRefObject.adg2.max;
                                        workSheet_t1.Cells[rowcount, 3] = refTimestamp.RootRefObject.adg2.actual;
                                        workSheet_t1.Cells[rowcount, 4] = refTimestamp.Timestamp;
                                        rowcount++;
                                        cellRange = workSheet_t1.Range[workSheet_t1.Cells[1, 1], workSheet_t1.Cells[rowcount, 4]];
                                        cellRange.EntireColumn.AutoFit();
                                    }
                                    break;
                                }
                            case 8:
                            {
                                    workSheet_t1.Name = "Adg 3";
                                    workSheet_t1.Cells[1, 1] = "Adg 3";
                                    workSheet_t1.Cells[1, 2] = dataIn[0].RootRefObject.adg3.description;
                                    var rowcount = 3;
                                    foreach (var refTimestamp in dataIn)
                                    {

                                        workSheet_t1.Cells[rowcount, 1] = refTimestamp.RootRefObject.adg3.min;
                                        workSheet_t1.Cells[rowcount, 2] = refTimestamp.RootRefObject.adg3.max;
                                        workSheet_t1.Cells[rowcount, 3] = refTimestamp.RootRefObject.adg3.actual;
                                        workSheet_t1.Cells[rowcount, 4] = refTimestamp.Timestamp;
                                        rowcount++;
                                        cellRange = workSheet_t1.Range[workSheet_t1.Cells[1, 1], workSheet_t1.Cells[rowcount, 4]];
                                        cellRange.EntireColumn.AutoFit();
                                    }
                                    break;
                                }
                            case 9:
                            {
                                    workSheet_t1.Name = "Gas 1";
                                    workSheet_t1.Cells[1, 1] = "Gas 1";
                                    workSheet_t1.Cells[1, 2] = dataIn[0].RootRefObject.gas1.description;
                                    var rowcount = 3;
                                    foreach (var refTimestamp in dataIn)
                                    {

                                        workSheet_t1.Cells[rowcount, 1] = refTimestamp.RootRefObject.gas1.min;
                                        workSheet_t1.Cells[rowcount, 2] = refTimestamp.RootRefObject.gas1.max;
                                        workSheet_t1.Cells[rowcount, 3] = refTimestamp.RootRefObject.gas1.actual;
                                        workSheet_t1.Cells[rowcount, 4] = refTimestamp.Timestamp;
                                        rowcount++;
                                        cellRange = workSheet_t1.Range[workSheet_t1.Cells[1, 1], workSheet_t1.Cells[rowcount, 4]];
                                        cellRange.EntireColumn.AutoFit();
                                    }
                                    break;
                                }
                            case 10:
                                {
                                    workSheet_t1.Name = "Gas 2";
                                    workSheet_t1.Cells[1, 1] = "Gas 2";
                                    workSheet_t1.Cells[1, 2] = dataIn[0].RootRefObject.gas2.description;
                                    var rowcount = 3;
                                    foreach (var refTimestamp in dataIn)
                                    {

                                        workSheet_t1.Cells[rowcount, 1] = refTimestamp.RootRefObject.gas2.min;
                                        workSheet_t1.Cells[rowcount, 2] = refTimestamp.RootRefObject.gas2.max;
                                        workSheet_t1.Cells[rowcount, 3] = refTimestamp.RootRefObject.gas2.actual;
                                        workSheet_t1.Cells[rowcount, 4] = refTimestamp.Timestamp;
                                        rowcount++;
                                        cellRange = workSheet_t1.Range[workSheet_t1.Cells[1, 1], workSheet_t1.Cells[rowcount, 4]];
                                        cellRange.EntireColumn.AutoFit();
                                    }
                                    break;
                                }
                           
                            default:
                                break;
                        }
                        
                        workBook.Worksheets.Add(workSheet_t1);
                        compCount++;
                    }
                }

                isSuccess = true;
                workBook.SaveAs(System.IO.Path.Combine(@"C:\","ivlab"));
                workBook.Close(); excel.Quit();
                
            }
            catch (Exception e)
            {
                isSuccess = false;
                Debug.WriteLine(e);
            }
        }

    }
}
