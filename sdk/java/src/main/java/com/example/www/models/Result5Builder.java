/*
 * BouncerAPILib
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
package com.example.www.models;

import java.util.*;

public class Result5Builder {
    //the instance to build
    private Result5 result5;

    /**
     * Default constructor to initialize the instance
     */
    public Result5Builder() {
        result5 = new Result5();
    }

    public Result5Builder status(String status) {
        result5.setStatus(status);
        return this;
    }

    /**
     * an optional message
     */
    public Result5Builder message(String message) {
        result5.setMessage(message);
        return this;
    }

    /**
     * a unique identifier for the newly updated IP Address; opaque but likely a GUID
     */
    public Result5Builder entryID(String entryID) {
        result5.setEntryID(entryID);
        return this;
    }
    /**
     * Build the instance with the given values
     */
    public Result5 build() {
        return result5;
    }
}