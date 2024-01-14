using WPFMVVMSandbox.ViewModel.Utilities;

namespace WPFMVVMSandbox.ViewModel;



public class ProductViewModel : ViewModelBase
{

    #region Public Properties

    public DateTime CreatedDate
    {
        get => _createdDate;
        set
        {
            _createdDate = value;
            //The error would come from a validator
            ErrorManager.AddErrors(new List<string> { "Created Date cannot be changed" });
            OnPropertyChanged();
        }
    }

    public string? Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged();
        }
    }

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged();
        }
    }

    public string? Image
    {
        get => _image;
        set
        {
            _image = value;
            OnPropertyChanged();
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged();
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged();
        }
    }

    public DateTime? UpdatedDate
    {
        get => _updatedDate;
        set
        {
            _updatedDate = value;
            OnPropertyChanged();
        }
    }


    #endregion Public Properties

    #region Private Methods

    #endregion Private Methods

    #region Private Fields

    private DateTime _createdDate;

    private string? _description;

    //Represents the viewmodel object for the Product object
    private int _id;
    private string? _image;
    private string _name = string.Empty;
    private decimal _price;
    private int _quantity;
    private DateTime? _updatedDate;

    #endregion Private Fields
}
