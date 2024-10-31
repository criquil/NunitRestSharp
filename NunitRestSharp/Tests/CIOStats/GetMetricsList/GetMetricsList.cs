using NunitRestSharp.Core;
using NunitRestSharp.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitRestSharp.Tests.CIOStats.GetMetricsList
{
    internal class GetMetricsList : Base
    {
        [Test]
        public void ValidateStatusCode()
        {
            RestResponse response = Helper.Get.GetWithAuth(url, "/api/CIOStats/GetMetricsList", tokenValue);
            Assert.That(((int)response.StatusCode), Is.EqualTo(200));
        }
        [Test]
        public void ValidateSchema()
        {
            RestResponse response = Helper.Get.GetWithAuth(url, "/api/CIOStats/GetMetricsList", tokenValue);
            Assert.That(((int)response.StatusCode), Is.EqualTo(200));
            Schema.isValidSchema(System.IO.Directory.GetCurrentDirectory() + "\\Resources\\Schemas\\GetMetricsList.json", response);
        }
        [Test]
        public void ValidateRequiredCredentials()
        {
            RestResponse response = Helper.Get.GetWithNoAuth(url, "/api/CIOStats/GetMetricsList");
            Assert.That(((int)response.StatusCode), Is.EqualTo(401));
        }
    }
}
