using System;
using System.Data;
using Access.Databaselayer;

namespace Access
{

	class DbProgarm
	{

		static string connectionString = "Server=hildur.ucn.dk;Database=DMA-CSD-S211_10407521;User id=DMA-CSD-S211_10407521;password= Password1!";
		static void Main()
		{

			TryConnect try1 = new TryConnect();
			List<ConnectionState> connStates = try1.TryConnection(connectionString);
			foreach (ConnectionState connState in connStates)
			{
				Console.WriteLine("Connection state was : " + connState);


			}




		}





	}





}