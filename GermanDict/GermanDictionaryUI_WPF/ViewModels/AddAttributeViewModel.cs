
using GermanDict.Interfaces;

namespace GermanDict.UI.ViewModels
{
    public class AddAttributeViewModel : WordHandlerViewModel
    {
        public AddAttributeViewModel()
        {
        }

        public AddAttributeViewModel(IRepository<IDictionaryItem> repository)
            : base(repository)
        {
            Name = "AddAttribute";
        }

        public override WordType WordType => WordType.Attribute;
    }
}
