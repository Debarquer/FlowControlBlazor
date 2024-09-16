namespace FlowControlBlazor.Components
{
    /// <summary>
    /// A class for demonstrating iteration functionalities.
    /// </summary>
    public partial class IterationManager
    {
        int nrOfRepetitions = 10;

        string inputRepeat = "";
        string inputThirdWord = "";

        string outputRepeat = "";
        string outputThirdWord = "";
        string thirdWordError = "";

        /// <summary>
        /// Sets the output to the input value which then repeats to the page nrOfRepetitions times.
        /// </summary>
        void HandleValidSubmitRepeat()
        {
            outputRepeat = inputRepeat;
        }

        /// <summary>
        /// Verifies that the user has input at least three words.
        /// Prints the input and the third word to the page.
        /// </summary>
        void HandleValidSubmitThirdWord()
        {
            thirdWordError = "";

            var split = inputThirdWord.Split(' ').Where(x => x != "").ToArray();

            if(split.Length < 3 ) 
            {
                thirdWordError = "Error: Please enter at least 3 words.";
                outputThirdWord = "";
                return;
            }

            string thirdWord = split[2];
            outputThirdWord = $"Third word: {thirdWord}";
        }

        void HandleInvalidSubmit()
        {

        }
    }
}
