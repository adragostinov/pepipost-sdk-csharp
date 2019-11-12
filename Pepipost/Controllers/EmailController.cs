/*
 * Pepipost
 *
 * This file was semi-automatically generated by APIMATIC v2.0 ( https://apimatic.io )
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
using Pepipost;
using Pepipost.Utilities;
using Pepipost.Http.Request;
using Pepipost.Http.Response;
using Pepipost.Http.Client;
using Pepipost.Exceptions;

namespace Pepipost.Controllers
{
    public partial class EmailController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static EmailController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static EmailController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new EmailController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// This Endpoint sends emails with the credentials passed.
        /// </summary>
        /// <param name="apiKey">Optional parameter: Generated header parameter. Example value ='5ce7096ed4bf2b39dfa932ff5fa84ed9ed8'</param>
        /// <param name="body">Optional parameter: The body passed will be json format.</param>
        /// <return>Returns the Models.SendEmailResponse response from the API call</return>
        public Models.SendEmailResponse CreateSendEmail(string apiKey = null, Models.EmailBody body = null, string url = null)
        {
            Task<Models.SendEmailResponse> t = CreateSendEmailAsync(apiKey, body, url);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This Endpoint sends emails with the credentials passed.
        /// </summary>
        /// <param name="apiKey">Optional parameter: Generated header parameter. Example value ='5ce7096ed4bf2b39dfa932ff5fa84ed9ed8'</param>
        /// <param name="body">Optional parameter: The body passed will be json format.</param>
        /// <return>Returns the Models.SendEmailResponse response from the API call</return>
        public async Task<Models.SendEmailResponse> CreateSendEmailAsync(string apiKey = null, Models.EmailBody body = null, string url = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(url))
            {
                _queryBuilder.Append(_baseUri + "/v2/sendEmail");
            }
            else
            {
                _queryBuilder.Append(url);
            }

            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "pepi-sdk-csharp v2" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "api_key", apiKey }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 405)
                throw new APIException(@"Method not allowed", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.SendEmailResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
} 
