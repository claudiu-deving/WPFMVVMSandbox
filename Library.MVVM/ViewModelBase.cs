#nullable enable

namespace Library.MVVM;

public class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
{
    private readonly IValidationService _validator;
    private readonly IRuleValidationFactory _ruleValidationFactory;
    private readonly IErrorManager _errorManager;
    private readonly Dictionary<string, object?> _fields = [];

    public Dictionary<string, List<IValidationRule>> ValidationRules { get; } = [];

    public bool HasErrors => _errorManager.HasErrors;

    protected IFactory CommandFactory { get; }

    public ViewModelBase(
        IRuleValidationFactory? ruleValidationFactory = null,
        IErrorManager? errorManager = null,
        IValidationService? validator = null
       )
    {
        _errorManager = errorManager ?? new ErrorManager();
        _validator = validator ?? new ValidationService(_errorManager);
        CommandFactory = new CommandFactory();
        _ruleValidationFactory = ruleValidationFactory ?? new RuleValidationFactory();
        PopulateValidationRules();
        _errorManager.ErrorsChanged += ViewModelBase_ErrorsChanged;
    }


    private void ViewModelBase_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
    {
        var properties = GetType().GetProperties();
        if (!properties.Any()) return;
        foreach (var property in properties)
        {
            if (property.PropertyType == typeof(CommandBase))
            {
                var command = (CommandBase)property.GetValue(this);
                command.RaiseCanExecuteChanged();
            }
        }
    }

    private void PopulateValidationRules()
    {
        var properties = GetType().GetProperties();
        if (!properties.Any()) return;
        foreach (var property in properties)
        {
            _fields.Add(property.Name, null);
            var attributes = property.GetCustomAttributes(true);
            PopulateValidationRules(property, attributes);
        }


        void PopulateValidationRules(PropertyInfo property, object[] attributes)
        {

            foreach (var rule in from attribute in attributes
                                 where attribute is ValidationAttribute
                                 let rule = _ruleValidationFactory.GetValidationRule((Attribute)attribute)
                                 select rule)
            {
                if (!ValidationRules.ContainsKey(property.Name))
                    ValidationRules[property.Name] = [];
                ValidationRules[property.Name].Add(rule);
            }
        }
    }



    /// <summary>
    /// Event that is fired when a property is changed
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    /// <summary>
    /// Method that is called when a property is changed
    /// </summary>
    /// <param name="propertyName">The name of the parameter, leave empty when the caller is property's setter.</param>
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(T value, [CallerMemberName] string propertyName = "")
    {
        var backingField = _fields[propertyName];
        // Check if the value has changed
        if (backingField?.Equals(value) ?? false) return false;

        // Set the new value
        _fields[propertyName] = value;

        // Perform validation
        ValidationRules.TryGetValue(propertyName, out List<IValidationRule> rules);
        _validator.Validate(propertyName, value, rules);

        // Notify property change
        OnPropertyChanged(propertyName);

        return true;
    }

    protected T? GetProperty<T>([CallerMemberName] string propertyName = "")
    {
        if (_fields.TryGetValue(propertyName, out var value))
        {
            if (value is null)
            {
                return default;
            }
            return (T?)value;
        }
        return default;
    }

    public IEnumerable? GetErrors(string propertyName)
    {
        return _errorManager.GetErrors(propertyName);
    }
}