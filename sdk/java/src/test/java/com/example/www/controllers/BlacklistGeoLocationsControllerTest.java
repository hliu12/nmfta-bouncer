/*
 * BouncerAPILib
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
package com.example.www.controllers;

import static org.junit.Assert.*;

import java.io.*;
import java.util.*;

import org.junit.AfterClass;
import org.junit.BeforeClass;
import org.junit.Test;

import com.example.www.models.*;
import com.example.www.exceptions.*;
import com.example.www.APIHelper;
import com.example.www.Configuration;
import com.example.www.testing.TestHelper;
import com.example.www.controllers.BlacklistGeoLocationsController;

import com.fasterxml.jackson.core.type.TypeReference;

public class BlacklistGeoLocationsControllerTest extends ControllerTestBase {
    
    /**
     * Controller instance (for all tests)
     */
    private static BlacklistGeoLocationsController controller;
    
    /**
     * Setup test class
     */
    @BeforeClass
    public static void setUpClass() {
        controller = getClient().getBlacklistGeoLocations();
    }

    /**
     * Tear down test class
     * @throws IOException
     */
    @AfterClass
    public static void tearDownClass() throws IOException {
        controller = null;
    }

    /**
     * List all Geo Locations in the Blacklist
     * @throws Throwable
     */
    @Test
    public void testList1() throws Throwable {

        // Set callback and perform API call
        ListResponse1 result = null;
        controller.setHttpCallBack(httpResponse);
        try {
            result = controller.list();
        } catch(APIException e) {};

       // Test whether the response is null
        assertNotNull("Response is null", 
                httpResponse.getResponse());
        // Test response code
        assertEquals("Status is not 200", 
                200, httpResponse.getResponse().getStatusCode());

        // Test headers
        Map<String, String> headers = new LinkedHashMap<String, String>();
        headers.put("Content-Type", TestHelper.nullString);
        
        assertTrue("Headers do not match", TestHelper.areHeadersProperSubsetOf(
                headers, httpResponse.getResponse().getHeaders(), true));

        // Test whether the captured response is as we expected
        assertNotNull("Result does not exist", 
                result);
        assertEquals("Response body does not match exactly",
                "{  \"Result\": {    \"Status\": \"Success\",    \"Message\": \"\"  },  \"GeoLocations\": [    \"884d9804999fc47a3c2694e49ad2536a#CA\"  ]}", 
                TestHelper.convertStreamToString(httpResponse.getResponse().getRawBody()));
    }

    /**
     * Get Details of a Geo Location Entry in the Blacklist
     * @throws Throwable
     */
    @Test
    public void testGetDetails1() throws Throwable {
        // Parameters for the API call
        String entryId = "884d9804999fc47a3c2694e49ad2536a";

        // Set callback and perform API call
        GetDetailsResponse1 result = null;
        controller.setHttpCallBack(httpResponse);
        try {
            result = controller.getDetails(entryId);
        } catch(APIException e) {};

       // Test whether the response is null
        assertNotNull("Response is null", 
                httpResponse.getResponse());
        // Test response code
        assertEquals("Status is not 200", 
                200, httpResponse.getResponse().getStatusCode());

        // Test headers
        Map<String, String> headers = new LinkedHashMap<String, String>();
        headers.put("Content-Type", TestHelper.nullString);
        
        assertTrue("Headers do not match", TestHelper.areHeadersProperSubsetOf(
                headers, httpResponse.getResponse().getHeaders(), true));

        // Test whether the captured response is as we expected
        assertNotNull("Result does not exist", 
                result);
        assertEquals("Response body does not match exactly",
                "{  \"Result\": {    \"Status\": \"Success\",    \"Message\": \"\"  },  \"Entry\": {    \"Country Code\": \"CA\",    \"Start_Date\": \"2019-04-05T02:04:16Z\",    \"End_Date\": \"2019-04-05T02:04:16Z\",    \"Comments\": \"noteworthy note\",    \"Active\": true  }}", 
                TestHelper.convertStreamToString(httpResponse.getResponse().getRawBody()));
    }

}
