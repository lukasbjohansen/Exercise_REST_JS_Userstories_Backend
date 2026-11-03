namespace REST_API
{
    public class RecordsRepositoryList : IRecordsRepository
    {
        private readonly List<Record> _records = new List<Record>();
        private int _nextId = 1;
        public int Count { get { return _records.Count; } }
        public RecordsRepositoryList(bool initializeWithSampleData = false, int sampleDataSet = 0)
        {
            if (initializeWithSampleData)
            {
                switch(sampleDataSet)
                {
                    case 1:
                        _records.Add(new Record { Id = _nextId++, Title = "Abbey Road", Artist = "The Beatles", PublicationYear = 1969, Duration = 2820 });
                        _records.Add(new Record { Id = _nextId++, Title = "Thriller", Artist = "Michael Jackson", PublicationYear = 1982, Duration = 2520 });
                        _records.Add(new Record { Id = _nextId++, Title = "Back in Black", Artist = "AC/DC", PublicationYear = 1980, Duration = 2520 });
                        _records.Add(new Record { Id = _nextId++, Title = "Dark Side of the Moon", Artist = "Pink Floyd", PublicationYear = 1973, Duration = 2580 }); 
                        break;
                    default:
                        _records.Add(new Record { Id = _nextId++, Title = "The Flowing Water", Artist = "Michael Jackson", Duration = 180, PublicationYear = 2020 });
                        _records.Add(new Record { Id = _nextId++, Title = "The Echoing Hills", Artist = "Addy Wilson", Duration = 200, PublicationYear = 2021 });
                        _records.Add(new Record { Id = _nextId++, Title = "The Whispering Woods", Artist = "Rasperr peter", Duration = 220, PublicationYear = 2022 });
                        _records.Add(new Record { Id = _nextId++, Title = "The Singing Sea", Artist = "Loki Guttenham", Duration = 240, PublicationYear = 2023 });
                        break;
                }
            }
        }

        //public Record AddRecord(Record record)
        //{
        //    if(record == null)
        //    {
        //        throw new ArgumentNullException(nameof(record));
        //    }
        //    record.Id = _nextId++;
        //    _records.Add(record);
        //    return record;
        //}
        //public Record? GetRecord(int id)
        //{
        //    return _records.FirstOrDefault(r => r.Id == id);
        //}
        public List<Record> GetRecords(string? title = null, string? artist = null, int? publicationYear = null, int? minDuration = null, int? maxDuration = null)
        {
            var query = _records.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(r => r.Title.ToLower().Contains(title.ToLower()));
            }

            if (!string.IsNullOrEmpty(artist))
            {
                query = query.Where(r => r.Artist.ToLower().Contains(artist.ToLower()));
            }

            if (publicationYear.HasValue)
            {
                query = query.Where(r => r.PublicationYear == publicationYear.Value);
            }

            if (minDuration.HasValue)
            {
                query = query.Where(r => r.Duration >= minDuration.Value);
            }

            if (maxDuration.HasValue)
            {
                query = query.Where(r => r.Duration <= maxDuration.Value);
            }

            return query.ToList();
        }
        //public Record? UpdateRecord(int id, Record record)
        //{
        //    if(record == null)
        //    {
        //        throw new ArgumentNullException(nameof(record));
        //    }
        //    Record? existingRecord = GetRecord(id);
        //    if(existingRecord == null)
        //    {
        //        return null;
        //    }
        //    existingRecord.Title = record.Title;
        //    existingRecord.Artist = record.Artist;
        //    existingRecord.Duration = record.Duration;
        //    existingRecord.PublicationYear = record.PublicationYear;
        //    return existingRecord;
        //}
        //public Record? DeleteRecord(int id)
        //{
        //    Record? existingRecord = GetRecord(id);
        //    if(existingRecord == null)
        //    {
        //        return null;
        //    }
        //    _records.Remove(existingRecord);
        //    return existingRecord;
        //}
    }
}
