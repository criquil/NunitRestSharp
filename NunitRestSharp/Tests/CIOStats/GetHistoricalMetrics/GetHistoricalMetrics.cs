using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NunitRestSharp.Core;
using NunitRestSharp.Helper;
using RestSharp;

namespace NunitRestSharp.Tests.CIOStats.GetHistoricalMetrics
{
    internal class GetHistoricalMetrics : Base
    {
        [Test]
        public void ValidateStatusCode()
        {
            RestResponse response = Helper.Get.GetWithAuth(url, "/api/CIOStats/GetHistoricalMetrics", tokenValue);
            Assert.That(((int)response.StatusCode), Is.EqualTo(200));
        }
        [Test]
        public void ValidateSchema()
        {
            RestResponse response = Helper.Get.GetWithAuth(url, "/api/CIOStats/GetMetrics", tokenValue);
            Assert.That(((int)response.StatusCode), Is.EqualTo(200));
            Schema.isValidSchema(System.IO.Directory.GetCurrentDirectory() + "\\Resources\\Schemas\\GetHistoricalMetrics.json", response);
        }
        [Test]
        public void ValidateRequiredCredentials()
        {
            RestResponse response = Helper.Get.GetWithNoAuth(url, "/api/CIOStats/GetHistoricalMetrics");
            Assert.That(((int)response.StatusCode), Is.EqualTo(401));
        }
    }
}
