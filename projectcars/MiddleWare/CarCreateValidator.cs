using projectcars.Interfaces.Repositories;

namespace projectcars.MiddleWare
{
    public class CarCreateValidator
    {
        private readonly RequestDelegate _next;
        private readonly IGenerationsRepository _generationsRepository;

        private readonly HashSet<string> _allowedTransmissionTypes = new HashSet<string>
        {
            "Автомат",
            "Механика"
        };
        private readonly HashSet<string> _allowedBodyTypes = new HashSet<string>
        {
            "Внедорожник 3 дв.",
            "Внедорожник 5 дв.",
            "Кабриолет",
            "Купе",
            "Легковой фургон",
            "Лимузин",
            "Лифтбек",
            "Микроавтобус грузопассажирский",
            "Микроавтобус пассажирский",
            "Минивэн",
            "Пикап",
            "Родстер",
            "Седан",
            "Универсал",
            "Хэтчбек 3 дв.",
            "Хэтчбек 5 дв.",
            "Другой"
        };
        private readonly HashSet<string> _allowedEngineTypes = new HashSet<string>
        {
            "Бензин",
            "Бензин(пропан-бутан)",
            "Бензин(метан)",
            "Бензин(гибрид)",
            "Дизель",
            "Дизель(гибрид)",
            "Электро"
        };
        private readonly HashSet<string> _allowedDriveTrains = new HashSet<string>
        {
            "Передний привод",
            "Задний привод",
            "Подключаемый полный привод",
            "Постоянный полный привод"
        };


        public CarCreateValidator(RequestDelegate next, IGenerationsRepository generationsRepository)
        {
            _next = next;
            _generationsRepository = generationsRepository;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            double? engineVolume = null;
            if (double.TryParse(context.Request.Form["EngineVolume"], out var parsedEngineVolume)) 
            {
                engineVolume = parsedEngineVolume;
            };
            string? transmissionType = context.Request.Form["TransmissionType"];
            string? bodyType = context.Request.Form["BodyType"];
            string? engineType = context.Request.Form["EngineType"];
            string? driveTrain = context.Request.Form["DriveTrain"];
            Guid generationId = Guid.Empty;
            if (Guid.TryParse(context.Request.Form["GenerationId"], out var parsedGenerationId)) 
            {
                generationId = parsedGenerationId;
            }
            int? prodYear = null;
            if (int.TryParse(context.Request.Form["ProdYear"], out var parsedProdYear)) 
            {
                prodYear = parsedProdYear;
            }

            bool result = true;

            result = result && engineVolume < 30.0;
            result = result && _allowedTransmissionTypes.Contains(transmissionType);
            result = result && _allowedBodyTypes.Contains(bodyType);
            result = result && _allowedEngineTypes.Contains(engineType);
            result = result && _allowedDriveTrains.Contains(driveTrain);
            var generationEntity = await _generationsRepository.GetById(generationId);
            result = result && (prodYear <= generationEntity.EndYear && prodYear >= generationEntity.StartYear);

            if (!result) 
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Validation failure.");
                return;
            }

            await _next.Invoke(context);
        }
    }
}
