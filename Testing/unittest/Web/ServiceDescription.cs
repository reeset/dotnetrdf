﻿using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VDS.RDF.Parsing;
using VDS.RDF.Writing.Formatting;

namespace VDS.RDF.Test.Web
{
    /// <summary>
    /// Summary description for ServiceDescription
    /// </summary>
    [TestClass]
    public class ServiceDescription
    {
        private void EnsureIIS()
        {
            if (!TestConfigManager.GetSettingAsBoolean(TestConfigManager.UseIIS))
            {
                Assert.Inconclusive("Test Config marks IIS as unavailable, cannot run this test");
            }
        }

        [TestMethod]
        public void ServiceDescriptionOptionsRequestOnSparqlServer()
        {
            EnsureIIS();
            String server = TestConfigManager.GetSetting(TestConfigManager.LocalGraphStoreUri);

            Console.WriteLine("Making an OPTIONS request to the web demos SPARQL Server at " + server);
            Console.WriteLine();

            NTriplesFormatter formatter = new NTriplesFormatter();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(server);
            request.Method = "OPTIONS";
            request.Accept = MimeTypesHelper.HttpAcceptHeader;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                IRdfReader parser = MimeTypesHelper.GetParser(response.ContentType);
                Graph g = new Graph();
                parser.Load(g, new StreamReader(response.GetResponseStream()));

                TestTools.ShowGraph(g);

                Assert.IsFalse(g.IsEmpty, "A non-empty Service Description Graph should have been returned");

                response.Close();
            }
        }

        [TestMethod]
        public void ServiceDescriptionOptionsRequestOnSparqlServer2()
        {
            EnsureIIS();
            String path = TestConfigManager.GetSetting(TestConfigManager.LocalGraphStoreUri) + "some/long/path/elsewhere";

            Console.WriteLine("Making an OPTIONS request to the web demos SPARQL Server at " + path);
            Console.WriteLine("This Test tries to ensure that the URI resolution works correctly");
            Console.WriteLine();

            NTriplesFormatter formatter = new NTriplesFormatter();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
            request.Method = "OPTIONS";
            request.Accept = MimeTypesHelper.HttpAcceptHeader;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                IRdfReader parser = MimeTypesHelper.GetParser(response.ContentType);
                Graph g = new Graph();
                parser.Load(g, new StreamReader(response.GetResponseStream()));

                TestTools.ShowGraph(g);

                Assert.IsFalse(g.IsEmpty, "A non-empty Service Description Graph should have been returned");

                response.Close();
            }
        }

        [TestMethod]
        public void ServiceDescriptionDescriptionUriSparqlServer()
        {
            EnsureIIS();
            String path = TestConfigManager.GetSetting(TestConfigManager.LocalGraphStoreUri) + "description";

            Console.WriteLine("Making an request for the Service Description from the web demos SPARQL Server at " + path);
            Console.WriteLine();

            NTriplesFormatter formatter = new NTriplesFormatter();
            Graph g = new Graph();
            UriLoader.Load(g, new Uri(path));
            TestTools.ShowGraph(g);

            Assert.IsFalse(g.IsEmpty, "A non-empty Service Description Graph should have been returned");
        }

        [TestMethod]
        public void ServiceDescriptionOptionsRequestOnQueryHandler()
        {
            EnsureIIS();
            String server = TestConfigManager.GetSetting(TestConfigManager.LocalQueryUri);

            Console.WriteLine("Making an OPTIONS request to the web demos Query Handler at " + server);
            Console.WriteLine();

            NTriplesFormatter formatter = new NTriplesFormatter();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(server);
            request.Method = "OPTIONS";
            request.Accept = MimeTypesHelper.HttpAcceptHeader;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                IRdfReader parser = MimeTypesHelper.GetParser(response.ContentType);
                Graph g = new Graph();
                parser.Load(g, new StreamReader(response.GetResponseStream()));

                TestTools.ShowGraph(g);

                Assert.IsFalse(g.IsEmpty, "A non-empty Service Description Graph should have been returned");

                response.Close();
            }
        }

        [TestMethod]
        public void ServiceDescriptionOptionsRequestOnSparqlServer3()
        {
            EnsureIIS();
            String server = TestConfigManager.GetSetting(TestConfigManager.LocalGraphStoreQueryUri);

            Console.WriteLine("Making an OPTIONS request to the web demos SPARQL Server Query Endpoint at " + server);
            Console.WriteLine();

            NTriplesFormatter formatter = new NTriplesFormatter();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(server);
            request.Method = "OPTIONS";
            request.Accept = MimeTypesHelper.HttpAcceptHeader;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                IRdfReader parser = MimeTypesHelper.GetParser(response.ContentType);
                Graph g = new Graph();
                parser.Load(g, new StreamReader(response.GetResponseStream()));

                TestTools.ShowGraph(g);

                Assert.IsFalse(g.IsEmpty, "A non-empty Service Description Graph should have been returned");

                response.Close();
            }
        }

        [TestMethod]
        public void ServiceDescriptionOptionsRequestOnSparqlServer4()
        {
            EnsureIIS();
            String server = TestConfigManager.GetSetting(TestConfigManager.LocalGraphStoreUpdateUri);

            Console.WriteLine("Making an OPTIONS request to the web demos SPARQL Server Update Endpoint at " + server);
            Console.WriteLine();

            NTriplesFormatter formatter = new NTriplesFormatter();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(server);
            request.Method = "OPTIONS";
            request.Accept = MimeTypesHelper.HttpAcceptHeader;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                IRdfReader parser = MimeTypesHelper.GetParser(response.ContentType);
                Graph g = new Graph();
                parser.Load(g, new StreamReader(response.GetResponseStream()));

                TestTools.ShowGraph(g);

                Assert.IsFalse(g.IsEmpty, "A non-empty Service Description Graph should have been returned");

                response.Close();
            }
        }
    }

}
