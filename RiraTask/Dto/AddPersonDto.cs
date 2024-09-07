using RiraTask.Entities;

namespace RiraTask.Dto
{
	public class AddPersonDto
	{
		public string Name { get; set; }
		public string Family { get; set; }
		public string NationalCode { get; set; }
		public DateTime BirthDate { get; set; }
		public static explicit operator Person(AddPersonDto dto) => new Person
		{
			Name = dto.Name,
			BirthDate = dto.BirthDate,
			Family = dto.Family,
			NationalCode = dto.NationalCode,
		};
	}
}
