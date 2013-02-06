using System.ComponentModel.DataAnnotations; 
namespace StriderCupRacing.Models
{ 
	public class Race
	{
		public int RaceId {get; set;}
		[StringLength(100)]
		[Required]
		public string Name {get; set;}
		[StringLength(1000)]
		[Required]
		public string Description {get; set;}
		[Required]
		public string Country {get; set;}
		[Required]
		public string State {get; set;}
		[Required]
		public string City {get; set;}
		[Required]
		public string Rating {get; set;}
		[Required]
		public string Status {get; set;}
		public System.DateTime StartDate {get; set;}
		public System.DateTime EndDate {get; set;}
		[Required]
		public string Type {get; set;}
	}
}