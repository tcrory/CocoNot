using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;

namespace IngredientCheck
{
    class IngredientList
    {
        private readonly List<string> ingredientText;
        private Regex ingredients;

        public Regex Ingredients => ingredients;

        public IngredientList()
        {
            ingredientText = new List<string>
            {
                "1,2 Octaneidal",
                "2 Phenoxyethanol",
                "Ammonium Lauryl Sulphate",
                "Capryl Glycol",
                "Caprylic Acid",
                "Caprilic Glycol",
                "Caprylic",
                "Capric Triglycerides",
                "Capric",
                "Caprylyl Glycol",
                "Ceteareth-20",
                "Cetearyl Alcohol",
                "Cetearyl Glucoside",
                "Ceteth-20 Phosphate",
                "Cetyl Alcohol",
                "Cetyl Esters",
                "Cocamide MEA",
                "Cocamidopropyl Betaine",
                "Cococaprylate",
                "Caprate",
                "Coco Glucoside",
                "Cocomide DEA",
                "Coconut Diethanolamide (CDFA)",
                "Cocos Nucifera",
                "Coconout Milk",
                "Coconout Oil",
                "Coconout",
                "Coconut Milk",
                "Coconut Oil",
                "Coconut",
                "Decyl Glucoside",
                "Disodium Cocamphodiprop",
                "Disodium Cocoamphodiacetate",
                "Emusifying Wax",
                "Glyceryl Caprylate",
                "Glyceryl Cocoate",
                "Hexyl Laurate",
                "Isopropyl Myristate",
                "Laureth-3",
                "Lauric Acid",
                "Lauryl Glucoside",
                "Lauryl Alcohol",
                "Lauramide DEA",
                "Myristic Acid",
                "Olefin Sulfonate",
                "Organic Sodium Cocoate",
                "PEG-7 Glyceryl Cocoate",
                "PEG-100 Stearate",
                "PEG-100",
                "Phenoxyethanol",
                "Polysorbate 20",
                "Sodium Cocoate",
                "Sodium Coco-Sulfate",
                "Sodium Cocoyl Isethionate",
                "Sodium Cocoyl Glutamate",
                "Sucrose Stearate",
                "Sodium Lauroamphoacetate",
                "Sodium Laureth Sulfate",
                "Sodium Lauroyl Sarcosinat",
                "Sodium Lauryl Sulfate",
                "Sodium Stearate",
                "Sorbitan Stearate",
                "Stearyl Alcohol",
                "Stearalkonium Chloride",
                "Sucrose Cocoate",
                "TEA-Laureth Sulfate",
                "Vegetable Cetearyl Glucose",
                "Vegetable Glycerine",
            };
            CompileRegexs();
        }

        private void CompileRegexs()
        {
            // Clean up the ingredient strings into regexes.
            var ingredientRegexes = new List<string>();
            var cleanupRe = new Regex(@"[-\s,]");
            foreach (string text in ingredientText)
            {
                // Replace spaces and hyphens with a sub-group that can match any of them.
                string manipulatedText = cleanupRe.Replace(text, @"([-\s,]*)");
                ingredientRegexes.Add(manipulatedText.ToLower());
            }
            string combinedReString = $"\\b({string.Join("|", ingredientRegexes)})\\b";
            ingredients = new Regex(combinedReString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public List<string> FindIngredients(string text)
        {
            var foundIngredients = new List<string>();
            MatchCollection matches = ingredients.Matches(text);
            foreach (Match match in matches)
            {
                foundIngredients.Add(match.Value);
            }
            return foundIngredients;
        }
    }
}
