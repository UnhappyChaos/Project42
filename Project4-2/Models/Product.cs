using System;
using System.ComponentModel.DataAnnotations;

namespace Project4_2
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		public string Code { get; set; }

		[Required]
		public string Name { get; set; }

		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }
	}
}