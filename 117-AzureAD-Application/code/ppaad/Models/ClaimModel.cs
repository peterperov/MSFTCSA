using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_OpenIDConnect_DotNet.Models
{
    public class ClaimModel
    {

        public string Title { get; set; }

        public Dictionary<string, string> Claims { get; set; }

    }
}
