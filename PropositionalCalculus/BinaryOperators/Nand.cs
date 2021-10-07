﻿namespace PropositionalCalculus.BinaryOperators
{
    using System.Collections.Generic;

    using UnaryOperators;

    public class Nand : BinaryOperator
    {
        public override int CompareTo(BinaryOperator other)
        {
            switch (other)
            {
                case And:
                case Nand:
                    return 0;
                case Or:
                case Nor:
                    return -1;
                case Xor:
                case Nxor:
                    return -1;
                default:
                    return -other.CompareTo(this);
            }
        }

        public override ExpressionOrFormula<T> Normalize<T>(ExpressionOrFormula<T> a, ExpressionOrFormula<T> b)
        {
            return new Formula<T>(a.BinaryOperator, new List<UnaryOperator>() { UnaryOperator.NOT }, a.WithOperators(null, a.UnaryOperators), b.WithOperators(AND, b.UnaryOperators));
        }

        public override bool Resolve(bool a, bool b)
        {
            return !(a && b);
        }

        public override string ToString()
        {
            return "!&";
        }
    }
}
