/*
 * BouncerAPILib
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
package com.example.www.models;

import java.util.*;

public class UpdateResponse1Builder {
    //the instance to build
    private UpdateResponse1 updateResponse1;

    /**
     * Default constructor to initialize the instance
     */
    public UpdateResponse1Builder() {
        updateResponse1 = new UpdateResponse1();
    }

    public UpdateResponse1Builder result(Result10 result) {
        updateResponse1.setResult(result);
        return this;
    }
    /**
     * Build the instance with the given values
     */
    public UpdateResponse1 build() {
        return updateResponse1;
    }
}