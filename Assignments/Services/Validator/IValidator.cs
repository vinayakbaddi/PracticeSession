namespace Assignments.Services.Validator
{
	/// <summary>
	/// Interface for validation strategy
	/// </summary>
	public interface IValidator
	{
		bool IsValid(string candidate);
	}
}