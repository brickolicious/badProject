using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using StoreAppPortLibrary;

namespace FestivalApp.DataModel
{
    class FestivalDataSource
    {


        public static async Task LoadRemoteDataAsync()
        {
            // Retrieve recipe data from Azure
            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 1024 * 1024; // Read up to 1 MB of data
            var response = await client.GetAsync(new Uri("http://contosorecipes8.blob.core.windows.net/AzureRecipesRP"));
            var result = await response.Content.ReadAsStringAsync();

            // Parse the JSON recipe data
            var recipes = JsonArray.Parse(result);

            // Convert the JSON objects into RecipeDataItems and RecipeDataGroups
            CreateGenreAndGenreGroup(recipes);
        }

        private static void CreateGenreAndGenreGroup(JsonArray array)
        {
            foreach (var item in array)
            {
                var obj = item.GetObject();
                Genre recipe = new Genre();
                GenreGroup group = null;

                foreach (var key in obj.Keys)
                {
                    IJsonValue val;
                    if (!obj.TryGetValue(key, out val))
                        continue;

                    switch (key)
                    {
                        case "key":
                            recipe.UniqueId = val.GetNumber().ToString();
                            break;
                        case "title":
                            recipe.Title = val.GetString();
                            break;
                        case "shortTitle":
                            recipe.ShortTitle = val.GetString();
                            break;
                        case "preptime":
                            recipe.PrepTime = (int)val.GetNumber();
                            break;
                        case "directions":
                            recipe.Directions = val.GetString();
                            break;
                        case "ingredients":
                            var ingredients = val.GetArray();
                            var list = (from i in ingredients select i.GetString()).ToList();
                            recipe.Ingredients = new ObservableCollection<string>(list);
                            break;
                        case "backgroundImage":
                            recipe.SetImage(val.GetString());
                            break;
                        case "tileImage":
                            recipe.SetTileImage(val.GetString());
                            break;
                        case "group":
                            var recipeGroup = val.GetObject();

                            IJsonValue groupKey;
                            if (!recipeGroup.TryGetValue("key", out groupKey))
                                continue;

                            group = _recipeDataSource.AllGroups.FirstOrDefault(c => c.UniqueId.Equals(groupKey.GetString()));

                            if (group == null)
                                group = CreateRecipeGroup(recipeGroup);

                            recipe.Group = group;
                            break;
                    }
                }

                if (group != null)
                    group.Items.Add(recipe);
            }
        }



    }
}
