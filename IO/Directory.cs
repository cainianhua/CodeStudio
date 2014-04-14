using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeStudio.IO
{
	public class DirectoryEx
	{
		public static void CycleCreateDirectory( string path ) {
			string[] folders = path.Split( '\\' );

			if ( Directory.Exists( path ) ) return;

			StringBuilder folderBuilder = new StringBuilder( folders.Length * 2 - 1 );
			for ( int i = 0; i < folders.Length; ++i ) {
				folderBuilder.Append( folders[i] ).Append("\\");
				if ( i == 0 ) continue;

				string folderSection = folderBuilder.ToString().TrimEnd( '\\' );

				if ( !Directory.Exists( folderSection ) ) {
					Directory.CreateDirectory( folderSection );
				}
			}
		}
	}
}
