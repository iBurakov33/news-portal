using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortalWebApi.Business_Logic_Layer.DTO
{
    public class NewsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] NewsImage { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
