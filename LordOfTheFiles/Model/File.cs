namespace LordOfTheFiles.Model
{
    /// <summary>
    /// Class which represents a file in our system
    /// </summary>
    public class File
    {
        // Instance variables
        private string name;
        private byte[] content;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the file.</param>
        /// <param name="content">The contents of the file as bytes.</param>
        public File(string name, byte[] content)
        {
            this.name = name;
            this.content = content;
        }

        /// <summary>
        /// Property for name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// property for Content
        /// </summary>
        public byte[] Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}
