using System;
using System.Collections.Generic;
using System.Text;

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
        public byte[] inpSignature { get; set; }


    }
}
