namespace Assignments.Services.ValidateStrategies
{
	/// <summary>
	/// context for strategy pattern
	/// </summary>
	public class ValidateContext
	{
		private readonly IValidator _validator;

		 public ValidateContext(IValidator validator)
		 {
			 _validator = validator;
		 }

		public bool IsValid(string data)
		{
			return _validator.IsValid(data);
		}
	}
}