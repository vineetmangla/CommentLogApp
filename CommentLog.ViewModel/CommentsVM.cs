using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentLog.ViewModel
{
    public class CommentsVM
    {
        public int ComId { get; set; }

        [Required(ErrorMessage = "Comment is required ")]     
        [MaxLength(200)]   
        public string CommentMsg { get; set; }       
        public DateTime CommentDate { get; set; }
        public int UserId { get; set; }
    }
}
