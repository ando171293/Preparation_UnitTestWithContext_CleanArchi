using Castle.Core.Resource;
using Preparation.IRepos;
using Preparation.IService;
using Preparation.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Preparation.Service
{
    public class ServiceParents : IServiceParents
    {
        private readonly IReposParents _isp;
        public ServiceParents(IReposParents isp) { _isp = isp; }
        public void Create(Parents entity)
        {
            _isp.Create(entity);
        }

        public List<Parents> GetDataXMl()
        {
            string chemin = "C:\\Users\\HAIRUN\\source\\repos\\Preparation\\Parents.xml";
            var listXml = XElement.Load(chemin);

            var Lst = listXml.Descendants("Parent").Select(p =>new Parents { 
                                                                    Id = int.Parse( p.Element("Id").Value),
                                                                    Pere = p.Element("Pere").Value,
                                                                    Mere = p.Element("Mere").Value,
                                                                    Adresse = p.Element("Adresse").Value
                                                                }).ToList();

            return Lst;
        }

        

        public void ExportParentsToXml()
        {
            var ListParents = FindAll().ToList();

            // Create a new XmlWriterSettings object and set the formatting options
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\r\n";

            // Create a new XmlWriter object with the settings and write the XML header
            using (XmlWriter writer = XmlWriter.Create(@"C:\\Users\\HAIRUN\\source\\repos\\Preparation\\Parents.xml", settings))
            {
                writer.WriteStartDocument();
                // Write the root element and loop through your data, writing each line as a child element
                writer.WriteStartElement("Parents");
                foreach (var line in ListParents)
                {
                    writer.WriteStartElement("Parent");
                    writer.WriteStartElement("Id"); writer.WriteString(line.Id.ToString()); writer.WriteEndElement();
                    writer.WriteStartElement("Pere"); writer.WriteString(line.Pere); writer.WriteEndElement();
                    writer.WriteStartElement("Mere"); writer.WriteString(line.Mere);  writer.WriteEndElement();
                    writer.WriteStartElement("Adresse"); writer.WriteString(line.Adresse);  writer.WriteEndElement();
                    writer.WriteEndElement();

                }
                writer.WriteEndElement(); // close the root element
                writer.WriteEndDocument();
            }

        }
            


        public void MockParents()
        {
            for (int i = 0; i < 100; i++) { 
                Parents parents = new Parents() { Pere = "nomPere-"+i,Mere="nomMere-"+i,Adresse="ville-"+i };
                Create(parents);
            }
        }

        public void Delete(Parents entity)
        {
            _isp.Delete(entity);
        }

        public IQueryable<Parents> FindAll()
        {
           return _isp.FindAll();
        }

        public IQueryable<Parents> FindByCondition(Expression<Func<Parents, bool>> expression)
        {
            throw new NotImplementedException();
        }

       

        public void Update(Parents entity)
        {
            _isp.Update(entity);
        }

        
    }
}
