using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Expressionist
{
    public class Expressionist : IExpressionist
    {
        private Dictionary<string, Expression> expressions;
        private Expression root;

        public Expressionist()
        {
            this.expressions = new Dictionary<string, Expression>();
        }

        public void AddExpression(Expression expression)
        {
            if (expressions.Count > 0)
            {
                throw new ArgumentException();
            }

            this.root = expression;
            expressions.Add(expression.Id, expression);
        }

        public void AddExpression(Expression expression, string parentId)
        {
            if (!this.expressions.ContainsKey(parentId))
            {
                throw new ArgumentException();
            }

            var parent = this.expressions[parentId];

            if (parent.LeftChild == null)
            {
                parent.LeftChild = expression;
            }
            else if (parent.RightChild == null)
            {
                parent.RightChild = expression;
            }
            else
            {
                throw new ArgumentException();
            }

            this.expressions.Add(expression.Id, expression);
            this.expressions[expression.Id].Parent = parent;
        }

        public bool Contains(Expression expression)
        {
            return this.expressions.ContainsKey(expression.Id);
        }

        public int Count()
        {
            return this.expressions.Count;
        }

        public string Evaluate()
        {
            var sb = new StringBuilder();

            this.Evaluate(this.root, sb);

            return sb.ToString();
        }

        private void Evaluate(Expression expression, StringBuilder sb)
        {
            if (expression == null)
            {
                return;
            }

            if (expression.Type == ExpressionType.Value)
            {
                sb.Append(expression.Value);
            }
            else
            {
                sb.Append("(");
                this.Evaluate(expression.LeftChild, sb);
                sb
                    .Append(" ")
                    .Append(expression.Value)
                    .Append(" ");
                this.Evaluate(expression.RightChild, sb);
                sb.Append(")");
            }
        }

        public Expression GetExpression(string expressionId)
        {
            if (!this.expressions.ContainsKey(expressionId))
            {
                throw new ArgumentException();
            }

            return this.expressions[expressionId];
        }

        public void RemoveExpression(string expressionId)
        {
            if (!this.expressions.ContainsKey(expressionId))
            {
                throw new ArgumentException();
            }

            var expression = this.expressions[expressionId];
            var parent = expression.Parent;


            if (parent.LeftChild.Id == expressionId)
            {
                parent.LeftChild = parent.RightChild;
            }

            this.Remove(expression);
            parent.RightChild = null;
        }

        private void Remove(Expression expression)
        {
            if (expression == null)
            {
                return;
            }

            this.expressions.Remove(expression.Id);
            this.Remove(expression.LeftChild);
            this.Remove(expression.RightChild);
        }

        public string PreOrderDfs()
        {
            var sb = new StringBuilder();
            int indent = 0;
            this.PreOrderDfs(this.root, sb, indent);

            return sb.ToString();
        }

        private void PreOrderDfs(Expression expression, StringBuilder sb, int indent)
        {
            if (expression == null)
            {
                return;
            }

            sb
                .Append(new string(' ', indent))
                .AppendLine(expression.Id);

            this.PreOrderDfs(expression.LeftChild, sb, indent + 2);
            this.PreOrderDfs(expression.RightChild, sb, indent + 2);
        }
    }
}
