using Grpc.Core;
using Grpc.Net.Client;
using RiraTask.Protos;

namespace RiraTask.Client
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{


				var Channel = GrpcChannel.ForAddress("http://localhost:5045");
				var PersonClient = new PersonService.PersonServiceClient(Channel);


				Console.WriteLine("Hello, World!");
				Console.WriteLine("enter your option => 1:GET, 2:ADD, 3:PUT, 4:Delete");
				var option = Console.ReadLine();
				switch(option)
				{
					case "1":
						{
							Console.WriteLine("Enter Id");
							var id = Console.ReadLine();
							if(id != null)
							{

								GetIdRequest requestId = new() { Id = int.Parse(id) };
								var getResponse = PersonClient.Get(requestId);
								Console.WriteLine($"Id = {getResponse.Id},Name = {getResponse.Name},Family = {getResponse.Family},NationalCode = {getResponse.NationalCode},BirthDate = {getResponse.BirthDate}");
								Console.WriteLine("End....");
							}
							else
							{
								Console.WriteLine("id can not null");
							}
							break;
						}
					case "2":
						{

							Console.WriteLine("enter new Name");
							var name = Console.ReadLine();
							Console.WriteLine("enter new Family");
							var family = Console.ReadLine();
							Console.WriteLine("enter new NationalCode");
							var nationalCode = Console.ReadLine();
							Console.WriteLine("enter new BirthDate");
							var birthDate = Console.ReadLine();
							if(!string.IsNullOrEmpty(name))
							{
								PersonClient.Add(new AddPersonRequest
								{
									Person = new Person
									{
										Name = name,
										Family = family,
										NationalCode = nationalCode,
										BirthDate = birthDate
									}
								});
								Console.WriteLine("operation has  successfuly.");
							}
							else
							{
								Console.WriteLine("id can not null");
							}
							break;
						}
					case "3":
						{
							Console.WriteLine("enter  Id");
							var id = Console.ReadLine();
							Console.WriteLine("enter new value for Name");
							var name = Console.ReadLine();
							Console.WriteLine("enter new value for Family");
							var family = Console.ReadLine();
							Console.WriteLine("enter new value for NationalCode");
							var nationalCode = Console.ReadLine();
							Console.WriteLine("enter new value for BirthDate");
							var birthDate = Console.ReadLine();
							if(id != null)
							{
								PersonClient.Update(new UpdatePersonRequest
								{
									Person =
									new Person
									{
										Id = int.Parse(id),
										Name = name,
										Family = family,
										NationalCode = nationalCode,
										BirthDate = birthDate
									}
								});
								Console.WriteLine("operation has  successfuly.");
							}
							else
							{
								Console.WriteLine("id can not null");
							}
							break;
						}
					case "4":
						{
							Console.WriteLine("enter Id for delete");
							var id = Console.ReadLine();
							if(id != null)
							{
								var result = PersonClient.Delete(new DeletePersonRequest { Id = int.Parse(id) });
								if(result != null)
								{
									Console.WriteLine($"delete operation succed is {result.IsDelete}");
								}
							}
							else
							{
								Console.WriteLine("id can not null");
							}
							break;
						}
				}
			}
			catch(RpcException ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}
	}
}
