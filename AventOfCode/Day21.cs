using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 21: Allergen Assessment
    /// </summary>
    public sealed class Day21 : DayBase
    {
        public string Part2CanonicalResult { get; private set; }

        public Day21() : base(21) { }

        public override long GetFirstPartResult(bool sample)
        {
            throw new NotImplementedException($"Use '{nameof(GetSecondPartResult)}' to get result for this day.");
        }

        public override long GetSecondPartResult(bool sample)
        {
            var recipes = GetRecipes(sample);

            var antigensDiscovered = new Dictionary<string, string>();

            MakeAntigenHypothesis(null, recipes, antigensDiscovered);

            // sorts by antigen alphabetical order
            antigensDiscovered = antigensDiscovered
                .OrderBy(ai => ai.Key)
                .ToDictionary(ai => ai.Key, ai => ai.Value);

            Part2CanonicalResult = string.Join(",", antigensDiscovered.Select(ai => ai.Value));

            return recipes
                .SelectMany(r => r.ingredients)
                .Where(i => !antigensDiscovered.Any(ai => ai.Value == i))
                .Count();
        }

        private List<(List<string> ingredients, List<string> antigens)> GetRecipes(bool sample)
        {
            return GetContent(v =>
            {
                if (v.Contains("("))
                {
                    var parts = v.Split("(");
                    var ingredients = parts[0].Trim().Split(" ");
                    var allergenes = parts[1].Replace(")", "").Replace("contains", "").Trim().Split(", ");
                    return (ingredients.ToList(), allergenes.ToList());
                }
                else
                {
                    return (v.Split(" ").ToList(), new List<string>());
                }
            }, sample: sample);
        }

        private List<(List<string> ingredients, List<string> allergenes)> CopyRecipes(List<(List<string> ingredients, List<string> antigens)> recipes)
        {
            return recipes
                .Select(r => (
                    new List<string>(r.ingredients),
                    new List<string>((r.antigens))))
                .ToList();
        }

        private bool AreRecipesConsistent(List<(List<string> ingredients, List<string> antigens)> recipes)
        {
            // recipes are inconsistent if:
            // - they have more antigens than ingredients
            // - they's more than one ingredient for one specific antigen
            return !recipes.Any(r => r.antigens.Count > r.ingredients.Count)
                && !recipes
                    .SelectMany(r => r.antigens)
                    .Any(a => recipes
                        .Where(r => r.antigens.Contains(a) && r.ingredients.Count == 1)
                        .SelectMany(r => r.ingredients)
                        .Distinct()
                        .Count() > 1);
        }

        private bool MakeAntigenHypothesis((string ingredient, string antigen)? hypothesis,
            List<(List<string> ingredients, List<string> antigens)> recipes,
            Dictionary<string, string> antigensDiscovered)
        {
            if (hypothesis.HasValue)
            {
                // remove hypothesis from recipes list
                foreach (var (ingredients, allergenes) in recipes)
                {
                    // recipe is inconsistent: hard break
                    if (allergenes.Contains(hypothesis.Value.antigen)
                        && !ingredients.Contains(hypothesis.Value.ingredient))
                    {
                        return false;
                    }
                    allergenes.Remove(hypothesis.Value.antigen);
                    ingredients.Remove(hypothesis.Value.ingredient);
                }

                // remaining recipes are inconsistent: hard break
                if (!AreRecipesConsistent(recipes))
                {
                    return false;
                }

                // no unidentified antigens remaining: we are done
                if (!recipes.Any(r => r.antigens.Count > 0))
                {
                    return true;
                }
            }

            // takes a remaining recipe with at least one antigen
            var newRecipeForHypothesis = recipes.First(lf => lf.antigens.Count > 0);
            var newAntigenHypothesis = newRecipeForHypothesis.antigens.First();
            var hypothesisIsValid = false;
            // makes an hypothesis on each ingredient of the recipe
            foreach (var newIngredientHypothesis in newRecipeForHypothesis.ingredients)
            {
                var antigensDiscoveredForHypothesis = new Dictionary<string, string>();
                if (MakeAntigenHypothesis(
                    (newIngredientHypothesis, newAntigenHypothesis),
                    CopyRecipes(recipes),
                    antigensDiscoveredForHypothesis))
                {
                    // hypothesis seems valid: add the antigen, with its related ingredient
                    // to our base of knowledge
                    hypothesisIsValid = true;
                    antigensDiscovered.Add(newAntigenHypothesis, newIngredientHypothesis);
                    foreach (var antigen in antigensDiscoveredForHypothesis.Keys)
                    {
                        antigensDiscovered.Add(antigen, antigensDiscoveredForHypothesis[antigen]);
                    }
                    break;
                }
            }

            return hypothesisIsValid;
        }
    }
}
