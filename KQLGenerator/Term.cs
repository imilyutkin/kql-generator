using System;
using System.Collections.Generic;
using KQLGenerator.Contracts;
using KQLGenerator.Enums;

namespace KQLGenerator
{
    public class Term : IToken
    {
        private const String Equal = "=";
        private const String NotEqual = "<>";
        private const String Contains = ":";
        private const String NotContains = ":";

        public String ManagedProperty
        {
            get;
            set;
        }

        public String Value
        {
            get;
            set;
        }

        public ConcatOperator? Operator
        {
            get;
            set;
        }

        public Operation Operation
        {
            get;
            set;
        }

        protected const String TermTemplate = @"{0}{1}{2}";

        public Term(String managedProperty, String value, Operation operation, ConcatOperator? concatOperator = null)
        {
            ManagedProperty = managedProperty;
            Value = value;
            Operator = concatOperator;
            Operation = operation;
        }

        public string Build()
        {
            CheckManagedPropertyAndValue();
            string from = GetManagedPropertyWithOperator();
            return String.Format(TermTemplate, from, Value,
                Operator.HasValue ? " " + Operator.ToString().ToUpper() + " " : "");
        }

        private void CheckManagedPropertyAndValue()
        {
            if (String.IsNullOrEmpty(ManagedProperty))
            {
                throw new ArgumentException("Managed property is null or empty");
            }
            if (String.IsNullOrEmpty(Value))
            {
                throw new ArgumentException("Value is null or empty");
            }
        }

        private string GetManagedPropertyWithOperator()
        {
            string result = "";
            if (Operation == Operation.NotContains)
            {
                result += "-";
            }
            result += ManagedProperty;
            result += GetOperation();
            return result;
        }

        private string GetOperation()
        {
            switch (Operation)
            {
                case Operation.Contains:
                    return Contains;
                case Operation.Equal:
                    return Equal;
                case Operation.NotContains:
                    return NotContains;
                case Operation.NotEqual:
                    return NotEqual;
            }
            throw new Exception("Unknow operation type.");
        }
    }
}