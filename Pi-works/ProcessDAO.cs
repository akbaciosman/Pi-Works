using System;

namespace Piworks
{
	public interface ProcessDAO
	{
		void readFile(string fileName);
		int findDistSong(int dist_song_number);
		int maxDistSong();
	}
}

