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
    public class RemoveResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private Models.Result6 result;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Result")]
        public Models.Result6 Result 
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
    }
} 