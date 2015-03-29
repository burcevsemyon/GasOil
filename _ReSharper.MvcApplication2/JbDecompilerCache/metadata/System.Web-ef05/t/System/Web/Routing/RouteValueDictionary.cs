// Type: System.Web.Routing.RouteValueDictionary
// Assembly: System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Web.dll

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Web.Routing
{
    /// <summary>
    /// Represents a case-insensitive collection of key/value pairs that you use in various places in the routing framework, such as when you define the default values for a route or when you generate a URL that is based on a route.
    /// </summary>
    [TypeForwardedFrom("System.Web.Routing, Version=3.5.0.0, Culture=Neutral, PublicKeyToken=31bf3856ad364e35")]
    public class RouteValueDictionary : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Web.Routing.RouteValueDictionary"/> class that is empty.
        /// </summary>
        public RouteValueDictionary();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Web.Routing.RouteValueDictionary"/> class and adds values that are based on properties from the specified object.
        /// </summary>
        /// <param name="values">An object that contains properties that will be added as elements to the new collection.</param>
        public RouteValueDictionary(object values);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Web.Routing.RouteValueDictionary"/> class and adds elements from the specified collection.
        /// </summary>
        /// <param name="dictionary">A collection whose elements are copied to the new collection.</param><exception cref="T:System.ArgumentNullException"><paramref name="dictionary"/> is null.</exception><exception cref="T:System.ArgumentException"><paramref name="dictionary"/> contains one or more duplicate keys.</exception>
        public RouteValueDictionary(IDictionary<string, object> dictionary);

        /// <summary>
        /// Adds the specified value to the dictionary by using the specified key.
        /// </summary>
        /// <param name="key">The key of the element to add.</param><param name="value">The value of the element to add.</param>
        public void Add(string key, object value);

        /// <summary>
        /// Removes all keys and values from the dictionary.
        /// </summary>
        public void Clear();

        /// <summary>
        /// Determines whether the dictionary contains the specified key.
        /// </summary>
        /// 
        /// <returns>
        /// true if the dictionary contains an element that has the specified key; otherwise, false.
        /// </returns>
        /// <param name="key">The key to locate in the dictionary.</param>
        public bool ContainsKey(string key);

        /// <summary>
        /// Determines whether the dictionary contains a specific value.
        /// </summary>
        /// 
        /// <returns>
        /// true if the dictionary contains an element that has the specified value; otherwise, false.
        /// </returns>
        /// <param name="value">The value to locate in the dictionary.</param>
        public bool ContainsValue(object value);

        /// <summary>
        /// Returns an enumerator that you can use to iterate through the dictionary.
        /// </summary>
        /// 
        /// <returns>
        /// A structure for reading data in the dictionary.
        /// </returns>
        public Dictionary<string, object>.Enumerator GetEnumerator();

        /// <summary>
        /// Removes the value that has the specified key from the dictionary.
        /// </summary>
        /// 
        /// <returns>
        /// true if the element is found and removed; otherwise, false. This method returns false if <paramref name="key"/> is not found in the dictionary.
        /// </returns>
        /// <param name="key">The key of the element to remove.</param>
        public bool Remove(string key);

        /// <summary>
        /// Gets a value that indicates whether a value is associated with the specified key.
        /// </summary>
        /// 
        /// <returns>
        /// true if the dictionary contains an element that has the specified key; otherwise, false.
        /// </returns>
        /// <param name="key">The key of the value to get.</param><param name="value">When this method returns, contains the value that is associated with the specified key, if the key is found; otherwise, contains the appropriate default value for the type of the <paramref name="value"/> parameter that you provided as an out parameter. This parameter is passed uninitialized.</param>
        public bool TryGetValue(string key, out object value);

        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item);
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item);
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex);
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item);
        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator();

        /// <summary>
        /// For a description of this member, see <see cref="M:System.Collections.IEnumerable.GetEnumerator"/>.
        /// </summary>
        /// 
        /// <returns>
        /// A structure for reading data in the dictionary.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator();

        /// <summary>
        /// Gets the number of key/value pairs that are in the collection.
        /// </summary>
        /// 
        /// <returns>
        /// The number of key/value pairs that are in the collection.
        /// </returns>
        public int Count { get; }

        /// <summary>
        /// Gets a collection that contains the keys in the dictionary.
        /// </summary>
        /// 
        /// <returns>
        /// A collection that contains the keys in the dictionary.
        /// </returns>
        public Dictionary<string, object>.KeyCollection Keys { get; }

        /// <summary>
        /// Gets a collection that contains the values in the dictionary.
        /// </summary>
        /// 
        /// <returns>
        /// A collection that contains the values in the dictionary.
        /// </returns>
        public Dictionary<string, object>.ValueCollection Values { get; }

        /// <summary>
        /// Gets or sets the value that is associated with the specified key.
        /// </summary>
        /// 
        /// <returns>
        /// The value that is associated with the specified key, or null if the key does not exist in the collection.
        /// </returns>
        /// <param name="key">The key of the value to get or set.</param>
        public object this[string key] { get; set; }

        ICollection<string> IDictionary<string, object>.Keys { get; }
        ICollection<object> IDictionary<string, object>.Values { get; }
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly { get; }
    }
}
