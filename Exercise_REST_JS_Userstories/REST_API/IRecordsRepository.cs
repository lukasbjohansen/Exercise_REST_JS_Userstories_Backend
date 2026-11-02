namespace REST_API
{
    public interface IRecordsRepository
    {
        Record AddRecord(Record record);
        Record? DeleteRecord(int id);
        Record? GetRecord(int id);
        List<Record> GetRecords();
        Record? UpdateRecord(int id, Record record);
    }
}