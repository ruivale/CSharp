/// QuickGraph Library 
/// 
/// Copyright (c) 2003 Jonathan de Halleux
///
/// This software is provided 'as-is', without any express or implied warranty. 
/// 
/// In no event will the authors be held liable for any damages arising from 
/// the use of this software.
/// Permission is granted to anyone to use this software for any purpose, 
/// including commercial applications, and to alter it and redistribute it 
/// freely, subject to the following restrictions:
///
///		1. The origin of this software must not be misrepresented; 
///		you must not claim that you wrote the original software. 
///		If you use this software in a product, an acknowledgment in the product 
///		documentation would be appreciated but is not required.
///
///		2. Altered source versions must be plainly marked as such, and must 
///		not be misrepresented as being the original software.
///
///		3. This notice may not be removed or altered from any source 
///		distribution.
///		
///		QuickGraph Library HomePage: http://www.dotnetwiki.org
///		Author: Jonathan de Halleux


using System;
using QuickGraph.Concepts;

namespace QuickGraph.Collections
{

	/// <summary>
	/// A dictionary with keys of type Vertex and values of type String
	/// </summary>
	public class VertexStringDictionary: System.Collections.DictionaryBase
	{
		/// <summary>
		/// Initializes a new empty instance of the VertexStringDictionary class
		/// </summary>
		public VertexStringDictionary()
		{
			// empty
		}

		/// <summary>
		/// Gets or sets the String associated with the given Vertex
		/// </summary>
		/// <param name="key">
		/// The Vertex whose value to get or set.
		/// </param>
		public virtual String this[IVertex key]
		{
			get
			{
				return (String) this.Dictionary[key];
			}
			set
			{
				this.Dictionary[key] = value;
			}
		}

		/// <summary>
		/// Adds an element with the specified key and value to this VertexStringDictionary.
		/// </summary>
		/// <param name="key">
		/// The Vertex key of the element to add.
		/// </param>
		/// <param name="value">
		/// The String value of the element to add.
		/// </param>
		public virtual void Add(IVertex key, String value)
		{
			this.Dictionary.Add(key, value);
		}

		/// <summary>
		/// Determines whether this VertexStringDictionary contains a specific key.
		/// </summary>
		/// <param name="key">
		/// The Vertex key to locate in this VertexStringDictionary.
		/// </param>
		/// <returns>
		/// true if this VertexStringDictionary contains an element with the specified key;
		/// otherwise, false.
		/// </returns>
		public virtual bool Contains(IVertex key)
		{
			return this.Dictionary.Contains(key);
		}

		/// <summary>
		/// Determines whether this VertexStringDictionary contains a specific key.
		/// </summary>
		/// <param name="key">
		/// The Vertex key to locate in this VertexStringDictionary.
		/// </param>
		/// <returns>
		/// true if this VertexStringDictionary contains an element with the specified key;
		/// otherwise, false.
		/// </returns>
		public virtual bool ContainsKey(IVertex key)
		{
			return this.Dictionary.Contains(key);
		}

		/// <summary>
		/// Determines whether this VertexStringDictionary contains a specific value.
		/// </summary>
		/// <param name="value">
		/// The String value to locate in this VertexStringDictionary.
		/// </param>
		/// <returns>
		/// true if this VertexStringDictionary contains an element with the specified value;
		/// otherwise, false.
		/// </returns>
		public virtual bool ContainsValue(String value)
		{
			foreach (String item in this.Dictionary.Values)
			{
				if (item == value)
					return true;
			}
			return false;
		}

		/// <summary>
		/// Removes the element with the specified key from this VertexStringDictionary.
		/// </summary>
		/// <param name="key">
		/// The Vertex key of the element to remove.
		/// </param>
		public virtual void Remove(IVertex key)
		{
			this.Dictionary.Remove(key);
		}

		/// <summary>
		/// Gets a collection containing the keys in this VertexStringDictionary.
		/// </summary>
		public virtual System.Collections.ICollection Keys
		{
			get
			{
				return this.Dictionary.Keys;
			}
		}

		/// <summary>
		/// Gets a collection containing the values in this VertexStringDictionary.
		/// </summary>
		public virtual System.Collections.ICollection Values
		{
			get
			{
				return this.Dictionary.Values;
			}
		}
	}
}
