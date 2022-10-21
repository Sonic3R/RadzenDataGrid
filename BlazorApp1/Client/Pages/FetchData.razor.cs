using BlazorApp1.Shared;

namespace BlazorApp1.Client.Pages
{
    public class FetchDataBase : InlineComponentBase<WeatherForecast>
    {
        private static readonly string[] Summaries = new[]
        {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        protected override WeatherForecast _selectedItem => new WeatherForecast();

        protected override Task LoadDataAsync()
        {
            _items = Enumerable.Range(1, 15).Select(index =>
            {
                var rand = Random.Shared.Next(-20, 55);

                return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rand,
                    Temperature = rand.ToString(),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
            }).ToList();

            return Task.CompletedTask;
        }

        protected override Task EditRow(WeatherForecast item)
        {
            _editForm.Model = item;
            return base.EditRow(item);
        }
    }
}