using NunitRestSharp.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NunitRestSharp.Core;

namespace NunitRestSharp.Tests.CIOStats.GetMetrics
{
    internal class GetMetrics : Base
    {
        [Test]
        public void ValidateStatusCode()
        {
            RestResponse response = Helper.Get.GetWithAuth(url, "/api/CIOStats/GetMetrics", tokenValue);
            Assert.That(((int)response.StatusCode), Is.EqualTo(200));
        }
        [Test]
        public void ValidateSchema()
        {
            RestResponse response = Helper.Get.GetWithAuth(url, "/api/CIOStats/GetMetrics", tokenValue);
            Assert.That(((int)response.StatusCode), Is.EqualTo(200));
            Schema.isValidSchema(System.IO.Directory.GetCurrentDirectory() + "\\Resources\\Schemas\\GetMetrics.json", response);
        }
        [Test]
        public void ValidateRequiredCredentials()
        {
            RestResponse response = Helper.Get.GetWithNoAuth(url, "/api/CIOStats/GetMetrics");
            Assert.That(((int)response.StatusCode), Is.EqualTo(401));
        }
    }
}
