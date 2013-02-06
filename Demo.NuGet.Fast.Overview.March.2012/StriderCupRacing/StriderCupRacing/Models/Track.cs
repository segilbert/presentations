using System.ComponentModel.DataAnnotations; 
namespace StriderCupRacing.Models
{ 
	public class Track
	{
		public int TrackId {get; set;}
		[StringLength(100)]
		[Required]
		public string Name {get; set;}
		[StringLength(1000)]
		[Required]
		public string Description {get; set;}
		[Required]
		public string Status {get; set;}
		[Required]
		public string Rating {get; set;}
		[Required]
		public string District {get; set;}
	}
}