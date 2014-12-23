using Assignments.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assignments.Services.ValidateStrategies
{
	/// <summary>
	/// concrete strategy
	/// </summary>
	public class RawTitle : IValidator
	{
		public bool IsValid(string candidate)
		{
			string candidateTrim = candidate.Trim();
			bool? isValidWithLightning = IsValidWithLightning(candidateTrim);


			if(isValidWithLightning.HasValue) return isValidWithLightning.Value;

			if (!HasOnlyOneNumberSet(candidateTrim)) return false;

			return IsValidPosition(candidateTrim);
		}

		/// <summary>
		/// IF this has lightning, then there should exist no other digits
		/// </summary>
		/// <param name="candidate">The candidate.</param>
		/// <returns>null if inconclusive</returns>
		private bool? IsValidWithLightning(string candidate)
		{
			if(candidate.ToUpper().EndsWith(Settings.Default.TalkTimeKeyword))
			{
				return !candidate.Any(Char.IsDigit);
			}

			return null;
		}

		private bool HasOnlyOneNumberSet(string candidate)
		{
			int[] ints =  Regex.Matches(candidate, @"\d").Cast<Match>().Select(m => m.Index).ToArray();
			return ints.Length - 1 == ints.Last() - ints.First();
		}

		/// <summary>
		/// If there is a number, we need to make sure it is at the end and not mixed in the title
		/// </summary>
		/// <param name="candidate">The candidate.</param>
		/// <returns>
		///   <c>true</c> if [is valid position] [the specified candidate]; otherwise, <c>false</c>.
		/// </returns>
		private bool IsValidPosition(string candidate)
		{
			var regex = new Regex(Settings.Default.TalkTimePattern);
			return regex.IsMatch(candidate);
		}
	}
}