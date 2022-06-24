using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class Query
    {
        private string name;
        private string id;
        private string text;
        private string condition;
        private string _value;
        private string oprator;
        private string nextoprator;
        private string _item;

        private List<string> table;
        private List<string> field;
        private List<string> fieldTransName;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int FieldsCount
        {
            get
            {
                return field.Count;
            }
        }

        public string Condition
        {
            get
            {
                return condition;
            }
            set
            {
                condition = value;
            }
        }

        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
               _value = value;
            }
        }

        public string Oprator
        {
            get
            {
                return oprator;
            }
            set
            {
                oprator = value;
            }
        }

        public string NextOprator
        {
            get
            {
                return nextoprator;
            }
            set
            {
                nextoprator = value;
            }
        }

        public string Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
            }
        }




        public Query()
        {
            text = "SELECT * FROM ";
            name = "";
            id = "";
            condition = "";
            _value = "";
            oprator = "";
            nextoprator = "";
            table = new List<string>();
            field = new List<string>();
            fieldTransName = new List<string>();
        }

        public void AddTable(string TableName)
        {
            table.Add(TableName);        
        }

        public void RemoveTable(string TableName)
        {
            table.Remove(TableName);
        }

        public void AddField(string FiledName)
        {
            field.Add(FiledName); 
        }

        public void AddFieldTransName(string FiledName)
        {
            fieldTransName.Add(FiledName);
        }

        public void RemoveField(string FiledName)
        {
            field.Remove(FiledName);
        }

        public void RemoveFieldTransName(string FiledName)
        {
            fieldTransName.Remove(FiledName);
        }

        public string GetTableName(int Index)
        {
            return table[Index];
        }

        public string GetFieldName(int Index)
        {
            return field[Index];
        }

        public string GetFieldTransName(int Index)
        {
            return fieldTransName[Index];
        }

        
    }
}
