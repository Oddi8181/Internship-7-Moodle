namespace Application.Common.Validation
{
    public class ValidationResult
    {
        private List<ValidationItem> _validationItems { get; set; } = new List<ValidationItem>();
        public IReadOnlyList<ValidationItem> ValidationItems() => _validationItems;

        public bool HasErrors => _validationItems.Any(v => v.ValidationSeverity == ValidationSeverity.Error);

        public void AddValidationItem(ValidationItem item)
        {
            _validationItems.Add(item);
        }

        public ValidationResult()
        {
            
        }
    }
}
