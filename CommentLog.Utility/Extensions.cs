using CommentLog.DomainModel;
using CommentLog.DTO;
using CommentLog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentLog.Utility;
using System.Web;

namespace CommentLog.Utility
{
    public static class Extensions
    {
        public static UsersDTO ToDTO(this UsersVM vm)
        {
            UsersDTO dto = new UsersDTO();
            dto.Email = vm.Email;
            dto.Name = vm.Name;
            dto.Password = CustomEncrypt.Encrypt(vm.Password);
            return dto;
        }

        public static Users ToDomainModel(this UsersDTO dto)
        {
            Users model = new Users();
            model.Email = dto.Email;
            model.Name = dto.Name;
            model.Password = dto.Password;
            return model;
        }


        public static UsersDTO ToDto(this Users model)
        {
            UsersDTO dto = new UsersDTO();
            dto.Id = model.Id;
            dto.Email = model.Email;
            dto.Name = model.Name;
            dto.Password = CustomDecrypt.Decrypt(model.Password);
            return dto;
        }

        public static CommentsDTO ToDTO(this CommentsVM vm)
        {
            CommentsDTO dto = new CommentsDTO();
            dto.CommentDate = vm.CommentDate;
            dto.CommentMsg = vm.CommentMsg;
            dto.UserId = vm.UserId;
            return dto;
        }

        public static Comments ToDomainModel(this CommentsDTO dto)
        {
            Comments model = new Comments();
            model.CommentedDate = dto.CommentDate;
            model.CommentMsg = dto.CommentMsg;
            model.UserId = dto.UserId;
            return model;
        }


        public static CommentsDTO ToDto(this Comments model)
        {
            CommentsDTO dto = new CommentsDTO();
            dto.ComId = model.ComId;
            dto.CommentDate = model.CommentedDate;
            dto.CommentMsg = model.CommentMsg;
            dto.UserId = model.UserId;
            return dto;
        }

        public static List<CommentsDTO> ToDto(this List<Comments> models)
        {
            List<CommentsDTO> dtos = new List<CommentsDTO>();
            foreach(var model in models)
            {
                dtos.Add(model.ToDto());
            }
            return dtos;
        }

        public static CommentsVM ToViewModel(this CommentsDTO dto)
        {
            CommentsVM vm = new CommentsVM();
            vm.ComId = dto.ComId;
            vm.CommentDate = dto.CommentDate;
            vm.CommentMsg = dto.CommentMsg;
            vm.UserId = dto.UserId;
            return vm;
        }

        public static List<CommentsVM> ToViewModel(this List<CommentsDTO> dtos)
        {
            List<CommentsVM> vms = new List<CommentsVM>();
            foreach (var dto in dtos)
            {
                vms.Add(dto.ToViewModel());
            }
            return vms;
        }


    }
}
