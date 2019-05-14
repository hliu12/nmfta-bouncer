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
public class AllContentsResponse 
        implements java.io.Serializable {
    private static final long serialVersionUID = 7083110882655980769L;
    private Result result;
    private List<String> iPAddresses;
    private List<String> geoLocations;
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
     * matching IP Address Objects found
     */
    @JsonGetter("IPAddresses")
    public List<String> getIPAddresses ( ) { 
        return this.iPAddresses;
    }
    
    /** SETTER
     * matching IP Address Objects found
     */
    @JsonSetter("IPAddresses")
    public void setIPAddresses (List<String> value) { 
        this.iPAddresses = value;
    }
 
    /** GETTER
     * matching Geo Location Objects (in short string form `{id}#{cc}`) found
     */
    @JsonGetter("GeoLocations")
    public List<String> getGeoLocations ( ) { 
        return this.geoLocations;
    }
    
    /** SETTER
     * matching Geo Location Objects (in short string form `{id}#{cc}`) found
     */
    @JsonSetter("GeoLocations")
    public void setGeoLocations (List<String> value) { 
        this.geoLocations = value;
    }
 
}
