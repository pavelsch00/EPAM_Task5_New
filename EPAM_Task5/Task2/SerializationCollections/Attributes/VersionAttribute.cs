using System;

namespace Task2.SerializationCollections.Attributes
{
    /// <summary>
    /// The class control version class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class VersionAttribute : Attribute
    {
        /// <summary>
        /// The property stores version class.
        /// </summary>
        public readonly Version classVersion;

        /// <summary>
        /// The constructor initializes version class.
        /// </summary>
        /// <param name="major">Major version.</param>
        /// <param name="minor">Minor version.</param>
        /// <param name="build">Build version.</param>
        /// <param name="revisionNumbers">Revision version.</param>
        public VersionAttribute(int major, int minor, int build, int revisionNumbers)
        {
            classVersion = new Version(major, minor, build, revisionNumbers);
        }

        /// <summary>
        /// The constructor initializes version class.
        /// </summary>
        /// <param name="major">Major version.</param>
        /// <param name="minor">Minor version.</param>
        /// <param name="build">Build version.</param>
        public VersionAttribute(int major, int minor, int build)
        {
            classVersion = new Version(major, minor, build);
        }

        /// <summary>
        /// The constructor initializes version class.
        /// </summary>
        /// <param name="major">Major version.</param>
        /// <param name="minor">Minor version.</param>
        public VersionAttribute(int major, int minor)
        {
            classVersion = new Version(major, minor);
        }

        /// <summary>
        /// The constructor initializes version class.
        /// </summary>
        /// <param name="version">Major.Minor.Build.Revision version.</param>
        public VersionAttribute(string version)
        {
            classVersion = new Version(version);
        }
    }
}
