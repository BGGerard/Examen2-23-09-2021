using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetWeb.Core.Expresiones
{
    public class Id : ExpresionTipo
    {
        public Id(Token token, Tipo tipo) : base(token, tipo)
        {
        }

        public override dynamic Evaluar()
        {
            return GestionDeAmbiente.GetSymbolForEvaluation(Token.Lexeme).Value;
        }
        public override string Generar()
        {
            return Token.Lexeme;
        }
        public override Tipo GetExpressionType()
        {
            return tipo;
        }

    }
}
