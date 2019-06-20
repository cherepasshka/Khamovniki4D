using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khamovniki4D
{
    class Node
    {
        private string  nodeName, nodeType;
        private int component,year;
        public int Component
        {
            get { return component; }
            set { component = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public string NodeType
        {
            get { return nodeType; }
            set { nodeType = value; }
        }
        public string NodeName
        {
            get { return nodeName; }
            set { nodeName = value; }
        }
        public Node(string nodeType,int comp)
        {
            NodeType = nodeType;
            Component = comp;
        }
        public override bool Equals(Object obj)
        {
            if (obj is Node)
            {
                if (obj is Manuscript && this is Manuscript) return (obj as Manuscript).name == (this as Manuscript).name && Component==(obj as Node).Component;
                return NodeName == (obj as Node).NodeName && NodeType == (obj as Node).NodeType && (obj as Node).Year == Year && Component == (obj as Node).Component;
            }
            return false;
        }
    }
    class Location : Node
    {
        public string street;
        public Location(string street, int comp) : base("Location", comp)
        {
            NodeName = street;
            this.street = street;
        }
    }
    class Time : Node
    {
        private int day, month;
        public int Day
        {
            get { return day; }
            set { day = value; }
        }
        public int Month
        {
            get { return month; }
            set { month = value; }
        }
        public Time(int d, int m, int y) : base("Time", -1)
        {
            Day = d;
            Month = m;
            Year = y;
            NodeName = string.Format("{0}.{1}.{2}", Day.ToString().PadLeft(2, '0'), Month.ToString().PadLeft(2, '0'), Year);
        }
        public Time() : base("Time", -1)
        {
            Day = 1;
            Month = 1;
        }
    }
    class Manuscript : Node
    {
        public string name, ganre;
        public Manuscript(string name, string ganre, int comp) : base("Manuscript",comp)
        {
            if (ganre != "")
                NodeName = name + ", " + ganre;
            else NodeName = name;
            this.name = name;
            this.ganre = ganre;
        }
    }
    class Human : Node
    {
        public string name;
        public Human(string name, int comp) : base("Human", comp)
        {
            NodeName = this.name = name;
        }
    }
    class Organization : Node
    {
        private string name;
        public Organization(string name, int comp) : base("Organization", comp)
        {
            NodeName = this.name = name;
        }
    }
}