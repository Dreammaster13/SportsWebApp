using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Reflection;

namespace SportsWebApp.Models
{
    public class SportData
    {
        static List<Dictionary<string, string>> AllSports = new List<Dictionary<string, string>>();
        static bool IsDataLoaded = false;

        public static List<Dictionary<string, string>> FindAll()
        {
            LoadData();

            //return a copy
            return new List<Dictionary<string, string>>(AllSports);
        }

        //return a list of all values contained in a given column without duplicates
        public static List<string> FindAll(string column)
        {
            LoadData();

            List<string> values = new List<string>();

            foreach (Dictionary<string, string> sport in AllSports)
            {
                string aValue = sport[column];
                if (!values.Contains(aValue))
                {
                    values.Add(aValue);
                }
            }

            //sort results alphabetically
            values.Sort();
            return values;
        }

        //search all columns for the given term
        public static List<Dictionary<string, string>> FindByValue(string value)
        {
            //load data, if not already loaded
            LoadData();

            List<Dictionary<string, string>> sports = new List<Dictionary<string, string>>();

            foreach (Dictionary<string, string> row in AllSports)
            {
                foreach (string key in row.Keys)
                {
                    string aValue = row[key];
                    if (aValue.ToLower().Contains(value.ToLower()))
                    {
                        sports.Add(row);
                        break;
                    }
                }
            }

            return sports;
        }

        /**
         * Returns results of search the sports data by key/value, using inclusion of the search term.
         
         * For example, searching for team "Patriots" will include results with "New England Patriots".
         */
        public static List<Dictionary<string, string>> FindByColumnAndValue(string column, string value)
        {
            //load data, if not already loaded
            LoadData();

            List<Dictionary<string, string>> sports = new List<Dictionary<string, string>>();

            foreach (Dictionary<string, string> row in AllSports)
            {
                string aValue = row[column];

                if (aValue.ToLower().Contains(value.ToLower()))
                {
                    sports.Add(row);
                }
            }

            return sports;
        }

        //load and parse data from sports_data.csv
        private static void LoadData()
        {
            if (IsDataLoaded)
            {
                return;
            }

            List<string[]> rows = new List<string[]>();

            using (StreamReader reader = File.OpenText("Models/sport_data.csv"))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] rowArray = CSVRowToStringArray(line);
                    if (rowArray.Length > 0)
                    {
                        rows.Add(rowArray);
                    }
                }
            }

            string[] headers = rows[0];
            rows.Remove(headers);

            //parse each row array intoa more friendly Dictionary
            //foreach (string[] row in rows)
            //{
            //    Dictionary<string, string> rowDict = new Dictionary<string, string>();

            //    for (int i = 0; i < headers.Length; i++)
            //    {
            //        rowDict.Add(headers[i], row[i]);
            //    }
            //    AllSports.Add(rowDict);
            //}

            IsDataLoaded = true;
        }

        /*
         * Parse a single line of a CSV file into a string array
         */
        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            // Loop through the row string one char at a time
            foreach (char c in row.ToCharArray())
            {
                if ((c == fieldSeparator && !isBetweenQuotes))
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    if (c == stringSeparator)
                    {
                        isBetweenQuotes = !isBetweenQuotes;
                    }
                    else
                    {
                        valueBuilder.Append(c);
                    }
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }

    }
}
