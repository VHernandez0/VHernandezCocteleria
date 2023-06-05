using Microsoft.AspNetCore.Mvc;
using ML;
using Newtonsoft.Json;

namespace VHernandezCocteleria.Controllers
{
    public class CoctelesController : Controller
    {
        //public IActionResult GetAllNombre()
        //{
        //    ML.Cocteles cocteles = new ML.Cocteles();
        //    cocteles.Coctels = new List<object>();
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/");
        //        var responsetask = client.GetAsync("json/v1/1/search.php?f=a");
        //        responsetask.Wait();
        //        var result = responsetask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsStringAsync();
        //            readTask.Wait();

        //            foreach (var resultItem in readTask.Result.ToArray())
        //            {
        //                ML.Cocteles resultitemlist = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Cocteles>(resultItem.ToString());
        //                cocteles.Coctels.Add(resultitemlist);
        //            }
        //        }
        //    }
        //        return View(cocteles);
        //}

        
        public IActionResult GetAllNombre() 
        {
            ML.drinks cocteles = new ML.drinks();
            cocteles.Coctels = new List<object>();
            using(var client =new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/");
                var responsetask = client.GetAsync("json/v1/1/search.php?f=a"); 
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<dynamic>();
                    readtask.Wait();
                    foreach (dynamic item in readtask.Result.drinks)
                    {
                        ML.drinks resultitem = new ML.drinks();
                        resultitem.idDrink = item.idDrink;
                        resultitem.strDrink = item.strDrink;
                        resultitem.strDrinkThumb = item.strDrinkThumb;
                        resultitem.strInstructions = item.strInstructionsES;
                        resultitem.strCategory = item.strCategory;
                        resultitem.strIngredient1 = item.strIngredient1;
                        resultitem.strIngredient2 = item.strIngredient2;
                        resultitem.strIngredient3 = item.strIngredient3;
                        resultitem.strIngredient4 = item.strIngredient4;
                        resultitem.Imagen1 = "https://www.thecocktaildb.com/images/ingredients/" + resultitem.strIngredient1 + "-small.png";
                        resultitem.Imagen2 = "https://www.thecocktaildb.com/images/ingredients/" + resultitem.strIngredient2 + "-small.png";
                        resultitem.Imagen3 = "https://www.thecocktaildb.com/images/ingredients/" + resultitem.strIngredient3 + "-small.png";
                        resultitem.Imagen4 = "https://www.thecocktaildb.com/images/ingredients/" + resultitem.strIngredient4 + "-small.png";

                        cocteles.Coctels.Add(resultitem);
                    }
                }
            }
            return View(cocteles);
        }
        [HttpPost]
        public IActionResult GetById(string strDrink)
        {
            ML.drinks drinks = new ML.drinks();
            drinks.Coctels = new List<object>();
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/");
                var responsetask = client.GetAsync("json/v1/1/search.php?s="+strDrink);
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<dynamic>();
                    readtask.Wait();
                    foreach (dynamic item in readtask.Result.drinks)
                    {
                        ML.drinks resultitem = new ML.drinks();
                        resultitem.idDrink = item.idDrink;
                        resultitem.strDrink = item.strDrink;
                        resultitem.strDrinkThumb = item.strDrinkThumb;
                        resultitem.strInstructions = item.strInstructionsES;
                        resultitem.strCategory = item.strCategory;
                        resultitem.strIngredient1 = item.strIngredient1;
                        resultitem.strIngredient2 = item.strIngredient2;
                        resultitem.strIngredient3 = item.strIngredient3;
                        resultitem.strIngredient4 = item.strIngredient4;
                        resultitem.Imagen1 = "https://www.thecocktaildb.com/images/ingredients/" + resultitem.strIngredient1 + "-small.png";
                        resultitem.Imagen2 = "https://www.thecocktaildb.com/images/ingredients/" + resultitem.strIngredient2 + "-small.png";
                        resultitem.Imagen3 = "https://www.thecocktaildb.com/images/ingredients/" + resultitem.strIngredient3 + "-small.png";
                        resultitem.Imagen4 = "https://www.thecocktaildb.com/images/ingredients/" + resultitem.strIngredient4 + "-small.png";

                        drinks.Coctels.Add(resultitem);
                    }
                }
            }
            return View(drinks);
        }
    }
}
