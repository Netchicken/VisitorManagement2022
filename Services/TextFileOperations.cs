namespace VisitorManagement.Services
{
    public class TextFileOperations : ITextFileOperations
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TextFileOperations(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }




        public IEnumerable<string> LoadConditionsForAcceptanceText()
        {
            //======= Conditions of Acceptance
            //Gets or sets the absolute path to the directory that contains the web-servable application content files.
            string rootPath = _webHostEnvironment.WebRootPath;
            //Get a path to the file by adding the filename to the path
            FileInfo filePath = new FileInfo(Path.Combine(rootPath, "ConditionsForAdmittance.txt"));
            //now we have access to the file, lets read all the lines in to a string array, each line is a seperate entry in the array
            string[] lines = System.IO.File.ReadAllLines(filePath.ToString());
            //then pass the string array of the conditions to the ViewData to show on the front.

            return lines.ToList();

        }
    }
}
