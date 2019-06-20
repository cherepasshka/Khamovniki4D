using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace Khamovniki4D
{
    class Neo4jDB
    {
        public GraphClient client;
        public Neo4jDB(string password, string uri = "http://localhost:7474")
        {
            client = new GraphClient(new Uri(uri + "/db/data"), "neo4j", password);
        }
        public void Connect()
        {
            try
            {
                client.Connect();
                Console.WriteLine("Connected to Neo4j!");
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }
        public void Clear()
        {
            client.Cypher.Match("(a)").DetachDelete("a").ExecuteWithoutResultsAsync();
        }
        public void CreateRelationship(string type, Node from, Node to)
        {
            var query = client.Cypher
            .Match("(from:" + from.NodeType + ")", "(to:" + to.NodeType + ")")
            .Where("from.NodeName={nodeFrom}").WithParam("nodeFrom", from.NodeName)
            .AndWhere("from.Year={fromYear}").WithParam("fromYear", from.Year)
            .AndWhere("from.Component={fromComponent}").WithParam("fromComponent", from.Component)
            .AndWhere("to.NodeName={nodeTo}").WithParam("nodeTo", to.NodeName)
            .AndWhere("to.Year={toYear}").WithParam("toYear", to.Year)
            .AndWhere("to.Component={toComponent}").WithParam("toComponent", to.Component)
            .Create("(from)-[:" + type + "]->(to)")
            .ExecuteWithoutResultsAsync();
            Console.WriteLine("Relationship {0} between node {1} and node {2} created", type, from.NodeName, to.NodeName);
        }
        public void AddNode(Node newNode)
        {
            client.Cypher.Create("(node:" + newNode.NodeType + "{ NodeName:{NodeName}, NodeType: {NodeType}, Year: {Year}, Component: {Component} })")
            .WithParam("NodeType", newNode.NodeType).WithParam("NodeName", newNode.NodeName)
            .WithParam("Year",newNode.Year).WithParam("Component",newNode.Component).ExecuteWithoutResults();
            Console.WriteLine("Node {0} created", newNode.NodeName);
        }
    }
}
