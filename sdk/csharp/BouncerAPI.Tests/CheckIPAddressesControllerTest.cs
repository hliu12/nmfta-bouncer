/*
 * BouncerAPI.Tests
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using BouncerAPI.Standard;
using BouncerAPI.Standard.Utilities; 
using BouncerAPI.Standard.Http.Client;
using BouncerAPI.Standard.Http.Response;
using BouncerAPI.Tests.Helpers;
using NUnit.Framework;
using BouncerAPI.Standard;
using BouncerAPI.Standard.Controllers;
using BouncerAPI.Standard.Exceptions;

namespace BouncerAPI.Tests
{
    [TestFixture]
    public class CheckIPAddressesControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests)
        /// </summary>
        private static CheckIPAddressesController controller;

        /// <summary>
        /// Setup test class
        /// </summary>
        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().CheckIPAddresses;
        }

        /// <summary>
        /// Check if an IP Address is Already White- or Black-Listed 
        /// </summary>
        [Test]
        public async Task TestTestForListMembership1() 
        {
            // Parameters for the API call
            string ipAddress = "192.168.100.14";

            // Perform API call
            Standard.Models.TestForListMembershipResponse result = null;

            try
            {
                result = await controller.TestForListMembershipAsync(ipAddress);
            }
            catch(APIException) {};

            // Test response code
            Assert.AreEqual(200, httpCallBackHandler.Response.StatusCode,
                    "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", null);

            Assert.IsTrue(TestHelper.AreHeadersProperSubsetOf (
                    headers, httpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");

            Assert.AreEqual("{  \"Result\": {    \"List\": \"Whitelist\",    \"Status\": \"Success\",    \"Message\": \"\"  },  \"Entry\": {    \"IPv4\": \"192.168.100.14/24\",    \"IPv6\": \"2001:db8::/64\",    \"Start_Date\": \"2019-04-05T02:04:16Z\",    \"End_Date\": \"2019-04-05T02:04:16Z\",    \"Comments\": \"noteworthy note\",    \"Active\": true  }}", 
                    TestHelper.ConvertStreamToString(httpCallBackHandler.Response.RawBody),
                    "Response body should match exactly (string literal match)");
        }

    }
}