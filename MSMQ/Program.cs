using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace MSMQ
{

	[ServiceContract]
	public interface IService
	{
		[OperationContract(IsOneWay =true)]
		void Process(string data);
	}

	[ServiceBehavior]
	public class MsmqService : IService
	{
		[OperationBehavior]
		public void Process(string data)
		{
			Console.WriteLine(string.Format("Process data (0) at (1)",data,DateTime.Now));
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost host = new ServiceHost(typeof(MsmqService));
			host.Open();
			Console.WriteLine("service is ready");
			Console.ReadLine();
		}
	}
}
