using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DotNetWeb.Core
{
    public class Tipo : IEquatable<Tipo>
    {
        public string Lexema { get; private set; }
        public TokenType TokenType { get; private set; }

        public Tipo(string lexema, TokenType tokenType)
        {
            Lexema = lexema;
            TokenType = tokenType;
        }
        
        public static Tipo Int => new Tipo("int", TokenType.IntConstant);
        public static Tipo Float => new Tipo("float", TokenType.FloatConstant);
        public static Tipo String => new Tipo("string", TokenType.StringConstant);
        public static Tipo StringList => new Tipo("StringList", TokenType.StringListKeyword);
        public static Tipo FloatList => new Tipo("FloatList", TokenType.FloatListKeyword);
        public static Tipo IntList => new Tipo("IntList", TokenType.IntListKeyword);
        public static Tipo MoreThan => new Tipo("MoreThan", TokenType.GreaterThan);
        public static Tipo LessThan => new Tipo("LessThan", TokenType.LessThan);




        public bool Equals([AllowNull] Tipo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Lexema == other.Lexema && TokenType == other.TokenType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((Tipo)obj);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Lexema, (int)TokenType);
        }

        public static bool operator ==(Tipo a, Tipo b) => a.Equals(b);
        public static bool operator !=(Tipo a, Tipo b) => a.Equals(b);
    }
}
