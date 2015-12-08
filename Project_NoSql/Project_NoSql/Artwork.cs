using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Xml;
using Newtonsoft.Json;

namespace Project_NoSql
{
    class Artwork
    {
        public string id { get; set; }

        public int acquisitionYear { get; set; }

        public string classification { get; set; }

        public int height { get; set; }

        public int width { get; set; }

        public string title { get; set; }

        public string thumbnailUrl { get; set; }

        public string url { get; set; }

        public string medium { get; set; }

        public int subjectCount { get; set; }

        public string creditLine { get; set; }

        public List<Contributor> contributorList;

        public List<string> subjectList;

        /*
        public void instantiateSubjects3(XmlNode noeud)
        {
            while(noeud.HasChildNodes)
            {
                if(noeud.Name == "name")
                {
                    Console.WriteLine(noeud.InnerText);
                }

                noeud = noeud.FirstChild;

                while(noeud.NextSibling != null)
                {
                    noeud = noeud.NextSibling;
                    if(noeud.Name == "name")
                    {
                        Console.WriteLine(noeud.InnerText);
                    }
                }
            }

        }

        public void instantiateSubjects2(XmlNode noeud)
        {

            noeud = noeud.FirstChild;
            while (noeud.NextSibling != null)
            {
                switch (noeud.Name)
                {
                    case "id":
                        Console.WriteLine("ID +++++++++++++++++++ " + noeud.InnerText);
                        break;
                    case "name":
                        Console.WriteLine("Adding subject " + noeud.InnerText);
                        break;
                    case "children":
                        Console.WriteLine("DEEPER");
                        instantiateSubjects2(noeud);
                        
                        if(noeud.NextSibling == null)
                        {
                            Console.WriteLine("UPPEEEEEEER");
                      
                            noeud = noeud.ParentNode; //Trop tot ? 
                        }
                        break;
                }
                noeud = noeud.NextSibling;
                Console.WriteLine("NEXTTTTT");

            }

        }

        public void instantiateSubjects(XmlNode noeud)
        {
            noeud = noeud.FirstChild;
            while (noeud.NextSibling != null)
            {
                Console.WriteLine("----> " + noeud.Name + "   parent = " + noeud.ParentNode.Name);

                switch (noeud.Name)
                {
                    case "id":
                        if(noeud.NextSibling.Name == "name")
                        {
                            Console.WriteLine("Adding subject : " + noeud.NextSibling.InnerText);
                            //noeud = noeud.NextSibling;
                        }
                        break;
                    case "name":
                        //subjectList.Add(noeud.InnerText);
                        Console.WriteLine("Adding subject : " + noeud.InnerText);
                        break;
                    case "children":
                        instantiateSubjects(noeud);
                        break;
                }
                noeud = noeud.NextSibling;

            }
        }
        */

        public void instantiateFromXml(string fichier)
        {
            XmlDocument docXml = (XmlDocument)JsonConvert.DeserializeXmlNode(fichier, "answer");
            docXml.Save("answerXml.xml");

            XmlNode noeud = docXml.FirstChild.FirstChild;

            while (noeud != null)
            {
                switch (noeud.Name)
                {
                    case "_id":
                        this.id = noeud.InnerText;
                        break;
                    case "acquisitionYear":
                        this.acquisitionYear = Convert.ToInt32(noeud.InnerText);
                        break;
                    case "classification":
                        this.classification = noeud.InnerText;
                        break;
                    case "height":
                        this.height = Convert.ToInt32(noeud.InnerText);
                        break;
                    case "width":
                        this.width = Convert.ToInt32(noeud.InnerText);
                        break;
                    case "title":
                        this.title = noeud.InnerText;
                        break;
                    case "thumbnailUrl":
                        this.thumbnailUrl = noeud.InnerText;
                        break;
                    case "url":
                        this.url = noeud.InnerText;
                        break;
                    case "medium":
                        this.medium = noeud.InnerText;
                        break;
                    case "subjectCount":
                        this.subjectCount = Convert.ToInt32(noeud.InnerText);
                        break;
                        /*
                    case "subjects":
                        instantiateSubjects3(noeud);
                        break;

                        
                        noeud = noeud.FirstChild;
                        while(noeud.NextSibling != null)
                        {
                            noeud = noeud.NextSibling;
                            switch(noeud.Name)
                            {
                                case "id":
                                    break;
                                case "name":
                                    subjectList.Add(noeud.InnerText);
                                    break;
                                case "children":
                                    noeud = noeud.FirstChild;


                                    noeud = noeud.ParentNode;
                                break;
                            }
                        }

                        break;
                        */


                    case "creditLine":
                        this.creditLine = noeud.InnerText;
                        break;

                    /*
                    case "contributors":
                        for (int i = 0; i < noeud.ChildNodes.Count; i++)
                        {
                            string date = null;
                            string fullName = null;
                            string role = null;
                            string gender = null;

                            switch (noeud.ChildNodes[i].Name)
                            {
                                case "date":
                                    date = noeud.ChildNodes[i].InnerText;
                                    break;
                                case "fc":
                                    fullName = noeud.ChildNodes[i].InnerText;
                                    break;
                                case "role":
                                    role = noeud.ChildNodes[i].InnerText;
                                    break;
                                case "gender":
                                    gender = noeud.ChildNodes[i].InnerText;
                                    break;
                            }

                            Contributor contributor = new Contributor(date, fullName, role, gender);
                            if(contributor != null)
                            {
                                contributorList.Add(contributor);
                            }
                        }
                        break;
                        */
                }
                noeud = noeud.NextSibling;
            }
        }


        public  string toString()
        {
            string answer = "id : " + id + ", acquisition year : " + acquisitionYear + ", classification : " + classification;
            return answer;
        }
    }
}
