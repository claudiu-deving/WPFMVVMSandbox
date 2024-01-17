using System.Collections.ObjectModel;

using Library.MVVM;

namespace WPFMVVMSandbox.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Products =
            [
                new ProductViewModel()
                {
                    Id = 1,
                    Name = "Product 1",
                    Description = "Description 1",
                    Price = 1.99m,
                    Image = "https://via.placeholder.com/150",
                    UpdatedDate = DateTime.Now,
                    CreatedDate = DateTime.Now
                }
            ];
        }
        public ObservableCollection<ProductViewModel> Products { get; }
    }
}
