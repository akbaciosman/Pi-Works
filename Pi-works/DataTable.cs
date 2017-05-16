using System;
using System.Collections.Generic;
namespace Piworks
{		
	class DataTable
	{
		private string playID;
		Dictionary<string,int> song_id_tables = new Dictionary<string, int>(); //No duplicate data
		private string clientID;
		private string playTS;

		public DataTable(){}

		public DataTable(string [] str){
			this.playID   = str[0];
			this.song_id_tables[str[1]] = 1;
			this.clientID = str[2];
			this.playTS   = str[3];
		}

		public bool addSongId(string key,int value){
			if (!isFind(key)){
				this.song_id_tables.Add (key,value);
				return true;
			}
			return false;
		}

		void setPlayID(string playID){
			this.playID = playID;
		}

		void setSongID(string songID){
			this.song_id_tables[ songID] = 1;
		}

		void setClientID(string clientID){
			this.clientID = clientID;
		}
		void setPlayTS(string playTS){
			this.playTS = playTS;
		}


		public string getPlayID()
		{
			return playID;
		}

		public Dictionary<string,int> getSongIdTables()
		{
			return song_id_tables;
		}

		public string getClientID()
		{
			return clientID;
		}

		public string getPlayTS()
		{
			return playTS;
		}



		public bool isFind(string key){
			if (song_id_tables.ContainsKey (key))
				return true;
			return false;
		}

		public override string ToString(){

			return "play_id : " + playID + " song_id : " + song_id_tables.ToString() +
				" client_id : " + clientID + " play_ts : " + playTS + " \n";
		}





	}
}

