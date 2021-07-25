using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public interface IHomeBusiness
    {
        Task<string> SubmitLoginAsync(LoginInputDTO input);
        Task ChangePwdAsync(ChangePwdInputDTO input);
        Task<object> GetOperatorInfoAsync();
        Task<List<Base_ActionDTO>> GetOperatorMenuListAsync();
    }

    public class LoginInputDTO
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }
    }

    public class ChangePwdInputDTO
    {
        [Required]
        public string oldPwd { get; set; }

        [Required]
        public string newPwd { get; set; }
    }
}
