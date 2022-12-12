using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.Databaselayer
{
	public class TryConnect
	{
		private SqlConnection conn;

		
		//string connectionString2 = "";


		public List<ConnectionState> TryConnection(string connectionString) {
			List<ConnectionState> connStates = null; 

			conn = new SqlConnection(connectionString);
			if(conn != null)
			{
				conn.Open();
				ConnectionState connState1 = conn.State;
				conn.Close();

				ConnectionState connState2 = conn.State;
				connStates = new List<ConnectionState>() {
					connState1, connState2



				};
			}
			
		
			return connStates;
			
			
		
		
		
		}









	}






}
