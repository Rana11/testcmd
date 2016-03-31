/*******************************************************************************
* Copyright 2009-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
* 
* Licensed under the Apache License, Version 2.0 (the "License"). You may
* not use this file except in compliance with the License. A copy of the
* License is located at
* 
* http://aws.amazon.com/apache2.0/
* 
* or in the "license" file accompanying this file. This file is
* distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
* KIND, either express or implied. See the License for the specific
* language governing permissions and limitations under the License.
*******************************************************************************/

using System;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using System.Collections.Generic;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.SecurityToken;
using Amazon.Runtime;

namespace AmazonDynamoDB_Sample
{

    public partial class Program
    {
        public static IAmazonDynamoDB client;

        public static void Main(string[] args)
        {
<<<<<<< Updated upstream
            //master changes
=======
            //stash
>>>>>>> Stashed changes
            //v2
            //asdasReposetory<ZPage>.Delete("ranasafasdfas");

            //var item = Reposetory<XPage>.Load("/page2", 1);

            //Reposetory<XPage>.Save(new XPage { Id = 466025, Url = "/page444444444", ProductId = 1, SiteId = 1, IsPublished = true.ToString() });

            //var condition = new ScanCondition("IsPublished", ScanOperator.Equal, new object[] { "true" });

            ////var item = Reposetory.LoadWithFilter<XPage>("/page4", 1, condition);


            //var cond1 = new KeyValueModel { Key = "ProductId", Value = 1, Operator = QueryOperator.Equal };
            //var item = Reposetory<XPage>.Query("ProductId-IsPublished-index", new[] { cond1 });
            //Console.WriteLine(item != null);

            //for (int i = 0; i < 10; i++)
            //{
            //    Reposetory.Save(new WebPage() { Id = i, Url = "/testxxxx111" + i, SiteId = i % 10, ProductId = i % 100, H1 = "H1 " + i });
            //    //Thread.Sleep(10);
            //    //var item = Reposetory.LoadByHashKey<TestTable>(i.ToString());
            //    Console.WriteLine(i);
            //}

            //for (int i = 0; i < 1000; i++)
            //{
            //    var result = Reposetory.Query<WebPage>("/test/Page" + i, "Url");
            //    Console.WriteLine(result.ToList().First().Url);
            //}



            //Reposetory.Delete<TestTable>("10");


            Console.WriteLine("Setting up DynamoDB client");
            client = new AmazonDynamoDBClient("AKIAJ7VOTZQNZLZU6DYA", "QGkGrM6sDbmwRSmj5kBwRnNHvhSZFDkMJ0dtPnvG", RegionEndpoint.EUWest1);

            //PutItem();
            Console.WriteLine();
            Console.WriteLine("Creating sample tables");
            CreateSampleTables();

            Console.WriteLine();
            Console.WriteLine("Running DataModel sample");
            RunDataModelSample();

            Console.WriteLine();
            Console.WriteLine("Running DataModel sample");
            RunDocumentModelSample();

            Console.WriteLine();
            Console.WriteLine("Removing sample tables");
            DeleteSampleTables();

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.Read();
        }
    }
}