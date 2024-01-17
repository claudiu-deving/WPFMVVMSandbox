using Library.MVVM;


namespace WPFMVVMSandbox.ViewModel;

public class ProductViewModel : ViewModelBase
{
    public ProductViewModel()
    {
    }

    private CommandBase? _saveCommand;
    #region Properties
    public DateTime CreatedDate { get => GetProperty<DateTime>(); set => SetProperty(value); }

    [IsNotEmpty]
    public string? Description { get => GetProperty<string?>(); set => SetProperty(value); }

    public int Id { get => GetProperty<int>(); set => SetProperty(value); }

    public string? Image { get => GetProperty<string?>(); set => SetProperty(value); }

    [IsNotEmpty]
    public string? Name { get => GetProperty<string>(); set => SetProperty(value); }
    [IsNotEmpty]
    public decimal Price { get => GetProperty<decimal>(); set => SetProperty(value); }
    [IsNotEmpty]
    public int Quantity { get => GetProperty<int>(); set => SetProperty(value); }

    [DateLater]
    public DateTime? UpdatedDate { get => GetProperty<DateTime?>(); set => SetProperty(value); }

    public CommandBase SaveCommand { get => _saveCommand ??= CommandFactory.Create(ExecuteSave, CanExecuteSave); }

    private bool CanExecuteSave(object arg)
    {
        return !HasErrors;
    }

    private void ExecuteSave(object obj)
    {
        Console.WriteLine("Saved");
    }
    #endregion Properties
}
