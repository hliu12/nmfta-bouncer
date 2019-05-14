/*
 * BouncerAPILib
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
package com.example.www.models;

import java.util.*;
import com.fasterxml.jackson.annotation.JsonGetter;
import com.fasterxml.jackson.annotation.JsonSetter;
import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonInclude.Include;

@JsonInclude(Include.ALWAYS)
public class GetDetailsResponse1 
        implements java.io.Serializable {
    private static final long serialVersionUID = -7265035448819549004L;
    private Result result;
    private GeoLocation entry;
    /** GETTER
     * TODO: Write general description for this method
     */
    @JsonGetter("Result")
    public Result getResult ( ) { 
        return this.result;
    }
    
    /** SETTER
     * TODO: Write general description for this method
     */
    @JsonSetter("Result")
    public void setResult (Result value) { 
        this.result = value;
    }
 
    /** GETTER
     * The geolocation information referenced by Bouncer when building `ufw` rules
     */
    @JsonGetter("Entry")
    public GeoLocation getEntry ( ) { 
        return this.entry;
    }
    
    /** SETTER
     * The geolocation information referenced by Bouncer when building `ufw` rules
     */
    @JsonSetter("Entry")
    public void setEntry (GeoLocation value) { 
        this.entry = value;
    }
 
}
