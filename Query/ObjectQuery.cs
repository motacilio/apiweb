using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiweb.Query
{
    public class ObjectQuery
    {
        public string? nome {get;set;} = null;
        public int? idade {get;set;}
        public string? sortBy {get;set;} = null;
        public bool isDescending {get;set;}

        public int pageNumber {get;set;} = 1;
        public int pageSize {get;set;} = 20;
    }
}