namespace Task1.Students.Interfaces
{
    /// <summary>
    /// The interface describes the student class.
    /// </summary>
    public interface IStudent
    {
        /// <summary>
        /// Property stores the student's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property stores the test name.
        /// </summary>
        public string TestName { get; set; }

        /// <summary>
        /// The property stores the date of the test.
        /// </summary>
        public string TestDate { get; set; }

        /// <summary>
        /// The property stores the test assessment.
        /// </summary>
        public int Assessment { get; set; }
    }
}
