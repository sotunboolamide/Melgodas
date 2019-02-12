using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MelgodasAndroid.Model;

namespace MelgodasAndroid.Repository
{
    class PestDiseaseRepository
    {
        private static List<Pest_Disease> Pest_Diseases = new List<Pest_Disease>
        {
            new Pest_Disease
            {
                ID=0,
                Name="Blight",
                 About=@"What it looks like: You’ll find brown spots on tomato leaves, starting with the older ones. Each spot starts to develop rings, like a target. Leaves turn yellow around the brown spots, then the entire leaf turns brown and falls off. Eventually the plant may have few, if any, leaves.",
                Causes=@"What causes it: A fungus called Alternaria solani. This fungus can live in the soil over the winter, so if your plants have had problems before like this, and you’ve planted tomatoes in the exact same spot, chances are good the same thing will happen to your plants this year.",
                Remedy=@"What to do about it: Crop rotation prevents new plants from contracting the disease. Avoid planting tomatoes, eggplants or peppers in the same spot each year as these can all be infected with early blight. A garden fungicide can treat infected plants.",
                Imagepath=null
            },
    new Pest_Disease
    {   ID=1,
        Name="Leaf Spot",
        About=@"Septoria Leaf Spot
What it looks like: After the plants begin to develop tomatoes, the lower leaves break out in yellow spots. Within the yellow spots, dark gray centers with dark borders appear. Black dots appear in the center of the spots. Foliage dies and falls off.",
        Causes=@"What causes it: A fungus called Septoria lycopersici thatinfects foliage.",
        Remedy=@"What to do about it: Avoid watering tomatoes from the top, as the spray can force the spores developing on the leaves back into the soil and continue the disease cycle. Certis Double Nickel 55™ Fungicide & Bactericide was developed for use against Septoria Leaf Spot on tomatoes",
        Imagepath=null
        },
    new Pest_Disease
    {
        ID=2,
        Name="Tuta Absoluta",
        About=@"Well, Tuta absoluta’s threat to Solanaceous crops originated from South America before spreading to other parts of the world.
The common name for Tuta absoluta is the tomato leafminer, named so because of the pest’s preference for tomato.
This dangerous pest favors tomato (Solanum lycopersicum) and sometimes potato (S. tuberosum).
Tomato leaf moth has a life cycle of 29 to 38 days depending on the temperature.
The pest prefers higher temperatures meaning the higher the temperature, the faster it will reproduce.",

        Causes =@"The most common source of infestation so far is buying seedlings that have been infected by the moth’s larva.
Therefore, it’s essential to only buy seedlings from certified plant nurseries.
You can further tell a health seedling by looking at the color. Healthy seedlings are strong, vigorous and dark green as opposed to yellowish.
So, do your homework and buy or grow healthy seedlings. This will give your tomato crop a good head start.
Other sources of infestation are wild hosts in the same family as the tomatoes and buying infected fruits at the market.
The former is more common than the latter.
Therefore, you need to ensure that the surrounding crops are either non-solanaceous or free from the pest altogether.",

        Remedy=@"Use of nets – Grow your tomatoes inside the insect nets while growing outdoor or within the greenhouse. If growing in the greenhouse, make sure the nets aren’t damaged.
Use of pheromone traps – Pheromone traps attracts and trap all-male adult moths especially when they are active at night. Use 2-4 traps per hectare for monitoring. If the number of trapped moths increases, you need to increase the traps accordingly.
Control human and animal traffic to the fields – Both humans and animals are vectors for spreading the bugs. So it’s important to control how they enter and leave your farm.
Sterilize the soil – Before you plant, ensure to properly sterilize the soil to kill all the eggs that might be present in the soil.
Quality planting materials – Buy quality seeds and seedlings from credible sources to ensure that they have not been infected by the larvae.
Others Methods
Use dustable sulfur which acts as an effective repellent
Practice crop rotation with non-solanaceous crops and completely remove any post-harvest plant debris.
Feed and irrigate your crop properly.
Completely remove any wild solanaceous host plants in the vicinity
Proper spacing, weed management, and crop sanitation
After a growing season (greenhouse), cut all plants above the soil level, leave them to dry out inside the greenhouse before uprooting and transporting debris outdoors for burning.

Control of Tuta absoluta using natural enemies
In case, of low infestation, biological control using natural enemies is the best alternative. For example, you can still use pheromone traps as discussed earlier.

However, this time the traps aren’t for monitoring purposes but for controlling the bugs.


 
In this scenario, use 25 – 35 traps per hectare, which will trap and kill the males.

Without mating, their reproduction will be hindered!

And that is what we want.

Other than that, the following strategies can also help.

Use a combination of neem oil (Azadirachtin – kills by suffocation) and Bacillus thuringiesissimply known as Bt.
Use yellow sticky traps to attract and trap the adults.
Finally, recent studies indicate that biological control services can be ascertained by using potential insectary plants, for example, Achillea millefolium and Calendula officinalis.

These plants serve as nutrient-providers to facilitate the installation of T. absoluta parasitoids (Necremnus tutae, Stenomesius nr. japonicus, and Bracon nr. nigricans) without encouraging the pest.

tuta absoluta control

Chemical Control of Tuta absoluta
If the prevalence of the infestation is high, use the last resort – Spray. Although I’m always skeptical about this.

But sometimes you’ve got to choose a lesser evil.

Try to use either, Deltamethrin, spinosad or Indoxacarb if occasional individuals of Tuta absoluta are observed.

However, don’t bother using pyrethrin-based chemicals.

They won’t help.",

        Imagepath=null
    }
        };


        public Pest_Disease GetPest_Disease_by_ID(int id)
        {
            return Pest_Diseases[id];
        }
        public List<Pest_Disease> GetPest_Disease()
        {
            return Pest_Diseases;
        }
    }
}