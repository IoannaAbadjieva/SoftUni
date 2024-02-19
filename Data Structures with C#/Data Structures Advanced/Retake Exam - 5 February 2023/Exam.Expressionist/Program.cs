using System;

namespace Exam.Expressionist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var expressionist = new Expressionist();

            expressionist.AddExpression(new Expression("A", "-", ExpressionType.Operator, null, null));
            expressionist.AddExpression(new Expression("B", "+", ExpressionType.Operator, null, null), "A");
            expressionist.AddExpression(new Expression("C", "-", ExpressionType.Operator, null, null), "A");
            expressionist.AddExpression(new Expression("D", "+", ExpressionType.Operator, null, null), "B");
            expressionist.AddExpression(new Expression("E", "4", ExpressionType.Value, null, null), "B");
            expressionist.AddExpression(new Expression("F", "5", ExpressionType.Value, null, null), "C");
            expressionist.AddExpression(new Expression("G", "-", ExpressionType.Operator, null, null), "C");
            expressionist.AddExpression(new Expression("H", "*", ExpressionType.Operator, null, null), "D");
            expressionist.AddExpression(new Expression("I", "/", ExpressionType.Operator, null, null), "D");
            expressionist.AddExpression(new Expression("J", "%", ExpressionType.Operator, null, null), "G");
            expressionist.AddExpression(new Expression("JA", "107", ExpressionType.Value, null, null), "G");
            expressionist.AddExpression(new Expression("K", "7", ExpressionType.Value, null, null), "H");
            expressionist.AddExpression(new Expression("L", "8", ExpressionType.Value, null, null), "H");
            expressionist.AddExpression(new Expression("M", "9", ExpressionType.Value, null, null), "I");
            expressionist.AddExpression(new Expression("N", "10", ExpressionType.Value, null, null), "I");
            expressionist.AddExpression(new Expression("O", "11", ExpressionType.Value, null, null), "J");
            expressionist.AddExpression(new Expression("P", "12", ExpressionType.Value, null, null), "J");

            Console.WriteLine(expressionist.Evaluate());
            Console.WriteLine(expressionist.Count());
            Console.WriteLine(expressionist.PreOrderDfs());

            expressionist.RemoveExpression("G");
            expressionist.RemoveExpression("D");
            Console.WriteLine(expressionist.Count());
            Console.WriteLine(expressionist.Evaluate());

           Console.WriteLine(expressionist.PreOrderDfs());
            
            
        }
    }
}
