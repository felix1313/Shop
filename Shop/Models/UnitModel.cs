namespace Shop.Models
{
    public class UnitModel
    {
        private readonly Unit instance;

        public UnitModel(Unit dbModel)
        {
            instance = dbModel;
        }

        public int Id
        {
            get
            {
                return instance.Id;
            }
        }

        public string Name
        {
            get
            {
                return instance.Name;
            }
        }

        public string Description
        {
            get
            {
                return instance.Description;
            }
        }

        public string Price
        {
            get
            {
                return string.Format("{0} UAH",instance.Price);
            }
        }

        public string ImageSrc
        {
            get
            {
                return instance.ImageSrc;
            }
        }
    }
}