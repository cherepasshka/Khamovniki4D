using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Text.RegularExpressions;
namespace Khamovniki4D
{
    public partial class GraphCreator : Form
    {
        List<Relationship> relationships;
        List<Node> nodes;
        Neo4jDB db;
        string serverUri, inputFile;
        int startInd = 2;
        public GraphCreator()
        {
            InitializeComponent();
            year.Minimum = 1925;
            year.Maximum = 1934;
            serverUri = "http://localhost:7474";
            OpenConnection();
            hint.Text = "";
            currentYear.Text = "Выбран " + year.Value + " год";
            relationships = new List<Relationship>();
            nodes = new List<Node>();
            inputFile = Directory.GetCurrentDirectory() + "\\inputs\\level3.xlsx";
        }
        private void FillGraphDB()
        {
            Node from, to;
            string type;
            foreach (Node node in nodes)
            {
                db.AddNode(node);
            }
            for (int i = 0; i < relationships.Count; ++i)
            {
                from = nodes[relationships[i].FromNodeInd];
                to = nodes[relationships[i].ToNodeInd];
                type = relationships[i].Type.Replace(" ", "_");
                db.CreateRelationship(type, from, to);
            }
        }
        private void AddNodesToList(string str, string pattern, ref List<string> nodes, ref string main_node)
        {
            try
            {
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(str);
                foreach (Match match in matches)
                {
                    if (match.Value == "!Булгаков!") main_node = match.Value.TrimStart(' ').TrimEnd(' ');
                    else nodes.Add(match.Value.TrimStart(' ').TrimEnd(' '));
                }
            }
            catch{}
        }
        private void AddNodesManuscript(string str, string patternManuscr, string patternGanre, ref List<string> nodes)
        {
            try
            {
                Regex regex = new Regex(patternManuscr);
                MatchCollection matches = regex.Matches(str);
                regex = new Regex(patternGanre);
                foreach (var match in matches)
                {
                    string m = match.ToString() + "," + regex.Match(str).ToString().Replace("\\", "");
                    nodes.Add(m.TrimStart(' ').TrimEnd(' '));
                }
            }
            catch{}
        }
        private Node MatchNode(string str, string year,int comp)
        {
            Node node;
            if (str[0] == '!')
            {
                node = new Human(str.Replace("!", ""), comp);
            }
            else if (str[0] == '|')
            {
                str = str.Replace("|", "");
                string[] manuscrData = str.Split(',');
                string name = manuscrData[0], ganre = manuscrData[1];
                node = new Manuscript(name, ganre, comp);
            }
            else if (str[0] == '?')
            {
                node = new Organization(str.Replace("?", ""), comp);
            }
            else if (str[0] == '/')
            {
                node = new Location(str.Replace("/", ""), comp);
            }
            else
            {
                node = new Node("None", -1);
            }
            node.Year = Convert.ToInt32(year);
            return node;
        }
        private void ClearString(string s, ref List<string> stringNodes, ref string mainPerson, ref string relat)
        {
            string patternPerson = @"![А-ЯЁа-яё\- ]+!", patternManusc = @"\|[А-ЯЁа-яё ]+\|", patternGanre = @"\\[\w ]+\\";
            string patternAddres = @"\/[А-Яа-я \.,0-9Ёё]+\/", patternOrganiz = @"\?[А-ЯЁа-яё \(\)]+\?", patternRelationsh = @"\*[А-ЯЁа-яё\.,\d- ]+\*";
            AddNodesToList(s, patternAddres, ref stringNodes, ref mainPerson);
            AddNodesManuscript(s, patternManusc, patternGanre, ref stringNodes);
            AddNodesToList(s, patternOrganiz, ref stringNodes, ref mainPerson);
            AddNodesToList(s, patternPerson, ref stringNodes, ref mainPerson);
            Regex regex = new Regex(patternRelationsh);
            MatchCollection matches = regex.Matches(s);
            if (matches.Count > 0)
                relat = matches[0].Value.ToString().Replace("*", "");
            else relat = "_";
            relat = relat.Replace(",", "").Replace("-", "").Replace(".","");
            relat = relat.TrimStart(' ').TrimEnd(' ');
            if (relat.Length > 70) relat = relat.Substring(0, 69);
        }
        private void AddFromBulgakov(string relat, string mainPerson, string yearOfPeriod, List<string> stringNodes, string year,int comp)
        {
            Node start, cur;
            Relationship relation;
            start = MatchNode(mainPerson, yearOfPeriod, comp);
            if (!nodes.Contains(start))
                nodes.Add(start);
            foreach (string node in stringNodes)
            {
                cur = MatchNode(node, yearOfPeriod, comp);
                if (cur.NodeType == "None") continue;
                if (!nodes.Contains(cur))
                    nodes.Add(cur);
                status.Items.Add(start.NodeName + "-[" + relat + "]-" + cur.NodeName + " ---- " + year);
                relation = new Relationship(relat, nodes.IndexOf(start), nodes.IndexOf(cur));
                if (!relationships.Contains(relation))
                    relationships.Add(relation);
            }
        }
        private void AddFromAll(string relat, string yearOfPeriod, List<string> stringNodes, string year,int comp)
        {
            Node first, second;
            Relationship relation;
            for (int i = 0; i < stringNodes.Count; ++i)
            {
                for (int j = i + 1; j < stringNodes.Count; ++j)
                {
                    first = MatchNode(stringNodes[i], yearOfPeriod,comp);
                    second = MatchNode(stringNodes[j], yearOfPeriod,comp);
                    if (first.NodeType == "None" || second.NodeType == "None") continue;
                    if (!nodes.Contains(first))
                        nodes.Add(first);
                    if (!nodes.Contains(second))
                    {
                        nodes.Add(second);
                    }
                    status.Items.Add(first.NodeName + "-[" + relat + "]-" + second.NodeName + " --------- " + year);
                    relation = new Relationship(relat, nodes.IndexOf(first), nodes.IndexOf(second));
                    if (!relationships.Contains(relation))
                        relationships.Add(relation);
                }
            }
        }
        private void MakeRelations(string s, string yearOfPeriod,int comp)
        {
            string mainPerson = "", relat = "";
            List<string> stringNodes = new List<string>();
            ClearString(s, ref stringNodes, ref mainPerson, ref relat);
            if (char.IsDigit(relat[0]))
            {
                relat = 'u' + relat;
            }
            relat = relat.Replace("-", "");
            if (mainPerson != "")
            {
                AddFromBulgakov(relat, mainPerson, yearOfPeriod, stringNodes, yearOfPeriod, comp);
            }
            else
            {
                AddFromAll(relat, yearOfPeriod, stringNodes, yearOfPeriod,comp);
            }
        }
        private void SplitDate(string date, out int day, out int month, out int year)
        {
            string[] dat = date.Split('.');
            day = Convert.ToInt32(dat[0]);
            month = Convert.ToInt32(dat[1]);
            year = Convert.ToInt32(dat[2]);
        }
        private void FillDateInterval(string date,ref string first,ref string second)
        {
            string pattern = @"(\d{1,2}\.){2}\d{4}";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(date);
            if (matches.Count < 1)
            {
                first = second = "";
                return;
            }
            first = second = matches[0].Value;
            if (matches.Count > 1)
            {
                second = matches[1].Value;
            }
        }
        public void CreateGraph(string year)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook wbook = app.Workbooks.Open(inputFile);
            Worksheet currentSheet = wbook.Worksheets["Граф событий_драм"];
            Time begin = new Time(), end = new Time();
            int count = 0, d, m, y, comp = 0, row = 1;
            string cur, first = "", second = "";
            while (currentSheet.get_Range("A" + row).Value2 != null) row++;
            Range relations = currentSheet.get_Range("B" + startInd.ToString(), "B" + row.ToString());
            Range years = currentSheet.get_Range("A" + startInd.ToString(), "A" + row.ToString());
            for (int i = 0; i < relations.Count; ++i)
            {
                cur = years[i].Value.Replace("<", "").Replace(">", "");
                FillDateInterval(cur, ref first, ref second);
                if (!first.Contains(year) && !second.Contains(year)) continue;
                if (count == 7){
                    count = 0;
                    comp++;
                }
                if (count == 0 && comp==0)
                {
                    SplitDate(first, out d, out m, out y);
                    begin = new Time(d, m, y);
                }
                MakeRelations(relations[i].Value.ToString(), year,comp);
                if (second != "" || first != "")
                {
                    SplitDate((second == "" ? first : second), out d, out m, out y);
                    end = new Time(d, m, y);
                }
                count++;
            }
            nodes.Add(begin);
            nodes.Add(end);
            relationships.Add(new Relationship("timeline", nodes.Count - 2, nodes.Count - 1));
            wbook.Close();
            FillGraphDB();
        }
        private void Create_Click(object sender, EventArgs e)
        {
            db.Clear();
            nodes.Clear();
            relationships.Clear();
            status.Items.Clear();
            CreateGraph(year.Value.ToString().TrimStart(' ').TrimEnd(' '));
        }
        private void Go_Click(object sender, EventArgs e)
        {
            Neo4jViewer nv = new Neo4jViewer(serverUri);
            nv.Show();
        }
        private void Year_MouseLeave(object sender, EventArgs e)
        {
            hint.Text = "";
        }
        private void Year_MouseEnter(object sender, EventArgs e)
        {
            hint.Text = "Перемещая ползунок этого элемента можно выбрать год, по которому нужно построить граф.";
        }
        private void Create_MouseEnter(object sender, EventArgs e)
        {
            hint.Text = "Строит граф по выбранному году.";
        }
        private void Create_MouseLeave(object sender, EventArgs e)
        {
            hint.Text = "";
        }
        private void Go_MouseLeave(object sender, EventArgs e)
        {
            hint.Text = "";
        }
        private void Go_MouseEnter(object sender, EventArgs e)
        {
            hint.Text = "Открывает Neo4j браузер.";
        }
        private void ChooseUri_MouseEnter(object sender, EventArgs e)
        {
            hint.Text = "Сейчас графовая БД подключена к " + serverUri + ".";
        }
        private void ChooseUri_MouseLeave(object sender, EventArgs e)
        {
            hint.Text = "";
        }
        private void ChooseInputFile_MouseEnter(object sender, EventArgs e)
        {
            hint.Text = "Сейчас открыт " + inputFile + ".";
        }
        private void ChooseInputFile_MouseLeave(object sender, EventArgs e)
        {
            hint.Text = "";
        }
        private void ChooseInputFile_Click(object sender, EventArgs e)
        {
            openInputFile.ShowDialog();
            if(openInputFile.FileName!="")
                inputFile = openInputFile.FileName;
        }
        private void OpenConnection()
        {
            db = new Neo4jDB("root", serverUri);
            db.Connect();
        }
        private void ChooseUri_Click(object sender, EventArgs e)
        {
            string res = InputBox.Show("Введите URI для используемой графовой БД");
            if (res != "") {
                serverUri = res;
                OpenConnection();
            }
        }
        private void Year_Scroll(object sender, EventArgs e)
        {
            currentYear.Text = "Выбран " + year.Value + " год";
        }
    }
}
/*
 Installation:
    install-package neo4jclient
 */