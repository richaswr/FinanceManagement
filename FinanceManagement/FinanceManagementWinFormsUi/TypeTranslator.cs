namespace FinanceManagementWinFormsUi
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using FinanceManagement.ETL.Models;

    public static class TypeTranslator<T>
    {
        public static T GetItemFromDataTableRow(DataRow sourceRow)
        {
            var classType = typeof(T);
            var newInstance = Activator.CreateInstance<T>();

            foreach (var property in classType.GetProperties())
            {
                property.SetValue(newInstance, sourceRow[property.Name]);
            }

            return newInstance;
        }

        public static T GetItemFromDataGridViewRow(DataGridViewRow sourceRow)
        {
            var classType = typeof(T);
            var newInstance = Activator.CreateInstance<T>();

            foreach (var property in classType.GetProperties())
            {
                property.SetValue(newInstance, sourceRow.Cells[property.Name]);
            }

            return newInstance;
        }
        public static DataTable GetDataTableFromSource(IList<T> sourceData)
        {
            var returnTable = new DataTable();
            if (!sourceData.Any())
            {
                return returnTable;
            }

            var classType = typeof(T);
            var properties = classType.GetProperties();

            foreach (var property in properties)
            {
                if (Attribute.IsDefined(property, typeof(DataTableIgnoreAttribute)))
                {
                    continue;
                }
                returnTable.Columns.Add(property.Name, property.PropertyType);
            }

            foreach (var T in sourceData)
            {
                var returnRow = returnTable.NewRow();
                foreach (var property in properties)
                {
                    if (Attribute.IsDefined(property, typeof(DataTableIgnoreAttribute)))
                    {
                        continue;
                    }
                    returnRow[property.Name] = property.GetValue(T);
                }

                returnTable.Rows.Add(returnRow);
            }
                
            return returnTable;
        }

        public static Collection<T> GetSourceFromDataTable(DataTable sourceData)
        {
            var returnData = new Collection<T>();
            var classType = typeof(T);

            foreach (DataRow sourceRow in sourceData.Rows)
            {
                var newInstance = Activator.CreateInstance<T>();

                foreach (DataColumn sourceColumn in sourceData.Columns)
                {
                    var matchingProperty = classType.GetProperty(sourceColumn.ColumnName);
                    matchingProperty.SetValue(newInstance, sourceRow[sourceColumn]);
                }

                returnData.Add(newInstance);
            }

            return returnData;
        }

        public static Collection<T> GetSourceFromDataGridView(DataGridView sourceData)
        {
            var returnData = new Collection<T>();
            var classType = typeof(T);

            foreach (DataGridViewRow row in sourceData.Rows)
            {
                var newInstance = Activator.CreateInstance<T>();
                foreach (var property in classType.GetProperties())
                {
                    property.SetValue(newInstance, row.Cells[property.Name].Value);
                }
                returnData.Add(newInstance);
            }

            return returnData;
        }

        public static void HideGridViewColumns(DataGridView source)
        {
            var classType = typeof(T);
            foreach (var property in classType.GetProperties())
            {
                if (!property.IsDefined(typeof(DataTableIgnoreAttribute), false)) continue;
                var dataGridViewColumn = source.Columns[property.Name];
                if (dataGridViewColumn != null)
                {
                    dataGridViewColumn.Visible = false;
                }
            }
        }
    }
}