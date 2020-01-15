using System;
using System.Collections.Generic;
using System.Text;

namespace Cabin_App
{
    public class clsItem
    {
        public clsItem(Boolean chkDone, string name, string size, long count, string grade)
        {
            ChkDone = chkDone;
            Name = name;
            Size = size;
            Count = count;
            Grade = grade;
        }

        public Boolean ChkDone { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public long Count { get; set; }
        public string Grade { get; set; }
        //{
        //    get
        //    {
        //        return 4;
        //    }
        //    set
        //    {
        //        Count = 4;
        //    }
        //}



        public override string ToString()
        {
            return Name;

        }
    }
}