	using System;

	namespace mcMath
	{
		/// <summary>
		/// Summary description for Class1.
		/// </summary>
		/// 
		

		public class mcMathComp
		{
			private bool bTest = false;
			public mcMathComp()
			{
				//
				// TODO: Add constructor logic here
				//
			}

			/// <summary>
			/// //This is a test method
			/// </summary>
			public void mcTestMethod()
			{
							
			}

			

			/// <summary>
			/// //This is a test property
			/// </summary>
			public bool Extra
			{
				get
				{
					return bTest;
				}
				set
				{
					bTest = Extra ;
				}
			}

			public long Add(long val1, long val2)
			{
				return val1 + val2;
			}
		}
	}
