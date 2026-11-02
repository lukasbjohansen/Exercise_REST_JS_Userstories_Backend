namespace REST_API
{
    public class RecordsRepositoryList : IRecordsRepository
    {
        private readonly List<Record> _records = new List<Record>();
        private int _nextId = 1;
        public RecordsRepositoryList(bool initializeWithSampleData = false)
        {
            if (initializeWithSampleData)
            {
                AddRecord(new Record {Title = "The Flowing Water", Artist = "Michael Jackson", Duration = 180, PublicationYear = 2020 });
                AddRecord(new Record { Title = "The Echoing Hills", Artist = "Addy Wilson", Duration = 200, PublicationYear = 2021 });
                AddRecord(new Record { Title = "The Whispering Woods", Artist = "Rasperr peter", Duration = 220, PublicationYear = 2022 });
                AddRecord(new Record { Title = "The Singing Sea", Artist = "Loki Guttenham", Duration = 240, PublicationYear = 2023 });
            }
        }

        public Record AddRecord(Record record)
        {
            if(record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }
            record.Id = _nextId++;
            _records.Add(record);
            return record;
        }
        public Record? GetRecord(int id)
        {
            return _records.FirstOrDefault(r => r.Id == id);
        }
        public List<Record> GetRecords()
        {
            return _records.ToList();
        }
        public Record? UpdateRecord(int id, Record record)
        {
            if(record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }
            Record? existingRecord = GetRecord(id);
            if(existingRecord == null)
            {
                return null;
            }
            existingRecord.Title = record.Title;
            existingRecord.Artist = record.Artist;
            existingRecord.Duration = record.Duration;
            existingRecord.PublicationYear = record.PublicationYear;
            return existingRecord;
        }
        public Record? DeleteRecord(int id)
        {
            throw new NotImplementedException();
        }
    }
}
