using System;
using DotNetWeb.Core.Expresiones;
using System.Collections.Generic;
using System.Text;

namespace DotNetWeb.Core.Statetment
{
    class ifstm : statement
    {
        public ifstm ( ExpresionTipo expr, statement state)
        {
            Expresion = expr;
            statement = state;
        }

        public ExpresionTipo Expresion { get; }
        public statement statement { get; }

        public override string Generate(int tabs)
        {
            var code = GetCodeInit(tabs);
            code += $"if({Expresion.Generar()}):{Environment.NewLine}";
            code += $"{statement.Generate(tabs + 1)}{Environment.NewLine}";
            return code;
        }

        public override void Interpret()
        {
            if (Expresion.Evaluar())
            {
                statement.Interpret();
            }
        }

        public override void ValidateSemantic()
        {
            if (Expresion.GetExpressionType() != Tipo.MoreThan || Expresion.GetExpressionType() != Tipo.LessThan )
            {
                throw new ApplicationException("PAra Un if es requerido un valor booleano");
            }
        }
    }
}
