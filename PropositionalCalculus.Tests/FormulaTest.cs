﻿namespace PropositionalCalculus.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PropositionalCalculus;
    using PropositionalCalculus.BinaryOperators;
    using PropositionalCalculus.UnaryOperators;
    using Xunit;

    public class FormulaTest
    {
        [Fact]
        public void TestEqualsSelf()
        {
            var a = new Formula<string>();
            var b = new Formula<string>();
            Assert.Equal(a, a);
            Assert.Equal(a, b);
        }

        [Fact]
        public void TestHashCode()
        {
            var a = new Formula<string>();
            var b = new Formula<string>();
            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }

        [Fact]
        public void TestToString()
        {
            var a = new Formula<string>();

            Assert.Equal(string.Empty, a.ToString());
        }

        [Fact]
        public void TestNegation()
        {
            var a = !new Formula<string>();

            Assert.Equal("!", a.ToString());

            a = !a;

            Assert.Equal("!!", a.ToString());
        }

        [Fact]
        public void TestWithOperator()
        {
            var a = new Formula<string>();
            a = a.WithOperators(BinaryOperator.AND, new List<UnaryOperator>() { UnaryOperator.NOT });

            Assert.Equal("& !", a.ToString());
        }

        [Fact]
        public void TestAnd()
        {
            var a = new Expression<string>("a");
            var b = new Expression<string>("b");
            var c = new Expression<string>("c");

            var result = a & b & c;
            Assert.Equal("a & b & c", result.ToString());
        }

        [Fact]
        public void TestOr()
        {
            var a = new Expression<string>("a");
            var b = new Expression<string>("b");
            var c = new Expression<string>("c");

            var result = a | b | c;
            Assert.Equal("a | b | c", result.ToString());
        }

        [Fact]
        public void TestXor()
        {
            var a = new Expression<string>("a");
            var b = new Expression<string>("b");
            var c = new Expression<string>("c");

            var result = a ^ b ^ c;
            Assert.Equal("a ^ b ^ c", result.ToString());
        }

        [Fact]
        public void TestMixedOperators()
        {
            var a = new Expression<string>("a");
            var b = new Expression<string>("b");
            var c = new Expression<string>("c");
            var d = new Expression<string>("d");

            var result = a & b | c ^ d;
            Assert.Equal("a & b | c ^ d", result.ToString());
            result = a | b & c ^ d;
            Assert.Equal("a | b & c ^ d", result.ToString());
            result = a | b ^ c & d;
            Assert.Equal("a | b ^ c & d", result.ToString());
            result = a ^ b | c & d;
            Assert.Equal("a ^ b | c & d", result.ToString());
            result = a & b ^ c | d;
            Assert.Equal("a & b ^ c | d", result.ToString());
            result = a ^ b & c | d;
            Assert.Equal("a ^ b & c | d", result.ToString());
        }

        [Fact]
        public void TestBraces()
        {
            var a = new Expression<string>("a");
            var b = new Expression<string>("b");
            var c = new Expression<string>("c");
            var d = new Expression<string>("d");

            var result = (a & b) | c ^ d;
            Assert.Equal("a & b | c ^ d", result.ToString());
            result = (a | b) & c ^ d;
            Assert.Equal("(a | b) & c ^ d", result.ToString());
            result = (a | b) ^ c & d;
            Assert.Equal("(a | b) ^ c & d", result.ToString());
            result = (a ^ b) | c & d;
            Assert.Equal("a ^ b | c & d", result.ToString());
            result = (a & b) ^ c | d;
            Assert.Equal("a & b ^ c | d", result.ToString());
            result = (a ^ b) & c | d;
            Assert.Equal("(a ^ b) & c | d", result.ToString());

            result = a & (b | c) ^ d;
            Assert.Equal("a & (b | c) ^ d", result.ToString());
            result = a | (b & c) ^ d;
            Assert.Equal("a | b & c ^ d", result.ToString());
            result = a | (b ^ c) & d;
            Assert.Equal("a | (b ^ c) & d", result.ToString());
            result = a ^ (b | c) & d;
            Assert.Equal("a ^ (b | c) & d", result.ToString());
            result = a & (b ^ c) | d;
            Assert.Equal("a & (b ^ c) | d", result.ToString());
            result = a ^ (b & c) | d;
            Assert.Equal("a ^ b & c | d", result.ToString());

            result = a & b | (c ^ d);
            Assert.Equal("a & b | c ^ d", result.ToString());
            result = a | b & (c ^ d);
            Assert.Equal("a | b & (c ^ d)", result.ToString());
            result = a | b ^ (c & d);
            Assert.Equal("a | b ^ c & d", result.ToString());
            result = a ^ b | (c & d);
            Assert.Equal("a ^ b | c & d", result.ToString());
            result = a & b ^ (c | d);
            Assert.Equal("a & b ^ (c | d)", result.ToString());
            result = a ^ b & (c | d);
            Assert.Equal("a ^ b & (c | d)", result.ToString());
        }
    }
}
