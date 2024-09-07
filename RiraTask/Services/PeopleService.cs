using Grpc.Core;
using RiraTask.Dto;
using RiraTask.Protos;
using RiraTask.Repos;
using RiraTask.Utils;

namespace RiraTask.Services
{
	public class PeopleService : PersonService.PersonServiceBase
	{
		private readonly IPersonRepo _personRepo;

		public PeopleService(IPersonRepo personRepo)
		{
			this._personRepo = personRepo;
		}
		public override async Task<GetResponse> Get(GetIdRequest request, ServerCallContext context)
		{
			var resReop = await _personRepo.Get(request.Id, CancellationToken.None);
			if(resReop != null)
			{
				var resp = new GetResponse()
				{
					Id = request.Id,
					BirthDate = resReop.BirthDate.ToString(),
					Name = resReop.Name,
					Family = resReop.Family,
					NationalCode = resReop.NationalCode,
				};
				return resp;
			}
			else
			{
				throw new RpcException(new Status(StatusCode.NotFound, "id not found."));
			}
		}
		public override async Task<AddRepsone> Add(AddPersonRequest request, ServerCallContext context)
		{
			try
			{
				var AddedPerson = await _personRepo.Create(new AddPersonDto
				{
					Name = request.Person.Name,
					Family = request.Person.Family,
					NationalCode = request.Person.NationalCode,
					BirthDate = request.Person.BirthDate.ConvertStrToDate(),
				}, CancellationToken.None);

				return new AddRepsone
				{
					Person = new Person
					{
						Id = request.Person.Id,
						Name = request.Person.Name,
						Family = request.Person.Family,
						NationalCode = request.Person.NationalCode,
						BirthDate = request.Person.BirthDate,
					}
				};
			}
			catch(Exception ex)
			{

				throw new RpcException(new Status(StatusCode.Aborted, ex.Message));
			}
		}
		public override async Task<UpdateResponse> Update(UpdatePersonRequest request, ServerCallContext context)
		{
			try
			{
				var UpdatedPerson = await _personRepo.Update(new Entities.Person
				{
					Id = request.Person.Id,
					Name = request.Person.Name,
					Family = request.Person.Family,
					NationalCode = request.Person.NationalCode,
					BirthDate = request.Person.BirthDate.ConvertStrToDate()
				}, CancellationToken.None);

				return new UpdateResponse
				{
					Person = new Person
					{
						Id = UpdatedPerson.Id,
						Name = UpdatedPerson.Name,
						Family = UpdatedPerson.Family,
						NationalCode = UpdatedPerson.NationalCode,
						BirthDate = UpdatedPerson.BirthDate.ToString(),
					}
				};
			}
			catch(Exception ex)
			{
				throw new RpcException(new Status(StatusCode.Aborted, ex.Message));
			}
		}
		public override async Task<DeleteResponse> Delete(DeletePersonRequest request, ServerCallContext context)
		{
			try
			{
				var delete = await _personRepo.Delete(request.Id, CancellationToken.None);

				return new DeleteResponse { IsDelete = delete };
			}
			catch(Exception ex)
			{
				throw new RpcException(new Status(StatusCode.Aborted, ex.Message));
			}
		}
	}
}
