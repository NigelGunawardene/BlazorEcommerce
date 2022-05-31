using BlazorEcommerce.Shared.Entities;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace BlazorEcommerce.DataAccess.Seed.Helpers;
public class ExcelReader
{

    public static IList ReadExcelAndOutputList<T>(string filePath, string type)
    {
        string blazorEcommerceSharedDllFilePath = "E:/Projects/CyberMuffin/Repos/BlazorEcommerce/Server/bin/Debug/net6.0/BlazorEcommerce.Shared.dll";
        DataTable dt = ReadExcelAndConvertToDatatable(filePath);
        //var assembly = Assembly.GetExecutingAssembly();
        var assembly = Assembly.LoadFile(blazorEcommerceSharedDllFilePath);
        Type typeOfList = assembly.GetType(type);
        var list = ConvertDataTableToList(dt, typeOfList); //var list = ConvertDataTableToList<T>(dt, typeOfList);
        //var list = ConvertDataTable<Product>(dt);
        return list;
    }

    private static DataTable ReadExcelAndConvertToDatatable(string filePath)
    {
        using (var excelPackage = new ExcelPackage(new FileInfo(filePath))) //filePath here
        {
            var workSheet = excelPackage.Workbook.Worksheets.First();
            DataTable dataTable = new DataTable();

            foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
            {
                dataTable.Columns.Add(firstRowCell.Text);
            }

            for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                var newRow = dataTable.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }
    }
    private static IList ConvertDataTableToList(DataTable dt, Type typeOfList) //private static IList ConvertDataTableToList<T>(DataTable dt, Type typeOfList)
    {
        switch (typeOfList.Name)
        {
            case "Product":
                var data = new List<Product>();
                foreach (DataRow row in dt.Rows)
                {
                    Product item = GetItem<Product>(row);
                    data.Add(item);
                }
                return data;
                break;
            default:
                return null;
        }
    }

    private static T GetItem<T>(DataRow datarow)
    {
        Type temp = typeof(T);
        T obj = Activator.CreateInstance<T>();

        foreach (DataColumn column in datarow.Table.Columns)
        {
            foreach (PropertyInfo pro in temp.GetProperties())
            {
                if (pro.Name == column.ColumnName)
                    pro.SetValue(obj, Convert.ChangeType(datarow[column.ColumnName], pro.PropertyType), null);
                else
                    continue;
            }
        }
        return obj;
    }

    private static IList? CreateList(Type t)
    {
        var listType = typeof(List<>);
        var constructedListType = listType.MakeGenericType(t);
        var instance = (IList)Activator.CreateInstance(constructedListType);
        return instance;
    }
}
