using System;
using FOV.Domain.Entities.IngredientGeneralAggregator.Enums;

namespace FOV.Domain.Entities.IngredientAggregator.Enums
{
    public static class MeasureTransfer
    {
        /// <summary>
        /// Converts a measure to its base unit representation (e.g., grams, milliliters).
        /// </summary>
        /// <param name="measure">The ingredient measure.</param>
        /// <returns>A string representing the base unit (e.g., "g(gram)", "mL(milliliter)").</returns>
        public static string ToSmallUnit(this IngredientMeasure measure) => measure switch
        {
            IngredientMeasure.gam => "g",
            IngredientMeasure.ml => "mL",
            _ => "Unknown small unit"
        };

        /// <summary>
        /// Converts a measure to its larger unit representation (e.g., kilograms, liters).
        /// </summary>
        /// <param name="measure">The ingredient measure.</param>
        /// <returns>A string representing the larger unit (e.g., "kg(kilogram)", "L(liter)").</returns>
        public static string ToLargeUnit(this IngredientMeasure measure) => measure switch
        {
            IngredientMeasure.gam => "kg",
            IngredientMeasure.ml => "L",
            _ => "Unknown large unit"
        };
    }
}
