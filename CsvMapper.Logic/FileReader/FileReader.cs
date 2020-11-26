using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CsvMapper.Logic.Attributes;
using CsvMapper.Logic.Models;

namespace Chinook.Logic
{
    public class FileReader
    {
        private static readonly Type _intType = typeof(int);
        private static readonly Type _doubleType = typeof(double);
        private static readonly Type _stringType = typeof(string);

        /// <summary>
        /// Reads a File from the working directory from the executable and parses the data into an IEnumerable
        /// </summary>
        /// <typeparam name="T">Type of data and filename</typeparam>
        /// <returns>List of read data</returns>
        /// <exception cref="SyntaxErrorException">When DataClassAttribute is not applied to T</exception>
        /// <exception cref="Exception">When an unsupported property type is used</exception>
        public static IEnumerable<T> Read<T>() where T : ModelObject, new()
        {
            var result = new List<T>();

            var type = typeof(T);
            var attr = type.GetCustomAttribute<DataClassAttribute>();
            //checking if DataClassAttribute is applied (is basically redundant)
            if (attr == null)
            {
                throw new SyntaxErrorException(type.FullName + " has no " + nameof(DataClassAttribute));
            }

            var nullLabel = attr.NullLabel;
            var fileName = "Data/" + type.Name + attr.FileExtension;
            var data = File.ReadAllLines(fileName, Encoding.UTF8);
            var props = type.GetProperties().ToDictionary(info => info.Name.ToLower(), info => info);
            var header = data[0].Split(attr.Seperator);

            // for each line in csv
            foreach (var line in data.Skip(1))
            {
                var elem = new T();
                var values = RemoveNestedSeperators(line, attr.Seperator).Split(attr.Seperator);
                //for each property whose name is listed in the header of the csv file (not case-sensitive)
                for (int i = 0; i < header.Length; i++)
                {
                    var prop = props[header[i].ToLower()];
                    var propType = prop.PropertyType;

                    if (propType == _intType)
                    {
                        if (values[i] == nullLabel)
                            prop.SetValue(elem, -1);
                        prop.SetValue(elem, int.Parse(values[i]));
                    }
                    else if (propType == _doubleType)
                    {
                        if (values[i] == nullLabel)
                            prop.SetValue(elem, double.NaN);
                        prop.SetValue(elem, double.Parse(values[i]));
                    }
                    else if (propType == _stringType)
                    {
                        if (values[i] == nullLabel)
                            prop.SetValue(elem, null);
                        prop.SetValue(elem, values[i]);
                    }
                    else
                    {
                        throw new Exception($"Unsupported datatype {prop.MemberType} of prop {prop.Name} in {type.FullName}");
                    }
                }

                result.Add(elem);
            }

            return result;
        }

        /// <summary>
        /// avoids crash, when there is a seperator nested inside a string
        /// </summary>
        /// <param name="line">a line from a csv file</param>
        /// <param name="seperator">seperator of the csv file</param>
        /// <returns>the seperated, fixed line</returns>
        private static string RemoveNestedSeperators(string line, char seperator)
        {
            var res = "";
            bool inside = false;
            char other = seperator == ';' ? ',' : ';';

            for (int i = 0; i < line.Length; i++)
            {
                char curr = line[i];
                if (line[i] == '"')
                    inside = !inside;
                if (inside && curr == seperator)
                    curr = other;


                if (curr != '"')
                    res += curr;
            }

            return res;
        }
    }
}