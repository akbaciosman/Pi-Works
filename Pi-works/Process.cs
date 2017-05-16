using System;
using System.IO;
using System.Collections.Generic;
using System.Text;



namespace Piworks
{
	class Process : ProcessDAO
	{	
		Dictionary<string,DataTable> list ;  	// key value is client id
		LinkedList<string> clientNo ;		 	// client id in the tables
		Dictionary<string,CountTable> countTable ;	//for count table
		public static HashSet<string> set ;						//For no duplicate dist_song_count

		//Constructor
		public Process(){
			list = new Dictionary<string,DataTable>();
			countTable = new Dictionary<string, CountTable>(); 
			clientNo = new LinkedList<string>(); 
			set = new HashSet<string>();
		}

		//
		public bool contains(string key){

			if (list != null && list.ContainsKey (key))
				return true;
			return false;
		
		}

		public Dictionary<string,CountTable> getCountTable(){
			return countTable;
		}

		public Dictionary<string,DataTable> getDataTable(){
			return list;
		}

		//read file and save data to Dictionary<string,dataTable>
		public void readFile(string fileName){
			try
			{
				using (StreamReader sr = new StreamReader(fileName))
				{
					string line=null;

					while ((line = sr.ReadLine()) != null)
					{	
						string[] tokens=null;

						//eliminate the other date
						if(line.Contains("10/08/2016")){
							tokens = line.Split(null);

							//get client data and ad to hashMap(DataTable) => client is uniqe
							addData(tokens);
					
						}
							
					}

					//Add data to CountTable{dist_song_count,client_cont}
					addDistToCountTable();

				}
			}catch (Exception e){

				Console.WriteLine("File can not be read");
				Console.WriteLine(e.Message);
			}

		}

		//Return dist_song_counts for given song_count
		//get hashMap sound_id_tables,and find given(346 or change) disting songs
		//
		public int findDistSong(int dist_song_number){
			int count = 0;
			DataTable table;
			foreach (string client in clientNo) {
				if (list.TryGetValue (client, out table))
				if (table.getSongIdTables ().Count == dist_song_number) {
						count++;
					}

				
			}
			return count;
		}

		//return max_dist_song_count 
		//used hashSet
		//Complexity is O(n)
		public int maxDistSong(){
			int max = -1;
			int count=0;

			foreach (string dist_song_count in set) {
				if ((count=Int32.Parse(dist_song_count))> max) {
						max = count;
					}
			}


		
			return max;
		}


		//add data to CountTable {dist_song_count, client_count}
		//And add dist_song_id to hashSet(no duplicate record)
		private void addDistToCountTable(){
			DataTable table;
			CountTable tableCount;
			foreach (string client in clientNo) {
				if (list.TryGetValue (client, out table))
					if (countTable.TryGetValue (table.getSongIdTables ().Count.ToString (), out tableCount)) {
							//add song_id to hashSet no duplicate
							set.Add (table.getSongIdTables ().Count.ToString ());
							
							//increment client_count and update Count_table
							tableCount.incrementCliNo ();
							countTable.Remove (table.getSongIdTables ().Count.ToString ());
							countTable.Add (tableCount.getDistSongCount ().ToString (), tableCount);
						} else {
							//if dist_song_count is not here,it will be add
							tableCount = new CountTable (table.getSongIdTables().Count.ToString(),1);
						
							countTable.Add (table.getSongIdTables().Count.ToString(),tableCount);
						}
			}
		}

		//Get line by line ,and split columns then add to HashMap(DataTable) => uniqe id is client
		private void  addData(string [] tokens){
			DataTable client;
			if (list.TryGetValue (tokens [2], out client)) { //if client is exist,then check duplicate song_ids
				
				if (!client.getSongIdTables ().ContainsKey (tokens [1])) { // if there is no duplicate song_id,then add
					client.addSongId (tokens [1], 1);
					list.Remove (client.getClientID ());
					list.Add (client.getClientID(), client);
				}
			} else {//if client is not exist,it will be insert dataTable
				clientNo.AddLast(tokens[2]);
				DataTable obj = new DataTable (tokens);

				list.Add (obj.getClientID(),obj);
			}
		}

	}
}

