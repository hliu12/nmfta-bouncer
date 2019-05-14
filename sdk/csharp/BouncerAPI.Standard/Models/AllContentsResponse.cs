/*
 * BouncerAPI.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BouncerAPI.Standard;
using BouncerAPI.Standard.Utilities;


namespace BouncerAPI.Standard.Models
{
    public class AllContentsResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private Models.Result result;
        private List<string> iPAddresses;
        private List<string> geoLocations;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Result")]
        public Models.Result Result 
        { 
            get 
            {
                return this.result; 
            } 
            set 
            {
                this.result = value;
                onPropertyChanged("Result");
            }
        }

        /// <summary>
        /// matching IP Address Objects found
        /// </summary>
        [JsonProperty("IPAddresses")]
        public List<string> IPAddresses 
        { 
            get 
            {
                return this.iPAddresses; 
            } 
            set 
            {
                this.iPAddresses = value;
                onPropertyChanged("IPAddresses");
            }
        }

        /// <summary>
        /// matching Geo Location Objects (in short string form `{id}#{cc}`) found
        /// </summary>
        [JsonProperty("GeoLocations")]
        public List<string> GeoLocations 
        { 
            get 
            {
                return this.geoLocations; 
            } 
            set 
            {
                this.geoLocations = value;
                onPropertyChanged("GeoLocations");
            }
        }
    }
} 