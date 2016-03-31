using System;
using System.Collections.Generic;
using System.Linq;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

namespace AmazonDynamoDB_Sample
{
    public class Reposetory<T> where T : class, new()
    {
        static readonly DynamoDBContext Context;
        static readonly  IAmazonDynamoDB Client;
        static Reposetory()
        {
            //IAmazonDynamoDB client = new AmazonDynamoDBClient("AKIAJ7VOTZQNZLZU6DYA", "QGkGrM6sDbmwRSmj5kBwRnNHvhSZFDkMJ0dtPnvG", RegionEndpoint.EUWest1);
            
            Client = new AmazonDynamoDBClient("AKIAI7VHNKV3FUFPFIWA", "PT+YSOalvNbUjp5JcUE95yDLV2jyX0avxLvPIxRa", RegionEndpoint.EUWest1);
            Context = new DynamoDBContext(Client);
        }

        public static void Save(T item)
        {
            Context.Save(item);
        }

        public static T Load(string hashKey)
        {
            return Context.Load<T>(hashKey);
        }

        public static T Load(object hashKey, object rangeKey)
        {
            return Context.Load<T>(hashKey, rangeKey);
        }
        
        public static void Delete(string key)
        {
            Context.Delete<T>(key, 1);
        }

        public static IEnumerable<T> Query(string indexName, params KeyValueModel[] args)
        {
            //var request = new QueryRequest
            //{
            //    TableName = "XPages",
            //    IndexName = indexName,
            //    ExpressionAttributeNames = new Dictionary<string, string>{{"#u", "Url"}},
            //    ProjectionExpression = "#u, SiteId",
            //    KeyConditionExpression = "ProductId = :v_productId and IsPublished= :v_isPublished",
            //    ExpressionAttributeValues = new Dictionary<string, AttributeValue> 
            //                                {
            //                                    {":v_productId", new AttributeValue { N = "1" }},
            //                                    {":v_isPublished", new AttributeValue { S = "true" }}
            //                                }
            //};


            var req = new QueryRequest
                          {
                              TableName = "ZPages",
                              IndexName = indexName,
                              KeyConditionExpression = "ProductId = :v_productId",
                              ExpressionAttributeValues =
                                  {
                                      {
                                          ":v_productId",new AttributeValue { N = "1" }
                                      }
                                  },
                              ExpressionAttributeNames = new Dictionary<string, string>{{"#u", "Url"}},
                              ProjectionExpression = "#u, SiteId",
                              ScanIndexForward = false
                          };


            var response = Client.Query(req);

            var result = ToList(response);

            return result;
        }

        private static IEnumerable<T> ToList(QueryResponse response)
        {
            var result = new List<T>();
            foreach (var item in response.Items)
            {
                var ii = new T();

                foreach (KeyValuePair<string, AttributeValue> kvp in item)
                {
                    var property = ii.GetType().GetProperty(kvp.Key);
                    var isInt = property.PropertyType.FullName.ToLower().Contains("int");

                    if (!isInt) property.SetValue(ii, (kvp.Value.S), null);
                    else property.SetValue(ii, Convert.ToInt32((kvp.Value.N)), null);
                }
                result.Add(ii);
            }
            return result;
        }

        public static void Sacan<T>()
        {
            Table table = Table.LoadTable(Client, "Businesses");
        }


        public static T LoadWithFilter<T>(object hashKey, object rangeKey, ScanCondition condition)
        {
           
            var queryFilter = new List<ScanCondition>{condition};
           
            var config = new DynamoDBOperationConfig{QueryFilter =  queryFilter};
            
            return Context.Load<T>(hashKey, rangeKey, config);
        }
    }

    public class KeyValueModel
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public QueryOperator Operator { get; set; }
    }
}
