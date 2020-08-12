using System;
using System.Runtime.Serialization;
using Task2.SerializationCollections.Attributes;

namespace Task2.Humans
{
    /// <summary>
    /// Class describes the human. Using ISerializable interface, Serializable and VersionAttribute attributes.
    /// </summary>
    [Serializable]
    [Version(2, 1, 0, 1)]
    public class Human : ISerializable
    {
        /// <summary>
        /// An empty constructor is needed for serialization.
        /// </summary>
        public Human()
        {
        }

        /// <summary>
        /// The constructor initializes the class object.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="country">Country.</param>
        /// <param name="city">City.</param>
        public Human(string name, string country, string city)
        {
            Name = name;
            City = city;
            Country = country;
        }

        /// <summary>
        /// The constructor is needed for serialization.
        /// </summary>
        /// <param name="info">Info.</param>
        /// <param name="context">Context.</param>
        public Human(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            City = (string)info.GetValue("City", typeof(string));
            Country = (string)info.GetValue("Country", typeof(string));
        }

        /// <summary>
        /// Property stores the human's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property stores the city name.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Property stores the country name.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Method is needed for serialization/derialization.
        /// </summary>
        /// <param name="info">Info.</param>
        /// <param name="context">Context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("City", City);
            info.AddValue("Country", Country);
        }

        /// <summary>
        /// Method equals two objects.
        /// </summary>
        /// <param name="obj">Equals object.</param>
        /// <returns>Returns the result of the comparison</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;

            Human human = (Human)obj;

            return Name == human.Name &&
                   City == human.City &&
                   Country == human.Country;
        }

        /// <summary>
        /// The method gets the hash code of the object.
        /// </summary>
        /// <returns>Returns the hash code of the object.</returns>
        public override int GetHashCode() => HashCode.Combine(Name, City, Country);

        /// <summary>
        /// The method returns information about the object in string form.
        /// </summary>
        /// <returns>Information about the object.</returns>
        public override string ToString() => $"Name: {Name}, City: {City}, Country: {Country}";
    }
}
