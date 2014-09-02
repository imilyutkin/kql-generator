using System;
using KQLGenerator.Contracts;
using KQLGenerator.Enums;
using KQLGenerator.Exceptions;

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

        public Operation Operation
        {
            get;
            set;
        }

        public ConcatOperator? ConcatOperator
        {
            get;
            set;
        }

        protected const String TermTemplate = @"{0}{1}{2}";

        public Term(String managedProperty, String value, Operation operation, ConcatOperator? concatOperator = null)
        {
            ManagedProperty = managedProperty;
            Value = value;
            ConcatOperator = concatOperator;
            Operation = operation;
        }

        public string Build()
        {
            CheckManagedPropertyAndValue();
            string from = GetManagedPropertyWithOperator();
            return String.Format(TermTemplate, from, Value,
                ConcatOperator.HasValue ? " " + ConcatOperator.ToString().ToUpper() : "");
        }

        private void CheckManagedPropertyAndValue()
        {
            if (String.IsNullOrEmpty(ManagedProperty))
            {
                throw new ManagedPropertyNullOrEmptyException("Managed property is null or empty");
            }
            if (String.IsNullOrEmpty(Value))
            {
                throw new ValueNullOrEmptyException("Value is null or empty");
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