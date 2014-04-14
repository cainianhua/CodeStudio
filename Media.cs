using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeStudio
{
	public class Media
	{
		/// <summary>
		/// Get mime type of stream that comes from a HttpPostFileBase object.
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string GetFileType( Stream input ) {
			if ( input.CanSeek && input.Position != 0 ) input.Position = 0;

			string fileclass = "";

			if ( input.Length > 2 ) {
				byte[] bytes = new byte[2];
				if ( input.CanRead ) {
					input.Read( bytes, 0, 2 );    // 读取前两位。
				}
				fileclass = bytes[0].ToString() + bytes[1].ToString();
			}

			//fileclass = "";

			return GetMimeTypeOfTypeCode( fileclass );
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fileclass"></param>
		/// <returns></returns>
		private static string GetMimeTypeOfTypeCode( string fileclass ) {
			#region [ 扩展名MIME映射 ]

			Dictionary<string, string> exts = new Dictionary<string, string>();
			exts.Add( "7173", "image/gif" );      // gif
			exts.Add( "255216", "image/jpeg" );   // jpg
			exts.Add( "13780", "image/png" );     // png
			exts.Add( "6677", "image/bmp" );      // bmp
			exts.Add( "7777", "image/tiff" );     // tiff
			//exts.Add("239187", "");     // txt,aspx,asp,sql
			//exts.Add("208207", "");     // xls, doc, ppt
			//exts.Add("6063", "");       // xml
			//exts.Add("6033", "");       // htm,html
			//exts.Add("4742", "");       // js
			//exts.Add("8075", "");       // xlsx,zip,pptx,mmap,zip
			//exts.Add("8297", "");       // rar
			//exts.Add("01", "");         // accdb,mdb
			//exts.Add("7790", "");       // exe,dll
			//exts.Add("5666", "");       // psd
			//exts.Add("255254", "");     // rdp
			//exts.Add("10056", "");      // bt种子
			//exts.Add("64101", "");      // bat

			#endregion

			#region [ 文件扩展名说明 ]

			/*文件扩展名说明
             *7173        gif 
             *255216      jpg
             *13780       png
             *6677        bmp
             *239187      txt,aspx,asp,sql
             *208207      xls.doc.ppt
             *6063        xml
             *6033        htm,html
             *4742        js
             *8075        xlsx,zip,pptx,mmap,zip
             *8297        rar   
             *01          accdb,mdb
             *7790        exe,dll           
             *5666        psd 
             *255254      rdp 
             *10056       bt种子 
             *64101       bat 
             *7777        tiff
             */

			#endregion

			return exts.Keys.Contains( "" ) ? exts[fileclass] : exts["255216"];
		}
	}
}
