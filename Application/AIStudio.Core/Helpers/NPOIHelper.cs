using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Core
{
    public static class NPOIHelper
    {
        public static IWorkbook GetWorkbook(string filePath)
        {
            IWorkbook hssfworkbook;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                string[] strs = filePath.Split('.');

                try
                {
                    hssfworkbook = new XSSFWorkbook(fileStream);
                }
                catch (Exception ex)
                {
                    hssfworkbook = new HSSFWorkbook(fileStream);
                    Console.WriteLine(ex.Message);
                }

                fileStream.Close();
                fileStream.Dispose();
            }

            if (hssfworkbook.NumberOfSheets == 0)
            {
                throw new Exception("打开的模板文件没有内容！");
            }

            return hssfworkbook;
        }

        public static IWorkbook CreateWorkbook(string filePath)
        {
            IWorkbook workbook;
            string fileExt = Path.GetExtension(filePath).ToLower();
            if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(); }
            else if (fileExt == ".xls") { workbook = new HSSFWorkbook(); } else { workbook = null; }
            if (workbook == null) { throw new Exception("导出文件的后缀不对！"); }

            ResetUserColorIndex();
            return workbook;
        }

        public static void SaveWorkbook(string filePath, IWorkbook workbook)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                //转为字节数组  
                MemoryStream stream = new MemoryStream();
                workbook.Write(stream);
                var buf = stream.ToArray();

                //保存为Excel文件  
                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.Write(ms);
                    workbook.Close();
                    byte[] data = ms.ToArray();
                    fileStream.Write(data, 0, data.Length);
                    fileStream.Flush();
                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
        }

        public static void SaveWorkbook(string filePath, IWorkbook workbook, bool IsNew)
        {
            using (FileStream fout = new FileStream(filePath, IsNew ? FileMode.Create : FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                fout.Flush();
                workbook.Write(fout);//写入文件
                workbook.Close();
                fout.Close();
            }
        }

        /// <summary>
        /// 设置单元格
        /// </summary>
        public static void SetCell(IRow dataRow, int colIndex, object value, ICellStyle cellStyle = null, Type type = null)
        {
            ICell newCell = dataRow.CreateCell(colIndex);
            if (cellStyle != null)
            {
                newCell.CellStyle = cellStyle;//格式化显示
            }
            string valueStr = value == null ? string.Empty : value.ToString();

            if (type == null && value != null)//如果没有设置格式，那么为自动格式，大部分应该走自动格式
            {
                type = value.GetType();
            }
            if (type == null)
            {
                return;
            }
            switch (type.ToString())
            {
                case "System.String"://字符串类型
                    newCell.SetCellValue(valueStr);
                    break;
                case "System.DateTime"://日期类型
                    DateTime dateV;
                    DateTime.TryParse(valueStr, out dateV);
                    newCell.SetCellValue(dateV);
                    break;
                case "System.Boolean"://布尔型
                    bool boolV = false;
                    bool.TryParse(valueStr, out boolV);
                    newCell.SetCellValue(boolV);
                    break;
                case "System.Int16"://整型
                case "System.Int32":
                case "System.Int64":
                case "System.Byte":
                    int intV = 0;
                    int.TryParse(valueStr, out intV);
                    newCell.SetCellValue(intV);
                    break;
                case "System.Decimal"://浮点型
                case "System.Double":
                    double doubV = 0;
                    double.TryParse(valueStr, out doubV);
                    newCell.SetCellValue(doubV);
                    break;
                case "System.DBNull"://空值处理
                    newCell.SetCellValue("");
                    break;
                default:
                    newCell.SetCellValue("");
                    break;
            }

        }

        /// <summary>
        /// 批注
        /// </summary>
        /// <param name="workSheet"></param>
        /// <param name="content"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public static IComment CreateComment(ISheet workSheet, string content, string author)
        {
            var patr = workSheet.CreateDrawingPatriarch();
            IComment comment;
            if (workSheet is XSSFSheet)
            {
                comment = patr.CreateCellComment(new XSSFClientAnchor(0, 0, 0, 0, 1, 2, 4, 8));
                comment.String = new XSSFRichTextString(content);
            }
            else
            {
                comment = patr.CreateCellComment(new HSSFClientAnchor(0, 0, 0, 0, 1, 2, 4, 8));
                comment.String = new HSSFRichTextString(content);
            }
            comment.Author = author;
            return comment;
        }

        /// <summary>
        /// 冻结
        /// </summary>
        public static void SetFreezePane(ISheet workSheet, int colSplit, int rowSplit, int leftmostColumn, int topRow)
        {
            workSheet.CreateFreezePane(colSplit, rowSplit, leftmostColumn, topRow);
        }

        /// <summary>
        /// 行宽
        /// </summary>
        /// <param name="workSheet"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="width"></param>
        public static void SetColumnWidth(ISheet workSheet, int start, int end, int width)
        {
            for (int i = start; i <= end; i++)
            {
                workSheet.SetColumnWidth(i, width * 256);
            }
        }

        public static void SetAutoColumnWidth(ISheet workSheet, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                workSheet.AutoSizeColumn(i);
            }
        }

        public static void MergedCell(ISheet workSheet, int firstRow, int lastRow, int firstCol, int lastCol)
        {
            CellRangeAddress region = new CellRangeAddress(firstRow, lastRow, firstCol, lastCol);
            workSheet.AddMergedRegion(region);
        }

        /// <summary>
        /// 字体
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="cellStyle"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static ICellStyle CreateFontCellStyle(IWorkbook workbook, ICellStyle cellStyle = null, short? color = NPOI.HSSF.Util.HSSFColor.Red.Index, int? fontsize = null, string fontname = null, bool? boldweight = null)
        {
            if (cellStyle == null)
            {
                cellStyle = workbook.CreateCellStyle();
            }
            //创建字体
            var font = workbook.CreateFont();
            //给字体设置颜色
            if (color != null)
            {
                font.Color = color.Value;
            }
            if (fontsize != null)
            {
                font.FontHeightInPoints = 9;
            }
            if (!string.IsNullOrEmpty(fontname))
            {
                font.FontName = fontname; // "宋体";
            }
            if (boldweight != null)
            {
                font.IsBold = true;
            }

            //给样式添加字体
            cellStyle.SetFont(font);

            return cellStyle;
        }

        /// <summary>
        /// 自定义颜色索引，这是一个坑，尽量避免使用自定义颜色
        /// </summary>

        public static short UserColorIndex { get; private set; }

        /// <summary>
        /// HSSF自定义颜色要占用系统索引，每个自定义颜色不能占用同一个，所以在这里进行规划使用
        /// </summary>
        public static void ResetUserColorIndex()
        {
            UserColorIndex = NPOI.HSSF.Util.HSSFColor.Black.Index;
        }

        /// <summary>
        /// 在设置自定义颜色之前，设置占用的系统颜色索引
        /// </summary>
        /// <param name="index"></param>
        public static void SetUserColorIndex(short index)
        {
            UserColorIndex = index;
        }

        /// <summary>
        /// 注意不要超过系统颜色的自定义颜色,也要避免占用你需要的系统颜色
        /// </summary>
        /// <param name="index"></param>
        public static void AutoSetUserColorIndex()
        {
            UserColorIndex++;
        }

        /// <summary>
        /// 字体
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="cellStyle"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static ICellStyle CreateFontColorCellStyle(IWorkbook workbook, ICellStyle cellStyle = null, System.Drawing.Color? color = null, int? fontsize = null, string fontname = null, bool? boldweight = null)
        {
            if (cellStyle == null)
            {
                cellStyle = workbook.CreateCellStyle();
            }
            //创建字体
            var font = workbook.CreateFont();
            //给字体设置颜色
            if (color != null)
            {
                //font.Color = color.Value;
                byte[] colors = new byte[3];
                colors[0] = color.Value.R;
                colors[1] = color.Value.G;
                colors[2] = color.Value.B;
                if (workbook is HSSFWorkbook)
                {
                    var palette = (workbook as HSSFWorkbook).GetCustomPalette();
                    palette.SetColorAtIndex(UserColorIndex, colors[0], colors[1], colors[2]);
                    //将自定义的颜色引入进来 
                    font.Color = UserColorIndex;
                    AutoSetUserColorIndex();//自动定位下一个索引
                }
                else
                {
                    XSSFCellStyle rowsStyleColor = (XSSFCellStyle)workbook.CreateCellStyle();
                    XSSFColor xssfColor = new XSSFColor();
                    //根据自己需要设置RGB
                    byte[] colorRgb = { colors[0], colors[1], colors[2] };
                    xssfColor.SetRgb(colorRgb);
                    ((XSSFFont)font).SetColor(xssfColor);
                }
            }
            if (fontsize != null)
            {
                font.FontHeightInPoints = 9;
            }
            if (!string.IsNullOrEmpty(fontname))
            {
                font.FontName = fontname; // "宋体";
            }
            if (boldweight != null)
            {
                font.IsBold = true;
            }

            //给样式添加字体
            cellStyle.SetFont(font);

            return cellStyle;
        }

        /// <summary>
        /// 格式
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="cellStyle"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ICellStyle CreateDataFormatCellStyle(IWorkbook workbook, ICellStyle cellStyle = null, string format = "@")
        {
            if (cellStyle == null)
            {
                cellStyle = workbook.CreateCellStyle();
            }
            IDataFormat formatNum = workbook.CreateDataFormat();
            cellStyle.DataFormat = workbook.CreateDataFormat().GetFormat(format);//

            return cellStyle;
        }

        /// <summary>
        /// 边框
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="cellStyle"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ICellStyle CreateBorderCellStyle(IWorkbook workbook, ICellStyle cellStyle = null, short? color = null)
        {
            if (cellStyle == null)
            {
                cellStyle = workbook.CreateCellStyle();
            }
            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;
            cellStyle.BorderTop = BorderStyle.Thin;

            if (color != null)
            {
                cellStyle.TopBorderColor = color.Value;
                cellStyle.BottomBorderColor = color.Value;
                cellStyle.LeftBorderColor = color.Value;
                cellStyle.RightBorderColor = color.Value;
            }
            return cellStyle;
        }

        /// <summary>
        /// 边框
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="cellStyle"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ICellStyle CreateBorderColorCellStyle(IWorkbook workbook, ICellStyle cellStyle = null, System.Drawing.Color? color = null)
        {
            if (cellStyle == null)
            {
                cellStyle = workbook.CreateCellStyle();
            }
            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;
            cellStyle.BorderTop = BorderStyle.Thin;

            if (color != null)
            {
                //font.Color = color.Value;
                byte[] colors = new byte[3];
                colors[0] = color.Value.R;
                colors[1] = color.Value.G;
                colors[2] = color.Value.B;
                if (workbook is HSSFWorkbook)
                {
                    var palette = (workbook as HSSFWorkbook).GetCustomPalette();
                    palette.SetColorAtIndex(UserColorIndex, colors[0], colors[1], colors[2]);
                    //将自定义的颜色引入进来 
                    cellStyle.TopBorderColor = UserColorIndex;
                    cellStyle.BottomBorderColor = UserColorIndex;
                    cellStyle.LeftBorderColor = UserColorIndex;
                    cellStyle.RightBorderColor = UserColorIndex;
                    AutoSetUserColorIndex();//自动定位下一个索引
                }
                else
                {
                    XSSFCellStyle rowsStyleColor = (XSSFCellStyle)workbook.CreateCellStyle();
                    XSSFColor xssfColor = new XSSFColor();
                    //根据自己需要设置RGB
                    byte[] colorRgb = { colors[0], colors[1], colors[2] };
                    xssfColor.SetRgb(colorRgb);
                    ((XSSFCellStyle)cellStyle).SetTopBorderColor(xssfColor);
                    ((XSSFCellStyle)cellStyle).SetBottomBorderColor(xssfColor);
                    ((XSSFCellStyle)cellStyle).SetLeftBorderColor(xssfColor);
                    ((XSSFCellStyle)cellStyle).SetRightBorderColor(xssfColor);
                }
            }

            return cellStyle;
        }

        /// <summary>
        /// 对齐
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="cellStyle"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ICellStyle CreateAlignCellStyle(IWorkbook workbook, ICellStyle cellStyle = null, HorizontalAlignment align = NPOI.SS.UserModel.HorizontalAlignment.Right)
        {
            if (cellStyle == null)
            {
                cellStyle = workbook.CreateCellStyle();
            }
            cellStyle.Alignment = align;

            return cellStyle;
        }

        /// <summary>
        /// 自动行号
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="cellStyle"></param>
        /// <param name="align"></param>
        /// <returns></returns>
        public static ICellStyle CreateWrapCellStyle(IWorkbook workbook, ICellStyle cellStyle = null, bool wrapText = true, VerticalAlignment align = NPOI.SS.UserModel.VerticalAlignment.Center)
        {
            if (cellStyle == null)
            {
                cellStyle = workbook.CreateCellStyle();
            }
            cellStyle.WrapText = wrapText;
            cellStyle.VerticalAlignment = align;

            return cellStyle;
        }
        /// <summary>
        /// 背景填充
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="cellStyle"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ICellStyle CreateFillColorCellStyle(IWorkbook workbook, ICellStyle cellStyle, short color)
        {
            if (cellStyle == null)
            {
                cellStyle = workbook.CreateCellStyle();
            }

            cellStyle.FillForegroundColor = color;
            cellStyle.FillPattern = FillPattern.SolidForeground;

            return cellStyle;
        }

        /// <summary>
        /// 背景填充
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="cellStyle"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ICellStyle CreateFillColorCellStyle(IWorkbook workbook, ICellStyle cellStyle, System.Drawing.Color? color)
        {
            if (cellStyle == null)
            {
                cellStyle = workbook.CreateCellStyle();
            }

            //font.Color = color.Value;
            byte[] colors = new byte[3];
            colors[0] = color.Value.R;
            colors[1] = color.Value.G;
            colors[2] = color.Value.B;
            if (workbook is HSSFWorkbook)
            {
                var palette = (workbook as HSSFWorkbook).GetCustomPalette();
                palette.SetColorAtIndex(UserColorIndex, colors[0], colors[1], colors[2]);
                //将自定义的颜色引入进来 
                cellStyle.FillForegroundColor = UserColorIndex;
                AutoSetUserColorIndex();//自动定位下一个索引
            }
            else
            {
                XSSFCellStyle rowsStyleColor = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFColor xssfColor = new XSSFColor();
                //根据自己需要设置RGB
                byte[] colorRgb = { colors[0], colors[1], colors[2] };
                xssfColor.SetRgb(colorRgb);
                ((XSSFCellStyle)cellStyle).SetFillBackgroundColor(xssfColor);
            }

            cellStyle.FillPattern = FillPattern.SolidForeground;

            return cellStyle;
        }

        public static void AddIntRangeValidationData(ISheet workSheet, int start, int end, int min, int max, string title = "错误", string message = "输入超出范围", bool? allowEmpty = null)
        {
            IDataValidationHelper helper;
            if (workSheet is HSSFSheet)
            {
                helper = new HSSFDataValidationHelper((HSSFSheet)workSheet);//获得一个数据验证Helper                 
            }
            else
            {
                helper = new XSSFDataValidationHelper((XSSFSheet)workSheet);//获得一个数据验证Helper  
            }
            var constraint = helper.CreateNumericConstraint(ValidationType.INTEGER, OperatorType.BETWEEN, min.ToString(), max.ToString());
            AddValidationData(workSheet, start, end, helper, constraint, title, message, allowEmpty);
        }

        public static void AddListValidationData(ISheet workSheet, int start, int end, string[] listOfValues, string title = "错误", string message = "请按右侧下拉箭头选择", bool? allowEmpty = null)
        {
            IDataValidationHelper helper;
            if (workSheet is HSSFSheet)
            {
                helper = new HSSFDataValidationHelper((HSSFSheet)workSheet);//获得一个数据验证Helper  
            }
            else
            {
                helper = new XSSFDataValidationHelper((XSSFSheet)workSheet);//获得一个数据验证Helper  
            }
            var constraint = helper.CreateExplicitListConstraint(listOfValues);
            AddValidationData(workSheet, start, end, helper, constraint, title, message, allowEmpty);
        }

        private static void AddValidationData(ISheet workSheet, int start, int end, IDataValidationHelper helper, IDataValidationConstraint constraint, string title, string message, bool? allowEmpty)
        {
            CellRangeAddressList cellRegions = new CellRangeAddressList(1, 65535, start, end);
            IDataValidation validation = helper.CreateValidation(constraint, cellRegions);
            validation.CreateErrorBox(title, message);
            validation.ShowErrorBox = true;
            if (allowEmpty != null)
            {
                validation.EmptyCellAllowed = allowEmpty.Value;
            }
            workSheet.AddValidationData(validation);
        }

        public static void LoadFromCSVText(ISheet workSheet, string csvText)
        {
            string[] datas = csvText.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (datas.Length > 1)
            {
                for (int i = 0; i < datas.Length; i++)
                {
                    IRow cellRow = workSheet.CreateRow(i);
                    string[] celldatas = datas[i].Split(',');
                    for (int j = 0; j < celldatas.Length; j++)
                    {
                        SetCell(cellRow, j, celldatas[j]);
                    }
                }
            }
        }

        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:  
                    return null;
                case CellType.Boolean: //BOOLEAN:  
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:  
                    return cell.NumericCellValue;
                case CellType.String: //STRING:  
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:  
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:  
                default:
                    return "=" + cell.CellFormula;
            }
        }
    }
}
