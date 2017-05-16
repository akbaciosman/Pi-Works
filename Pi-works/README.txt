

Main :
	create process

	call process.readFile
	function(): process read file line by line
		if date == "10/08/2016"
			function(): addData(line)
				if(client is not find in DataTable(HashMap)):
					add(clientID,DataTable);
				else:
					get client from dataTable
					if(client.dist_songs contains line.dist_song):
						ignored
					else:
						delete client from dataTable & add dist_song to client.dist_songs
						then readd client to dataTable


	call process.findDistSong(distSongNumber)
	....

	call process.maxDistSong()
	...


	I used hash maps for dataTable, dataTable.dist_song and countTable..
	used set for dist_song_count..
	used linkedlist for client_id records for accessing hashMap

