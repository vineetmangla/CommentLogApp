using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentLog.DomainModel
{
    public class Comments:BaseEntity
    {
        [Key]
        public int ComId { get; set; }        
        public string CommentMsg { get; set; }
        public DateTime CommentedDate { get; set; }
        public int UserId { get; set; }
    }
}
