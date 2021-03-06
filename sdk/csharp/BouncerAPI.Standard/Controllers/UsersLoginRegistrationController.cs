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
    public partial class UsersLoginRegistrationController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static UsersLoginRegistrationController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static UsersLoginRegistrationController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new UsersLoginRegistrationController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Authenticate to this Bouncer instance.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.LoginToBouncerAPIResponse response from the API call</return>
        public Models.LoginToBouncerAPIResponse LoginToBouncerAPI(Models.LoginToBouncerAPIRequest body)
        {
            Task<Models.LoginToBouncerAPIResponse> t = LoginToBouncerAPIAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Authenticate to this Bouncer instance.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.LoginToBouncerAPIResponse response from the API call</return>
        public async Task<Models.LoginToBouncerAPIResponse> LoginToBouncerAPIAsync(Models.LoginToBouncerAPIRequest body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1.1/login");


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
                return APIHelper.JsonDeserialize<Models.LoginToBouncerAPIResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// ONLY AVAILABLE when Bouncer is started with the `--testing` parameter.
        /// Register a new user with this instance of Bouncer.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.RegisterNewUserResponse response from the API call</return>
        public Models.RegisterNewUserResponse RegisterNewUser(Models.RegisterNewUserRequest body)
        {
            Task<Models.RegisterNewUserResponse> t = RegisterNewUserAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// ONLY AVAILABLE when Bouncer is started with the `--testing` parameter.
        /// Register a new user with this instance of Bouncer.
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.RegisterNewUserResponse response from the API call</return>
        public async Task<Models.RegisterNewUserResponse> RegisterNewUserAsync(Models.RegisterNewUserRequest body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1.1/register");


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
                return APIHelper.JsonDeserialize<Models.RegisterNewUserResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
} 