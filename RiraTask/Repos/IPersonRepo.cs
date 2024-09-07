using RiraTask.Dto;
using RiraTask.Entities;

namespace RiraTask.Repos
{
	public interface IPersonRepo
	{
		Task<Person> Get(int id,CancellationToken cancellationToken);
		Task<Person> Create(AddPersonDto Person, CancellationToken cancellationToken);
		Task<Person> Update(Person Person, CancellationToken cancellationToken);	
		Task<bool> Delete(int id, CancellationToken cancellationToken	);
	}
}
