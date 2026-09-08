namespace stefan_academy_vanilla_charp.Common
{
    public class Repository<T> where T : class, IEntity
    {
        private readonly List<T> items = new();
        private readonly ITextMapper<T> mapper;
        private readonly string path;

        public Repository(ITextMapper<T> mapper, string path)
        {
            this.mapper = mapper;
            this.path = path;
            Read();
        }

        protected List<T> Items
        {
            get { return items; }
        }

        public T FindById(Guid id)
        {
            foreach (T item in items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public void Save()
        {
            using (var writer = new StreamWriter(path))
            {
                for (int i = 0; i < items.Count; i++)
                {
                    writer.Write(mapper.ToText(items[i]));

                    if (i + 1 < items.Count)
                    {
                        writer.Write("\n");
                    }
                }
            }
        }

        private void Read()
        {
            using (var reader = new StreamReader(path))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    items.Add(mapper.FromText(line));
                }
            }
        }
    }
}
