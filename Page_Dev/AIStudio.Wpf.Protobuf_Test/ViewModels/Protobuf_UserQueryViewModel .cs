using AIStudio.Wpf.Protobuf_Test.Models;

namespace AIStudio.Wpf.Protobuf_Test.ViewModels
{
    class Protobuf_UserQueryViewModel : Protobuf_QueryViewModel<Protobuf_UserDTO, Protobuf_UserDTO_Query>
    {
        public Protobuf_UserQueryViewModel() : base("Protobuf_Test", typeof(Protobuf_UserQueryEditViewModel))
        {

        }

    }
}
