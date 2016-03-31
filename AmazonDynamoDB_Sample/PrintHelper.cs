using System;
using System.Collections.Generic;

using Amazon.DynamoDBv2.Model;

namespace AmazonDynamoDB_Sample
{
    public class PrintHelper
    {
        public static void PrintItem(Dictionary<string, AttributeValue> attrs)
        {
            foreach (KeyValuePair<string, AttributeValue> kvp in attrs)
            {
                Console.Write(kvp.Key + " = ");
                PrintValue(kvp.Value);
            }
        }

        public static void PrintValue(AttributeValue value)
        {
            // Binary attribute value.
            if (value.B != null)
            {
                Console.Write("Binary data");
            }
                // Binary set attribute value.
            else if (value.BS.Count > 0)
            {
                foreach (var bValue in value.BS)
                {
                    Console.Write("\n  Binary data");
                }
            }
                // List attribute value.
            else if (value.L.Count > 0)
            {
                foreach (AttributeValue attr in value.L)
                {
                    PrintValue(attr);
                }
            }
                // Map attribute value.
            else if (value.M.Count > 0)
            {
                Console.Write("\n");
                PrintItem(value.M);
            }
                // Number attribute value.
            else if (value.N != null)
            {
                Console.Write(value.N);
            }
                // Number set attribute value.
            else if (value.NS.Count > 0)
            {
                Console.Write("{0}", String.Join("\n", value.NS.ToArray()));
            }
                // Null attribute value.
            else if (value.NULL)
            {
                Console.Write("Null");
            }
                // String attribute value.
            else if (value.S != null)
            {
                Console.Write(value.S);
            }
                // String set attribute value.
            else if (value.SS.Count > 0)
            {
                Console.Write("{0}", String.Join("\n", value.SS.ToArray()));
            }
                // Otherwise, boolean value.
            else
            {
                Console.Write(value.BOOL);
            }

            Console.Write("\n");
        }
    }
}