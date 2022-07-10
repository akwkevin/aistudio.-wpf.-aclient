using AIStudio.Wpf.Agile_Development.Commons;
using AIStudio.Wpf.Agile_Development.Models;
using AIStudio.Wpf.Agile_Development.Views;

namespace AIStudio.Wpf.Agile_Development.ViewModels
{
    class Protobuf_UserQueryViewModel : Protobuf_QueryViewModel<Protobuf_UserDTO, Protobuf_UserDTO_Query>
    {
        public Protobuf_UserQueryViewModel() : base("Protobuf_Test", typeof(Protobuf_UserQueryEditViewModel))
        {

        }

    }
}
