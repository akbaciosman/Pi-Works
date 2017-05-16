using System;
using System.Collections.Generic;

namespace Piworks
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			string fileName = "exhibitA-input.csv";

			Process pro;

			//create process
			pro = new Process();

			//read data from file and parse it
			pro.readFile(fileName);

			//get 346
			int distSongNumber = 346; //you can change
			int count = pro.findDistSong(distSongNumber);
			Console.WriteLine("distSongNumber  "+distSongNumber + " count : " + count);

			int max = pro.maxDistSong();
			Console.WriteLine("max dist: " + max);

			//you can display CountTable
			/*Dictionary<string,CountTable> countTable = pro.getCountTable();
			displayCountTable(countTable);*/

			Console.ReadKey();
		

		}

		//display count_table {dist_song_count,client_count}
		//@param count_table(Dictionary) 
		public static void displayCountTable(Dictionary<string,CountTable> count_table){
			CountTable countTableData;
			Console.WriteLine ("dist_song_count | client_count");
			Console.WriteLine ("------------------------------");
			foreach (string count_dist_song in Process.set) {
				count_table.TryGetValue (count_dist_song, out countTableData);

				Console.Write(countTableData.ToString());
				Console.WriteLine ("------------------------------");
			}

		}

	}
}
