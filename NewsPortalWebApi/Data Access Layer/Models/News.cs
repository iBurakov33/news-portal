using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsPortalWebApi.Data;

namespace NewsPortalWebApi
{
    public class News 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] NewsImage { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public bool Relevancy { get; set; }
    }
}
