namespace FlowControlBlazor.Components
{
    public partial class IterationManager
    {
        int nrOfRepetitions = 10;

        string inputRepeat = "";
        string inputThirdWord = "";

        string outputRepeat = "";
        string outputThirdWord = "";
        string thirdWordError = "";

        void HandleValidSubmitRepeat()
        {
            outputRepeat = inputRepeat;
        }

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
