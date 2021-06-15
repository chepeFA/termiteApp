using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using termiteApp.Core.AuxClasses;

//using Microsoft.AspNetCore.Mvc;

namespace termiteApp.Core.Domain
{
    public class Inspector
    {
        
        public int inpId { get; set; }
        public string inpName { get; set; }
        public string inpLastName { get; set; }
        public bool inpSex { get; set; }
        public DateTime inpDob { get; set; }
        public string inpLicenseNumber { get; set; }

        // ByteArrayConverter b = new ByteArrayConverter();

        [JsonConverter(typeof(ByteArrayConverter))]
        public byte[] inpSignature { get; set; }
        
    }

    }

