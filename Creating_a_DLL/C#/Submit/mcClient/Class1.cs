using System;
using mcMath;

namespace mcClient
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			mcMathComp cls = new mcMathComp();
			long lRes = cls.Add( 23, 40 );
			cls.Extra = false;
			Console.WriteLine(lRes.ToString());
		}
	}
}
