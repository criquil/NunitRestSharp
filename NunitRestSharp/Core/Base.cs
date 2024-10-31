using NunitRestSharp.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitRestSharp.Core
{
    internal class Base
    {
      //  private RestRequest request;
        public static string tokenValue;
        public static string url;

        [SetUp]
        public static async Task Setup()
        {
            tokenValue =  await Initializer.Initialize();
            url = Initializer.URL();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up code
        }
    }
}
