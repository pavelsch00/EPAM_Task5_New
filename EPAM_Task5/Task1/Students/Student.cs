using System;
using Task1.Students.Interfaces;

namespace Task1.Students
{
    /// <summary>
    /// Class describes the student.
    /// </summary>
    public class Student : IStudent, IComparable
    {
        /// <summary>
        /// The field stores for min assessment.
        /// </summary>
        private const int _minAssessment = 0;

        /// <summary>
        /// The field stores for max assessment.
        /// </summary>
        private const int _maxAssessment = 10;

        /// <summary>
        /// The field stores the test assessment.
        /// </summary>
        private int assessment;

        /// <summary>
        /// An empty constructor is needed for serialization.
        /// </summary>
        public Student()
        {
        }

        /// <summary>
        /// The constructor initializes the class object.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="testName">Test name.</param>
        /// <param name="testDate">Date of the test.</param>
        /// <param name="assessment">Test assessment.</param>
        public Student(string name, string testName, string testDate, int assessment)
        {
            Name = name;
            TestName = testName;
            TestDate = testDate;
            Assessment = assessment;
        }

        /// <inheritdoc cref="IStudent.Name"/>
        public string Name { get; set; }

        /// <inheritdoc cref="IStudent.TestName"/>
        public string TestName { get; set; }

        /// <inheritdoc cref="IStudent.TestDate"/>
        public string TestDate { get; set; }

        /// <inheritdoc cref="IStudent.Assessment"/>
        public int Assessment
        {
            get => assessment;
            set
            {
                if (value >= _minAssessment && value <= _maxAssessment)
                    assessment = value;
                else
                    throw new ArgumentException("Invalid assessment.");
            }
        }

        /// <summary>
        /// Method comparing two objects.
        /// </summary>
        /// <param name="obj">Comparison object.</param>
        /// <returns>Returns the result of the comparison</returns>
        public int CompareTo(object obj)
        {
           Student student = (Student)obj;
           return Assessment.CompareTo(student.Assessment);
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

            Student student = (Student)obj;

            return Name == student.Name &&
                   TestName == student.TestName &&
                   TestDate == student.TestDate &&
                   Assessment == student.Assessment;
        }

        /// <summary>
        /// The method gets the hash code of the object.
        /// </summary>
        /// <returns>Returns the hash code of the object.</returns>
        public override int GetHashCode() => HashCode.Combine(Name, TestName, TestDate, Assessment);

        /// <summary>
        /// The method returns information about the object in string form.
        /// </summary>
        /// <returns>Information about the object.</returns>
        public override string ToString() => $"Name: {Name}, Test Name: {TestName}, TestDate: {TestDate}, Assessment: {Assessment}\n";
    }
}
