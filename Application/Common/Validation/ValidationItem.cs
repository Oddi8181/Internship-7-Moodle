namespace Application.Common.Validation
{
    public class ValidationItem
    {
        public ValidationSeverity ValidationSeverity {get; set;}
        public string Message {get; set; }
        public string Code {get; set; }

        public ValidationItem()
        {
            
        }
    }
}
