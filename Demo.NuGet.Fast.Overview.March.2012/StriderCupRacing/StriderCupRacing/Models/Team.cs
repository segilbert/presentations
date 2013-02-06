using System.ComponentModel.DataAnnotations; 
namespace StriderCupRacing.Models
{ 
	public class Team
	{
		public int TeamId {get; set;}
		[StringLength(100)]
		[Required]
		public string Name {get; set;}
		[StringLength(1000)]
		[Required]
		public string Description {get; set;}
		public int Points {get; set;}
	}
}