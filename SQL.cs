using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Engine
{
    class SQL
    {
        private readonly string[] queryDelimiters = { "from", "FROM", "where", "WHERE", "select", "SELECT" };
        private readonly string[] fieldDelimiters = { ",", " " };
        private readonly string[] expressionDelimiters = { "AND", "and", "OR", "or" };
        private readonly string[] operatorDelimiters = { "=", ">", "<", ">=", "<=" };
        
        //Fields
        public string Query;
        public Data Data;

        //Constructors
        public SQL(string query, Data data)
        {
            Query = query;
            Data = data;
        }

        //Methods
        public string runQuery() //Execute decoding on query
        {
            string s = "";
            string[] splitedQuery = splitString(Query, queryDelimiters);
            string[] conditions = splitString(splitedQuery[1], expressionDelimiters);
            string[] fields = splitString(splitedQuery[2], fieldDelimiters);

            switch (splitedQuery[0].Trim())
            {
                case "Users":
                    if (splitedQuery[1].Contains("AND") || splitedQuery[1].Contains("and"))
                    {
                        s = andCondition(conditions, fields);
                    }
                    else if (splitedQuery[1].Contains("OR") || splitedQuery[1].Contains("or"))
                    {
                        s = orNoneCondition(conditions, fields);
                    }
                    else
                    {
                        s = orNoneCondition(conditions, fields);
                    }
                    break;
            }
            return s;
        }
        private string andCondition(string[] conditions, string[] fields) //Handle AND in the expression
        {
            string s = "";
            foreach (User u in Data.Users)
            {
                int answer = 0;
                answer = checkCondition(conditions, u);
                if (answer == 2)
                {
                    s += u.userValuesByFields(fields);
                }
            }
            return s;
        }
        private string orNoneCondition(string[] conditions, string[] fields) //Handle OR and NONE in the expression
        {
            string s = "";
            foreach (User u in Data.Users)
            {
                int answer = 0;
                answer = checkCondition(conditions, u);
                if (answer >= 1)
                {
                    s += u.userValuesByFields(fields);
                }
            }
            return s;
        }
        
        //Help Methods
        private string[] splitString(string str, string[] delimiters) //Split string by given dillmiters
        {
            string[] splited = str.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return splited;
        }
        private string[] splitConditions(string conditon) //Split condition string to field, value and operator
        {
            string[] splitedConditon = new string[3];
            splitedConditon[0] = conditon.Split(operatorDelimiters, StringSplitOptions.RemoveEmptyEntries).First().Trim();
            splitedConditon[1] = conditon.Split(operatorDelimiters, StringSplitOptions.RemoveEmptyEntries).Last().Trim();
            splitedConditon[2] = getOperator(conditon).Trim();
            return splitedConditon;
        }
        private int checkCondition(string[] conditions, User u) //Check if the condition is true
        {
            int answer = 0;
            foreach (string c in conditions)
            {
                string[] splitCondition = splitConditions(c);
                string value = getUserValue(u, splitCondition[0]);
                switch (splitCondition[2])
                {
                    case "=":
                        if (isEqual(value, splitCondition[1]))
                        {
                            answer += 1;
                        }
                        break;
                    case ">=":
                        if (isEqual(value, splitCondition[1]) || isBigger(value, splitCondition[1]))
                        {
                            answer += 1;
                        }
                        break;
                    case "<=":
                        if (isEqual(value, splitCondition[1]) || isSmaller(value, splitCondition[1]))
                        {
                            answer += 1;
                        }
                        break;
                    case ">":
                        if (isBigger(value, splitCondition[1]))
                        {
                            answer += 1;
                        }
                        break;
                    case "<":
                        if (isSmaller(value, splitCondition[1]))
                        {
                            answer += 1;
                        }
                        break;
                    default:
                        answer = 0;
                        break;
                }
            }
            return answer;
        }
        private string getOperator(string conditon) //Get the operator of the condition
        {
            switch (conditon)
            {
                case string a when a.Contains(">="):
                    return ">=";
                case string b when b.Contains("<="):
                    return "<=";
                case string c when c.Contains("="):
                    return "=";
                case string d when d.Contains("<"):
                    return "<";
                case string e when e.Contains(">"):
                    return ">";
            }
            return null;
        }
        private string getUserValue(User u, string left) //Get the value of the user that match the field
        {
            switch (left.Trim())
            {
                case "FullName":
                    {
                        return u.FullName;
                    }
                case "Email":
                    {
                        return u.Email;
                    }
                case "Age":
                    {
                        return u.Age.ToString();
                    }
            }
            return null;
        }
        private bool isEqual(string uVal, string qVal) //Check if two values are equal
        {
            if (uVal == qVal)
            {
                return true;
            }
            return false;
        }
        private bool isBigger(string uVal, string qVal) //Check if one value is bigger then the other
        {
            if (int.Parse(uVal) > int.Parse(qVal))
            {
                return true;
            }
            return false;
        }
        private bool isSmaller(string uVal, string qVal) //Check if one value is smaller then the other
        {
            if (int.Parse(uVal) < int.Parse(qVal))
            {
                return true;
            }
            return false; ;
        }
    }
}
