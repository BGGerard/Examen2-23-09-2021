using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DotNetWeb.Core.Expresiones;

namespace DotNetWeb.Core.Statetment
{
    public class Asignacion : statement
    {
        public Asignacion(Id id, ExpresionTipo expression)
        {
            Id = id;
            Expression = expression;
        }

        public Id Id { get; }
        public ExpresionTipo Expression { get; }

        public override string Generate(int tabs)
        {
            var code = GetCodeInit(tabs);
            code += $"{Id.Generar()} = {Expression.Generar()}{Environment.NewLine}";
            return code;
        }

        public override void Interpret()
        {
            GestionDeAmbiente.UpdateVariable(Id.Token.Lexeme, Expression.Evaluar());
        }

        public override void ValidateSemantic()
        {
            if (Id.GetExpressionType() != Expression.GetExpressionType())
            {
                throw new ApplicationException($"Tipo {Id.GetExpressionType()} No se puede asignar a {Expression.GetExpressionType()}");
            }
        }
    }
}
