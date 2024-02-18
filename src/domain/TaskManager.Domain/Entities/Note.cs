namespace TaskManager.Domain.Entities
{
    public class Note
    {
        private Guid _id;
        private string _record;

        public Note(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                throw new ArgumentException($"Value can not be null or whitespace{nameof(record)}");
            }
            _record = record ?? throw new ArgumentNullException(nameof(record));
        }

        public Guid Id
        {
            get { return _id; }
            init => _id = value;
        }

        public string Record
        {
            get { return _record; }
            set
            {
                if (string.IsNullOrWhiteSpace(_record))
                {
                    throw new ArgumentException($"Value can not be null or whitespace{nameof(_record)}");
                }
                _record = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

    }
}
