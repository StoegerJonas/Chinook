using System;

namespace Chinook.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DataClassAttribute:Attribute
    {
        public string NullLabel { get; set; } = "NULL";
        public char Seperator { get; set; } = ';';
        public string FileExtension { get; set; }= ".csv";
    }
}