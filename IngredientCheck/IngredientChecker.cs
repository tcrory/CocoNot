using System;
using System.Collections.Generic;

namespace IngredientCheck
{
    public class IngredientChecker
    {
        private IngredientList ingredients;

        public IngredientChecker()
        {
            ingredients = new IngredientList();
        }

        public List<string> Check(string text)
        {
            return ingredients.FindIngredients(text);
        }
    }
}
