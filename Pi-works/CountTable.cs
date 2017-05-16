namespace Piworks
{	
   class CountTable
   {
		private string dist_song_count; //this is uniqe
      	private int client_count;
      


		public CountTable(string dist_song_count,int client_count){
          this.dist_song_count   = dist_song_count;
          this.client_count = client_count;
      }


      public void setClientCount(int client_count){
         this.client_count = client_count;
      }

		public void setDistSongCount(string dist_song_count){
         this.dist_song_count = dist_song_count;
      }

	  public void incrementCliNo(){
		this.client_count++;
	}


	 public int getClientCount()
      {
         return client_count;
      }
         
		public string getDistSongCount()
      {
         return dist_song_count;
      }
     

      public override string ToString(){

         return  dist_song_count + "\t\t| \t" + client_count + "  \n";
      }

   
   }
}