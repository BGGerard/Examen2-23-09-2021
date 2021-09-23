using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetWeb.Core.Statetment
{
    public class Sequencia : statement
    {

        public statement FirstStatement { get; private set; }

        public statement NextStatement { get; private set; }

        public Sequencia(statement firstStatement, statement nextStatement)
        {
            FirstStatement = firstStatement;
            NextStatement = nextStatement;
        }

        public override string Generate(int tabs)
        {
            var code = FirstStatement?.Generate(tabs);
            code += NextStatement?.Generate(tabs);
            return code;
        }

        public override void Interpret()
        {
            FirstStatement?.ValidateSemantic();
            NextStatement?.ValidateSemantic();
        }

        public override void ValidateSemantic()
        {
            FirstStatement?.ValidateSemantic();
            NextStatement?.ValidateSemantic();
        }
    }
}
