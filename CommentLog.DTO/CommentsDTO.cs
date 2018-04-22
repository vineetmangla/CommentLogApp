using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentLog.DTO
{
    public class CommentsDTO
    {
        public int ComId { get; set; }        
        public string CommentMsg { get; set; }
        public DateTime CommentDate { get; set; }
        public int UserId { get; set; }
    }
}
