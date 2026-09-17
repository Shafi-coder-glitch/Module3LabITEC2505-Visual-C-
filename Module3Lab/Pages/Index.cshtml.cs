using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Module3Lab.Pages
{
    public class IndexModel : PageModel
    {
        // These properties hold the page data.
        public int HungerLevel { get; set; }
        public string HungerMessage { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;
        public string EncouragementMessage { get; set; } = string.Empty;
        public bool ShowResults { get; set; } = false;

        // This runs when the page first opens.
        public void OnGet()
        {
        }

        // This runs when the user submits the form.
        public void OnPost(int hungerLevel)
        {
            HungerLevel = hungerLevel;
            ShowResults = true;

            // These values set the hunger levels.
            const int veryHungryThreshold = 8;
            const int somewhatHungryThreshold = 5;

            // Check the hunger level.
            if (HungerLevel >= veryHungryThreshold)
            {
                HungerMessage = "You're super hungry. Order both tacos and burritos.";
            }
            else if (HungerLevel >= somewhatHungryThreshold)
            {
                HungerMessage = "You're moderately hungry. Go for a plate of tacos.";
            }
            else
            {
                HungerMessage = "You're not that hungry. Opt for a small burrito.";
            }

            // Choose tacos or burrito.
            Recommendation = (HungerLevel >= somewhatHungryThreshold) ? "Tacos" : "Burrito";

            // Choose a message for each hunger level.
            switch (HungerLevel)
            {
                case 10:
                    EncouragementMessage = "You're a taco and burrito champion.";
                    break;

                case 9:
                case 8:
                case 7:
                    EncouragementMessage = "Taco plate time.";
                    break;

                case 6:
                case 5:
                case 4:
                    EncouragementMessage = "Small burrito it is.";
                    break;

                default:
                    EncouragementMessage = "Maybe just grab a snack.";
                    break;
            }
        }
    }
}
