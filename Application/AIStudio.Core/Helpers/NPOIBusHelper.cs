using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Core
{
    public static class NPOIBusHelper
    {
        /// <summary>
        /// Excel导入成Datable
        /// </summary>
        /// <param name="file">导入路径(包含文件名与扩展名)</param>
        /// <returns></returns>
        public static DataTable ExcelToTable(string file)
        {
            DataTable dt = new DataTable();

            IWorkbook workbook = null;
            try
            {
                workbook = NPOIHelper.GetWorkbook(file);

                //只考虑Sheet1的，不支持多sheet
                var worksheet = workbook.GetSheetAt(0);

                //表头  
                IRow header = worksheet.GetRow(worksheet.FirstRowNum);
                List<int> columns = new List<int>();
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = NPOIHelper.GetValueType(header.GetCell(i));
                    if (obj == null || obj.ToString() == string.Empty)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                    }
                    else
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    columns.Add(i);
                }
                //数据  
                for (int i = worksheet.FirstRowNum + 1; i <= worksheet.LastRowNum; i++)
                {
                    DataRow dr = dt.NewRow();
                    bool hasValue = false;
                    foreach (int j in columns)
                    {
                        if (worksheet.GetRow(i).GetCell(j).CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(worksheet.GetRow(i).GetCell(j)))
                        {
                            dr[j] = worksheet.GetRow(i).GetCell(j).DateCellValue;
                        }
                        else
                        {
                            dr[j] = NPOIHelper.GetValueType(worksheet.GetRow(i).GetCell(j));
                        }
                        if (dr[j] != null && dr[j].ToString() != string.Empty)
                        {
                            hasValue = true;
                        }
                    }
                    if (hasValue)
                    {
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close();
                }
            }

            return dt;
        }

        /// <summary>
        /// Datable导出成Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file">导出路径(包括文件名与扩展名)</param>
        public static void TableToExcel(DataTable dt, string file, Action<IWorkbook, ISheet> action)
        {
            try
            {
                IWorkbook workbook = NPOIHelper.CreateWorkbook(file);
                //添加一个sheet页
                ISheet workSheet = workbook.CreateSheet(string.IsNullOrEmpty(dt.TableName) ? "Sheet1" : dt.TableName);

                //表头  
                IRow headerRow = workSheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    NPOIHelper.SetCell(headerRow, i, dt.Columns[i].ColumnName);
                }

                //数据  
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow cellRow = workSheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        NPOIHelper.SetCell(cellRow, j, dt.Rows[i][j]);
                        if (dt.Rows[i][j].GetType().ToString() == "System.DateTime")
                        {
                            var cellStyle = NPOIHelper.CreateDataFormatCellStyle(workbook, null, "yyyy-MM-dd HH:mm:ss");
                            cellRow.GetCell(j).CellStyle = cellStyle;
                        }
                    }
                }

                if (action != null)
                {
                    action(workbook, workSheet);
                }

                NPOIHelper.SaveWorkbook(file, workbook);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Datable新增到Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file"></param>
        public static void AppendTableToExcel(DataTable dt, string file, Action<IWorkbook, ISheet> action)
        {
            try
            {
                IWorkbook workbook = null;

                string fileExt = Path.GetExtension(file).ToLower();
                bool IsNew = !File.Exists(file);
                if (!IsNew)
                {
                    workbook = NPOIHelper.GetWorkbook(file);
                }
                else
                {
                    workbook = NPOIHelper.CreateWorkbook(file);
                }

                ISheet workSheet = null;

                int num = 0;
                if (IsNew)
                {
                    workSheet = workbook.CreateSheet(string.IsNullOrEmpty(dt.TableName) ? "Sheet1" : dt.TableName);
                    //表头  
                    IRow headerRow = workSheet.CreateRow(0);
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        NPOIHelper.SetCell(headerRow, i, dt.Columns[i].ColumnName);
                    }
                }
                else
                {
                    workSheet = workbook.GetSheetAt(0);

                }

                num = workSheet.LastRowNum + 1;
                //数据  
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow cellRow = workSheet.CreateRow(i + num);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        NPOIHelper.SetCell(cellRow, j, dt.Rows[i][j]);
                        if (dt.Rows[i][j].GetType().ToString() == "System.DateTime")
                        {
                            var cellStyle = NPOIHelper.CreateDataFormatCellStyle(workbook, null, DateTimeStringFormat);
                            cellRow.GetCell(j).CellStyle = cellStyle;
                        }
                    }
                }

                if (action != null)
                {
                    action(workbook, workSheet);
                }

                NPOIHelper.SaveWorkbook(file, workbook, IsNew);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<T> ExcelToClass<T>(string file) where T : new()
        {
            DataTable dt = ExcelToTable(file);

            return ModelHandler<T>.FillModel(dt);
        }

        /// <summary>
        /// Datable导出成Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file">导出路径(包括文件名与扩展名)</param>
        public static void ClassToExcel<T>(List<T> list, string file, Action<IWorkbook, ISheet> action) where T : new()
        {
            DataTable dt = ModelHandler<T>.FillDataTable(list);

            TableToExcel(dt, file, action);
        }

        /// <summary>
        /// Datable新增到Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file"></param>
        public static void AppendClassToExcel<T>(List<T> list, string file, Action<IWorkbook, ISheet> action = null) where T : new()
        {
            DataTable dt = ModelHandler<T>.FillDataTable(list);
            AppendTableToExcel(dt, file, action);
        }

        public static string DateTimeStringFormat {get;set;}="yyyy-MM-dd HH:mm:ss";
    }
}
