/*
 * BouncerAPI.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using BouncerAPI.Standard;
using BouncerAPI.Standard.Utilities;
using BouncerAPI.Standard.Http.Request;
using BouncerAPI.Standard.Http.Response;
using BouncerAPI.Standard.Http.Client;
using BouncerAPI.Standard.Exceptions;

namespace BouncerAPI.Standard.Controllers
{
    public partial class WhitelistGeoLocationsController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static WhitelistGeoLocationsController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static WhitelistGeoLocationsController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new WhitelistGeoLocationsController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Remove a Geo Location in the Whitelist
        /// </summary>
        /// <param name="entryId">Required parameter: a unique identifier for the Geo Location; opaque but likely a GUID</param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.RemoveResponse1 response from the API call</return>
        public Models.RemoveResponse1 Remove(string entryId, Models.GeoLocation body)
        {
            Task<Models.RemoveResponse1> t = RemoveAsync(entryId, body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Remove a Geo Location in the Whitelist
        /// </summary>
        /// <param name="entryId">Required parameter: a unique identifier for the Geo Location; opaque but likely a GUID</param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.RemoveResponse1 response from the API call</return>
        public async Task<Models.RemoveResponse1> RemoveAsync(string entryId, Models.GeoLocation body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1.1/whitelists/geolocations/{entry_id}/delete");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "entry_id", entryId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.DeleteBody(_queryUrl, _headers, _body);

            //Custom Authentication to be added for authorization
            AuthUtility.AppendCustomAuthParams(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ReturnException(@"Unexpected error in API call. See HTTP response body for details.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.RemoveResponse1>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Update a Geo Location in the Whitelist
        /// </summary>
        /// <param name="entryId">Required parameter: a unique identifier for the Geo Location; opaque but likely a GUID</param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.UpdateResponse1 response from the API call</return>
        public Models.UpdateResponse1 Update(string entryId, Models.GeoLocation body)
        {
            Task<Models.UpdateResponse1> t = UpdateAsync(entryId, body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Update a Geo Location in the Whitelist
        /// </summary>
        /// <param name="entryId">Required parameter: a unique identifier for the Geo Location; opaque but likely a GUID</param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.UpdateResponse1 response from the API call</return>
        public async Task<Models.UpdateResponse1> UpdateAsync(string entryId, Models.GeoLocation body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1.1/whitelists/geolocations/{entry_id}/update");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "entry_id", entryId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PutBody(_queryUrl, _headers, _body);

            //Custom Authentication to be added for authorization
            AuthUtility.AppendCustomAuthParams(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ReturnException(@"Unexpected error in API call. See HTTP response body for details.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.UpdateResponse1>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Create a Geo Location in the Whitelist. When POSTed-to this endpoint, Bouncer scans `geolist.txt` for any IPs matching the Country Code (CC) in the POSTed object and, for each: Bouncer will create a new ipaddress in this list (black- or white-list).
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.CreateResponse1 response from the API call</return>
        public Models.CreateResponse1 Create(Models.GeoLocation body)
        {
            Task<Models.CreateResponse1> t = CreateAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Create a Geo Location in the Whitelist. When POSTed-to this endpoint, Bouncer scans `geolist.txt` for any IPs matching the Country Code (CC) in the POSTed object and, for each: Bouncer will create a new ipaddress in this list (black- or white-list).
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.CreateResponse1 response from the API call</return>
        public async Task<Models.CreateResponse1> CreateAsync(Models.GeoLocation body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1.1/whitelists/geolocations/create");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            //Custom Authentication to be added for authorization
            AuthUtility.AppendCustomAuthParams(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ReturnException(@"Unexpected error in API call. See HTTP response body for details.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.CreateResponse1>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get Details of a Geo Location Entry in the Whitelist
        /// </summary>
        /// <param name="entryId">Required parameter: a unique identifier for the Geo Location; opaque but likely a GUID</param>
        /// <return>Returns the Models.GetDetailsResponse1 response from the API call</return>
        public Models.GetDetailsResponse1 GetDetails(string entryId)
        {
            Task<Models.GetDetailsResponse1> t = GetDetailsAsync(entryId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get Details of a Geo Location Entry in the Whitelist
        /// </summary>
        /// <param name="entryId">Required parameter: a unique identifier for the Geo Location; opaque but likely a GUID</param>
        /// <return>Returns the Models.GetDetailsResponse1 response from the API call</return>
        public async Task<Models.GetDetailsResponse1> GetDetailsAsync(string entryId)
        {
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1.1/whitelists/geolocations/{entry_id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "entry_id", entryId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers);

            //Custom Authentication to be added for authorization
            AuthUtility.AppendCustomAuthParams(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ReturnException(@"Unexpected error in API call. See HTTP response body for details.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.GetDetailsResponse1>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// List all Geo Locations in the Whitelist
        /// </summary>
        /// <return>Returns the Models.ListResponse1 response from the API call</return>
        public Models.ListResponse1 List()
        {
            Task<Models.ListResponse1> t = ListAsync();
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// List all Geo Locations in the Whitelist
        /// </summary>
        /// <return>Returns the Models.ListResponse1 response from the API call</return>
        public async Task<Models.ListResponse1> ListAsync()
        {
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1.1/whitelists/geolocations");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers);

            //Custom Authentication to be added for authorization
            AuthUtility.AppendCustomAuthParams(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ReturnException(@"Unexpected error in API call. See HTTP response body for details.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.ListResponse1>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
} 