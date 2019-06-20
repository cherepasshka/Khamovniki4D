using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khamovniki4D
{
    class Relationship
    {
        string type;
        int fromNodeInd, toNodeInd;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int ToNodeInd
        {
            get { return toNodeInd; }
            set { toNodeInd = value; }
        }
        public int FromNodeInd
        {
            get { return fromNodeInd; }
            set { fromNodeInd = value; }
        }
        public Relationship(string type, int fromInd, int toInd)
        {
            Type = type;
            FromNodeInd = fromInd;
            ToNodeInd = toInd;
        }
        public override bool Equals(object obj)
        {
            if (obj is Relationship)
            {
                bool first = (obj as Relationship).FromNodeInd == FromNodeInd && (obj as Relationship).ToNodeInd == ToNodeInd
                    && (obj as Relationship).Type == Type;
                bool second = (obj as Relationship).ToNodeInd == FromNodeInd && (obj as Relationship).FromNodeInd == ToNodeInd
                    && (obj as Relationship).Type == Type;
                return first || second;
            }
            return false;
        }
    }
}
