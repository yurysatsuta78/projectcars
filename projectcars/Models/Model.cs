using projectcars.Entities;

namespace projectcars.Models
{
    public class Model
    {
        private Model(string modelName)
        {
            ModelName = modelName;
        }

        public static Model Create(string modelName)
        {
            return new Model(modelName);
        }

        public int ModelId { get; set; }
        public string ModelName { get; set; } = String.Empty;
        public Brand? Brand { get; set; }
    }
}
