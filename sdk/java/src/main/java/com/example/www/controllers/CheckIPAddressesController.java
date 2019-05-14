/*
 * BouncerAPILib
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
package com.example.www.controllers;

import java.io.*;
import java.util.*;
import java.util.concurrent.*;
import com.fasterxml.jackson.core.type.TypeReference;

import com.example.www.*;
import com.example.www.models.*;
import com.example.www.exceptions.*;
import com.example.www.http.client.HttpClient;
import com.example.www.http.client.HttpContext;
import com.example.www.http.request.HttpRequest;
import com.example.www.http.response.HttpResponse;
import com.example.www.http.response.HttpStringResponse;
import com.example.www.http.client.APICallBack;
import com.example.www.controllers.syncwrapper.APICallBackCatcher;

public class CheckIPAddressesController extends BaseController {
    //private static variables for the singleton pattern
    private static final Object syncObject = new Object();
    private static CheckIPAddressesController instance = null;

    /**
     * Singleton pattern implementation 
     * @return The singleton instance of the CheckIPAddressesController class 
     */
    public static CheckIPAddressesController getInstance() {
        if (null == instance) {
            synchronized (syncObject) {
                if (null == instance) {
                    instance = new CheckIPAddressesController();
                }
            }
        }
        return instance;
    }

    /**
     * Check if an IP Address is Already White- or Black-Listed
     * @param    ipAddress    Required parameter: the IP address to check
     * @return    Returns the TestForListMembershipResponse response from the API call 
     */
    public TestForListMembershipResponse testForListMembership(
                final String ipAddress
    ) throws Throwable {

        HttpRequest _request = _buildTestForListMembershipRequest(ipAddress);
        HttpResponse _response = getClientInstance().executeAsString(_request);
        HttpContext _context = new HttpContext(_request, _response);

        return _handleTestForListMembershipResponse(_context);
    }

    /**
     * Check if an IP Address is Already White- or Black-Listed
     * @param    ipAddress    Required parameter: the IP address to check
     * @return    Returns the void response from the API call 
     */
    public void testForListMembershipAsync(
                final String ipAddress,
                final APICallBack<TestForListMembershipResponse> callBack
    ) {
        Runnable _responseTask = new Runnable() {
            public void run() {

                HttpRequest _request;
                try {
                    _request = _buildTestForListMembershipRequest(ipAddress);
                } catch (Exception e) {
                    callBack.onFailure(null, e);
                    return;
                }

                // Invoke request and get response
                getClientInstance().executeAsStringAsync(_request, new APICallBack<HttpResponse>() {
                    public void onSuccess(HttpContext _context, HttpResponse _response) {
                        try {
                            TestForListMembershipResponse returnValue = _handleTestForListMembershipResponse(_context);
                            callBack.onSuccess(_context, returnValue);
                        } catch (Exception e) {
                            callBack.onFailure(_context, e);
                        }
                    }

                    public void onFailure(HttpContext _context, Throwable _exception) {
                        // Let the caller know of the failure
                        callBack.onFailure(_context, _exception);
                    }
                });
            }
        };

        // Execute async using thread pool
        APIHelper.getScheduler().execute(_responseTask);
    }

    /**
     * Builds the HttpRequest object for testForListMembership
     */
    private HttpRequest _buildTestForListMembershipRequest(
                final String ipAddress) throws IOException, APIException {
        //the base uri for api requests
        String _baseUri = Configuration.getBaseUri();

        //prepare query string for API call
        StringBuilder _queryBuilder = new StringBuilder(_baseUri + "/v1.1/check/{ip_address}");

        //process template parameters
        Map<String, Object> _templateParameters = new HashMap<String, Object>();
        _templateParameters.put("ip_address", ipAddress);
        APIHelper.appendUrlWithTemplateParameters(_queryBuilder, _templateParameters);
        //validate and preprocess url
        String _queryUrl = APIHelper.cleanUrl(_queryBuilder);

        //load all headers for the outgoing API request
        Map<String, String> _headers = new HashMap<String, String>();
        _headers.put("user-agent", BaseController.userAgent);
        _headers.put("accept", "application/json");


        //prepare and invoke the API call request to fetch the response
        HttpRequest _request = getClientInstance().get(_queryUrl, _headers, null);

        // Invoke the callback before request if its not null
        if (getHttpCallBack() != null) {
            getHttpCallBack().OnBeforeRequest(_request);
        }

        // Custom Authentication to be added for authorization
        CustomAuthUtility.appendCustomAuthParams(_request);

        return _request;
    }

    /**
     * Processes the response for testForListMembership
     * @return An object of type void
     */
    private TestForListMembershipResponse _handleTestForListMembershipResponse(HttpContext _context)
            throws APIException, IOException {
        HttpResponse _response = _context.getResponse();

        //invoke the callback after response if its not null
        if (getHttpCallBack() != null) {
            getHttpCallBack().OnAfterResponse(_context);
        }

        //Error handling using HTTP status codes
        int _responseCode = _response.getStatusCode();

        if (_responseCode == 400) {
            throw new ReturnException("Unexpected error in API call. See HTTP response body for details.", _context);
        }
        //handle errors defined at the API level
        validateResponse(_response, _context);

        //extract result from the http response
        String _responseBody = ((HttpStringResponse)_response).getBody();
        TestForListMembershipResponse _result = APIHelper.deserialize(_responseBody,
                                                        new TypeReference<TestForListMembershipResponse>(){});

        return _result;
    }

}
