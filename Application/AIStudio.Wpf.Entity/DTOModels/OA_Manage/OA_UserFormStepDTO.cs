using AIStudio.Core.Models;
using AIStudio.Wpf.Entity.Models;

namespace AIStudio.Wpf.Entity.DTOModels
{
    public class OA_UserFormStepDTO : OA_UserFormStep
    {
        public string Avatar { get; set; }

        public override string ToString()
        {
            return Id + "-" + CreatorName;
        }
    }
}
